using UnityEngine;

public class ShipBulletSpawner : ManualSpawner<ShipBullet>
{
    [SerializeField] private Transform _spawnPoint;

    protected override ShipBullet CreatePooledItem()
    {
        var bullet = Instantiate(Prefab);
        bullet.transform.position = _spawnPoint.position;
        bullet.SetDirection(_spawnPoint.up);

        return bullet;
    }
}
