public class EnemyGun : AutoSpawner<EnemyBullet>
{
    protected override EnemyBullet CreatePooledItem()
    {
        var bullet = Instantiate(Prefab);
        bullet.transform.position = transform.position;

        return bullet;
    }
}