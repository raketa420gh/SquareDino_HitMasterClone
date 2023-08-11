using UnityEngine;

public class Bullet : MonoBehaviour, IProjectile
{
    [SerializeField] private float _flySpeed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _damage = 50;
    private Vector3 _direction;
    private string _enemyLayer = "Enemy";

    public float FlySpeed => _flySpeed;

    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction * _flySpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"collided with {other.name}");

        var isCollidedEnemy = other.gameObject.layer == LayerMask.NameToLayer(_enemyLayer);

        if (isCollidedEnemy)
        {
            var enemy = other.GetComponentInParent<IUnit>();
            enemy.TakeDamage(_damage);
            gameObject.SetActive((false));
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}