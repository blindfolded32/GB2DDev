﻿using System.Collections.Generic;
using CommonClasses;
using Data;
using Features.InventoryFeature;
using Item;
using UnityEngine;

public class ShedController : BaseController, IShedController
{
    private readonly IUpgradeableCar _car;
    private readonly UpgradeHandlerRepository _upgradeRepository;
    private readonly InventoryController _inventoryController;
    private readonly IInventoryModel _model;

    public ShedController(IReadOnlyList<UpgradeItemConfig> upgradeItems, List<ItemConfig> items, IUpgradeableCar car, Transform placeForUI, InventoryController inventoryController)
    {
        _car = car;
        _upgradeRepository = new UpgradeHandlerRepository(upgradeItems);
        AddController(_upgradeRepository);

        _inventoryController = inventoryController;
        _inventoryController.SetInventoryViewPosition(placeForUI);
        _model = _inventoryController.Model;
        _inventoryController.CloseAndSaveInventory += Exit;
    }

    public void Enter()
    {
        _inventoryController.DisplayEquippedItems();
        _inventoryController.ShowInventory();
        _car.Restore();
        Debug.Log($"Enter, car speed = {_car.Speed}");
    }

    public void Exit()
    {
        _upgradeRepository.EquipUpgradeItems(_model.GetUpgrades());
        EquipItems(_car, _model.GetEquippedItems(), _upgradeRepository.Content);
        Debug.Log($"Exit, car speed = {_car.Speed}");
    }

    private void EquipItems(IUpgradeableCar car,
        IReadOnlyList<IItem> equiped,
        IReadOnlyDictionary<int, IUpgradeCarHandler> upgradeHandlers)
    {
        foreach (var item in equiped)
        {
            if (upgradeHandlers.TryGetValue(item.Id, out var handler))
                handler.Upgrade(car);
        }
    }

    public new void OnDispose()
    {
        _inventoryController.CloseAndSaveInventory -= Exit;
        base.OnDispose();
    }
}