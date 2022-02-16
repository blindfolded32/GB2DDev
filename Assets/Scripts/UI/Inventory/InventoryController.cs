using System.Collections.Generic;
using Data;
using Item;
using UnityEngine;

namespace UI.Inventory
{
    public class InventoryController : BaseController, IInventoryController
    {
        private readonly IInventoryModel _inventoryModel;
        private  IInventoryView _inventoryView;
        private readonly IItemsRepository _itemsRepository;

        public InventoryController(List<ItemConfig> itemConfigs, IInventoryModel inventoryModel)
        {
            _inventoryModel = inventoryModel;
            _itemsRepository = new ItemsRepository(itemConfigs);
            
            foreach (var item in _itemsRepository.Items.Values)
                _inventoryModel.EquipItem(item);
        }

        public void InitShedUI(Transform placeForUI, ResourcePath layoutPrefabPath, ResourcePath itemPrefabPath)
        {
            var view = Object.Instantiate(ResourceLoader.LoadPrefab(layoutPrefabPath), placeForUI);
            _inventoryView = view.GetComponent<IInventoryView>();
            _inventoryView.LoadShedUI(OnItemToggleChanged, _inventoryModel.GetAllItems(), itemPrefabPath);
        }

        public void ShowInventory()
        {
            _inventoryView.Show();
        }
        
        private void OnItemToggleChanged(IItem item, bool isOn)
        {
            if (isOn)
                _inventoryModel.EquipItem(item);
            else
                _inventoryModel.UnEquipItem(item);
        }
        
        protected override void OnDispose()
        {
            _inventoryView?.Hide();
            _inventoryView?.OnDispose();
        }
    }
}
