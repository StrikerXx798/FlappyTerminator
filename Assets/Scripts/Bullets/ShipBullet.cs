using UnityEngine;

public class ShipBullet : Bullet
{
    private Vector2 _direction;

    private new void Update()
    {
        transform.Translate(_direction * (Speed * Time.deltaTime), Space.World);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
        transform.up = direction; // Устанавливаем поворот пули
    }
}