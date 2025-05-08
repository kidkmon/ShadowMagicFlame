using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardsAssetCollection : ScriptableObject
{
    [SerializeField] CardAssetConfig[] CardAssetConfigs;

    Dictionary<int, CardAssetConfig> _cardAssetConfigs;

    public int Size => CardAssetConfigs.Length;

    public void Initialize()
    {
        _cardAssetConfigs = new Dictionary<int, CardAssetConfig>();
        foreach (var config in CardAssetConfigs)
        {
            _cardAssetConfigs.Add(config.Id, config);
        }
    }

    public CardAssetConfig GetConfig(int id)
    {
        return _cardAssetConfigs[id];
    }
}