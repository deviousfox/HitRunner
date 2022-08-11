using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 4;
    [SerializeField] private int _damage;
    private Rigidbody rigidbody;

    public void Init(Vector3 direction)
    {
        if (rigidbody == null)
            rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;

        rigidbody.AddForce(direction * _bulletSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
        }

        BulletsPool.Instance.DestroyObject(this);
    }
}