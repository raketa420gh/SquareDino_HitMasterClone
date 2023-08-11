using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private int _poolCount = 25;
    [SerializeField] private bool _isAutoExpand = true;
    [SerializeField] private Bullet _prefab;

    private Pool<Bullet> _pool;

    public Pool<Bullet> Pool => _pool;

    public void CreatePool()
    {
        _pool = new Pool<Bullet>(_prefab, _poolCount, transform);
        _pool.AutoExpand = _isAutoExpand;
    }
}
