using UnityEngine;

public interface IUnitRagdoll
{
    Rigidbody[] AllRigidBodies { get; }
    void Activate();
    void Deactivate();
}