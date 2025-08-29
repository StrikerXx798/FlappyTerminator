using System;
using UnityEngine;

public class ShipCollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;

    private void OnValidate()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.TryGetComponent(out IInteractable interactable))
        {
            if (other.TryGetComponent(out EnemyBullet bullet))
            {
                bullet.Explode();
            }

            CollisionDetected?.Invoke(interactable);
        }
    }
}