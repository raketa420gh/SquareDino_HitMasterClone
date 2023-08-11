
using UnityEngine;

public interface IUnitFactory
{
    IUnit CreateUnit(UnitType type, Vector3 position);
}