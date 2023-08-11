using UnityEngine;

[CreateAssetMenu(order = 51, menuName = "Unit", fileName = "NewUnitData")]
public class UnitData : ScriptableObject
{
    public int MaxHealth = 100;
    public float MoveSpeed = 5;
    public Color Color = Color.white;
}