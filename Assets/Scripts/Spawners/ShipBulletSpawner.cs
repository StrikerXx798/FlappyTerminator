using UnityEngine;

public class ShipBulletSpawner : ManualSpawner<ShipBullet>
{
    [SerializeField] Transform _spawnPoint;

    protected override ShipBullet CreatePooledItem()
    {
        var bullet = Instantiate(Prefab);
        bullet.transform.position = _spawnPoint.position;

        return bullet;
    }
}
