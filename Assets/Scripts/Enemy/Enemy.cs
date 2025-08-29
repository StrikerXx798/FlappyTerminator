using System;
using UnityEngine;

public class Enemy : Element, IInteractable
{
    [SerializeField] private float _speed;

    public Action Died;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    private void Update()
    {
        var vector3 = transform.position;
        vector3.z = 0;
        transform.position = vector3;
        transform.Translate(transform.up * (_speed * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ShipBullet bullet))
        {
            bullet.Explode();
            Die();
        }
    }

    private void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}