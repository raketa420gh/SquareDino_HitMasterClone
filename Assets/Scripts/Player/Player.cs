using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private IUnit _unit;
    
    public IUnit Unit => _unit;

    public void Initialize()
    {
        _unit ??= GetComponent<IUnit>();
        
        _unit.WorldObject.layer = LayerMask.NameToLayer("Player");
        
        name = "PlayerUnit";
    }
}