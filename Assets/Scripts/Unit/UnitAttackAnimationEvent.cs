using System;
using UnityEngine;

public class UnitAttackAnimationEvent : MonoBehaviour
{
    public event Action OnThrow; 

    public void Throw()
    {
        OnThrow?.Invoke();
    }
}
