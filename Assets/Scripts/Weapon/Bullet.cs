using UnityEngine;

public class Bullet : Element, IInteractable
{
    [SerializeField] private float _speed;
    [SerializeField] private ExplosionEffect _explosionEffectPrefab;
    [SerializeField] private LayerMask _targetMask;

    private Vector2 _direction;

    private void Update()
    {
        transform.Translate(_direction * (_speed * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var isTarget = ((1 << collision.gameObject.layer) & _targetMask) != 0;

        if (isTarget)
        {
            Explode();
        }
    }

    private void Explode()
    {
        var explosion = Instantiate(
            _explosionEffectPrefab,
            transform.position,
            Quaternion.identity
        );
        explosion.Play();
        Destroy(gameObject);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
        transform.up = direction;
    }
}