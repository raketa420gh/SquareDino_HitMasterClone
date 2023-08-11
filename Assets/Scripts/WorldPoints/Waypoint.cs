using UnityEngine;

public class Waypoint : WorldPoint
{
    [SerializeField] private WorldPoint[] _enemyPoints;
    private IUnit[] _spawnedEnemies;

    public IUnit[] SpawnedEnemies => _spawnedEnemies;

    public WorldPoint[] GetEnemyPoints()
    {
        return _enemyPoints is not { Length: > 0 } ? null : _enemyPoints;
    }

    public void SetWaypointEnemies(IUnit[] enemies)
    {
        _spawnedEnemies = enemies;
    }

    public void ShowEnemies()
    {
        foreach (var enemy in _spawnedEnemies)
        {
            enemy.WorldObject.gameObject.SetActive(true);
        }
    }

    public void HideEnemies()
    {
        foreach (var enemy in _spawnedEnemies)
        {
            enemy.WorldObject.gameObject.SetActive(false);
        }
    }
}