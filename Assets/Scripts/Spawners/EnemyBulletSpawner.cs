using UnityEngine;

public class EnemyBulletSpawner : AutoSpawner<EnemyBullet>
{
    [SerializeField] Transform _spawnPoint;

    protected override EnemyBullet CreatePooledItem()
    {
        var bullet = Instantiate(Prefab);
        bullet.transform.position = _spawnPoint.position;

        return bullet;
    }
}
