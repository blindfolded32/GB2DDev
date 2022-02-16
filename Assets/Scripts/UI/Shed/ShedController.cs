using System.Collections.Generic;
using Data;
using Item;
using UI.Inventory;
using UnityEngine;

namespace Model
{
    public class ShedController : BaseController, IShedController
    {
        private readonly IReadOnlyList<UpgradeItemConfig> _upgradeItems;
        private readonly IUpgradeableCar _car;
        private readonly UpgradeHandlerRepository _upgradeRepository;
        private readonly InventoryController _inventoryController;
        private readonly IInventoryModel _inventoryModel;
        
        private readonly Transform _uiTransform;
  
        private readonly ResourcePath _shedUIPrefabPath = new ResourcePath() { PathResource = "Prefabs/Inventory"};
        private readonly ResourcePath _shedItemPrefabPath = new ResourcePath() { PathResource = "Prefabs/InventoryItem"};

        public ShedController(IInventoryModel inventoryModel, IReadOnlyList<UpgradeItemConfig> upgradeItems, List<ItemConfig> items, IUpgradeableCar car, Transform uiTransform)
        {
            _upgradeItems = upgradeItems;
            _car = car;
            _inventoryModel = inventoryModel;//new InventoryModel();
            _uiTransform = uiTransform;
            _upgradeRepository = new UpgradeHandlerRepository(upgradeItems);

        
            AddController(_upgradeRepository);
            _inventoryController = new InventoryController(items, _inventoryModel);
            _inventoryController.InitShedUI(_uiTransform, _shedUIPrefabPath, _shedItemPrefabPath);
            AddController(_inventoryController);
        }

        public void Enter()
        {
            _inventoryController.ShowInventory();
        }
        protected override void OnDispose()
        {
            _upgradeRepository?.Dispose();
            _inventoryController?.Dispose();
        }
        public void Exit()
        {
            UpgradeCarWithEquipedItems(_car, _inventoryModel.GetEquippedItems(), _upgradeRepository.UpgradeItems);
        }

        private void UpgradeCarWithEquipedItems(IUpgradeableCar car,
            IReadOnlyList<IItem> equiped,
            IReadOnlyDictionary<int, IUpgradeCarHandler> upgradeHandlers)
        {
            foreach (var item in equiped)
            {
                if (upgradeHandlers.TryGetValue(item.Id, out var handler))
                    handler.Upgrade(car);
            }
        }
    }
}