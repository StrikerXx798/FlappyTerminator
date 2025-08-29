using UnityEngine;

public abstract class Bullet : Element
{
    [SerializeField] private float _speed;
    [SerializeField] private ExplosionEffect _explosionEffectPrefab;

    protected float Speed => _speed;
    
    protected virtual void Update()
    {
        transform.Translate(transform.up * (_speed * Time.deltaTime), Space.World);
    }

    public void Explode()
    {
        var explosion = Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);
        explosion.Play();
        Destroy(gameObject);
    }
}