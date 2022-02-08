<<<<<<< HEAD
﻿using CommonClasses;
using Player;
=======
﻿using Model.Analytic;
using Profile;
using Tools.Ads;
>>>>>>> upstream/Lesson2
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Transform _placeForUi;

    [SerializeField] private UnityAdsTools _ads;

    private MainController _mainController;
    private IAnalyticTools _analyticsTools;

    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(15f);
        _analyticsTools = new UnityAnalyticTools();
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer, _analyticsTools, _ads);
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
