using UnityEngine;

[CreateAssetMenu(order = 51, menuName = "Unit", fileName = "NewUnitData")]
public class UnitData : ScriptableObject
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private Color _color = Color.white;

    public int MaxHealth => _maxHealth;
    public float MoveSpeed => _moveSpeed;
    public Color Color => _color;
}