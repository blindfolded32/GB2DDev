using System;
using System.Collections.Generic;
using CommonClasses;
using Player;
using UnityEngine;
using Object = UnityEngine.Object; 
namespace UI.Menu
{
    public class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/mainMenu"};
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;
        private Dictionary<int, GameObject> _trails = new Dictionary<int, GameObject>();

        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame);
            _view.UpdateTouch += OnTouch;
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
        }
        
        private void OnTouch(Touch data)
        {
            switch (data.phase)
            {
                case TouchPhase.Began:
                    AddNewTrail(data);
                    break;
                case TouchPhase.Moved:
                    if (_trails.TryGetValue(data.fingerId, out var trail))
                    {
                        
                        var pos = new Vector3( Camera.main.ScreenToWorldPoint(data.position).x, Camera.main.ScreenToWorldPoint(data.position).y,0);
                        trail.transform.position = pos;
                    }
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    RemoveTrail(data);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddNewTrail(Touch data)
        {
            var trail = _view.CreateTrail(Camera.main.ScreenToWorldPoint(data.position));
            _trails.Add(data.fingerId,trail);
        }

        private void RemoveTrail(Touch data)
        {
            _trails.TryGetValue(data.fingerId, out var trail);
            GameObject.Destroy(trail, 1f);
            _trails.Remove(data.fingerId);
        }
        
        protected override void OnDispose()
        {
            base.OnDispose();
            _view.UpdateTouch -= OnTouch;
        }
    }
}

