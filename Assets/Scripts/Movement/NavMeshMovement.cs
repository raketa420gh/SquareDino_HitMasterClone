using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NavMeshMovement : MonoBehaviour, IMovement
{
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 destination)
    {
        _navMeshAgent.destination = destination;
    }

    public void Stop()
    {
        _navMeshAgent.Stop();
    }
}