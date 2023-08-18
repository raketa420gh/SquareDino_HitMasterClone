using UnityEngine;

public class UnitLayerSelector : MonoBehaviour
{
    [SerializeField] private string _playerLayerName = "Player";
    [SerializeField] private string _enemyLayerName = "Enemy";
    [SerializeField] private GameObject[] _layerSelectorTargets;

    public void SetLayer(UnitType type)
    {
        switch (type)
        {
            case UnitType.Player:
                SetLayer(_playerLayerName);
                break;
            case UnitType.Enemy:
                SetLayer(_enemyLayerName);
                break;
        }
    }

    private void SetLayer(string layerName)
    {
        foreach (var target in _layerSelectorTargets)
        {
            target.layer = LayerMask.NameToLayer(layerName);
        }
    }
}
