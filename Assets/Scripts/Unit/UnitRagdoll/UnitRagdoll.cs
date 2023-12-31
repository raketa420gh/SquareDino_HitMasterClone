using UnityEngine;

public class UnitRagdoll : MonoBehaviour, IUnitRagdoll
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody[] allRigidBodies;

    public Rigidbody[] AllRigidBodies => allRigidBodies;

    public void Activate() => SetRagdollActive(true);

    public void Deactivate() => SetRagdollActive(false);

    private void SetRagdollActive(bool isActive)
    {
        animator.enabled = !isActive;

        foreach (var rigidbody in allRigidBodies)
            if (rigidbody != null)
                rigidbody.isKinematic = !isActive;
    }
}