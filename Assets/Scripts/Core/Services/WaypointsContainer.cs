using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaypointsContainer : MonoBehaviour, IWaypointsContainer
{
    [SerializeField] private Waypoint[] _waypoints;
    private Waypoint _lastWaypoint;

    private void Awake()
    {
        if (_waypoints is not { Length: > 0 })
                    return;
                
        _lastWaypoint = _waypoints.Last();
    }

    public WorldPoint[] GetAllEnemiesPoints()
    {
        var allEnemyPoints = new List<WorldPoint>();

        foreach (var waypoint in _waypoints)
            allEnemyPoints.AddRange(waypoint.GetEnemyPoints());

        return allEnemyPoints.ToArray();
    }

    public Waypoint[] GetWaypoints()
    {
        return _waypoints;
    }
}