using UnityEngine;
using Zenject;

public class UnitFactory : IUnitFactory
{
    private IAssetProvider _assetProvider;
    private string _unitPath = "Prefabs/Unit";
    private string _playerDataPath = "Data/PlayerData";
    private string _enemyUnitDataPath = "Data/EnemyData";

    [Inject]
    public void Construct(IAssetProvider assetProvider) => 
        _assetProvider = assetProvider;

    public IUnit CreateUnit(UnitType type, Vector3 position)
    {
        var data = GetUnitData(type);
        var path = new string(_unitPath);
        var go = _assetProvider.Instantiate(path, position);
        var unit = go.GetComponent<IUnit>();
        unit.Initialize(type, data, position);
        go.layer = LayerMask.NameToLayer("Enemy");

        if (type != UnitType.Player) 
            return unit;
        
        IPlayer player = go.AddComponent<Player>();
        player.Initialize();
        unit.DeactivateHealthBar();

        return unit;
    }

    private UnitData GetUnitData(UnitType type)
    {
        var data = type switch
        {
            UnitType.Player => Resources.Load<UnitData>(_playerDataPath),
            UnitType.Enemy => Resources.Load<UnitData>(_enemyUnitDataPath),
            UnitType.Neutral => ScriptableObject.CreateInstance<UnitData>(),
            _ => null
        };

        return data;
    }
}