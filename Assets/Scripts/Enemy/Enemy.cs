using System;
using UnityEngine;

public class Enemy : Element, IInteractable
{
    public Action Died;
    
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