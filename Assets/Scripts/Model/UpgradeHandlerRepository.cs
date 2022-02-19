﻿using System;
using System.Collections.Generic;
using CommonClasses;
using Data;
using Tools;

public class UpgradeHandlerRepository : BaseController, IRepository<int, IUpgradeCarHandler>
{
    public IReadOnlyDictionary<int, IUpgradeCarHandler> Content => _content;

    private Dictionary<int, IUpgradeCarHandler> _content = new Dictionary<int, IUpgradeCarHandler>();

    public UpgradeHandlerRepository(IReadOnlyList<UpgradeItemConfig> configs)
    {
        PopulateItems(ref _content, configs);
    }

    private void PopulateItems(ref Dictionary<int, IUpgradeCarHandler> upgradeItems, IReadOnlyList<UpgradeItemConfig> configs)
    {
        foreach (var config in configs)
        {
            upgradeItems[config.Id] = CreateHandler(config);
        }
    }

    private IUpgradeCarHandler CreateHandler(UpgradeItemConfig config)
    {
        switch (config.UpgradeType)
        {
            case UpgradeType.None:
                return UpgradeHandelrStub.Default;
       
            case UpgradeType.Speed:
                return new SpeedUpgradeHandler(config);
            
            case UpgradeType.Control:
                return UpgradeHandelrStub.Default;
          
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public interface IShedController
{
    void Enter();
    void Exit();
}