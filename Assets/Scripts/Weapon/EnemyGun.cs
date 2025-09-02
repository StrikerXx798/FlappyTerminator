public class EnemyGun : AutoSpawner<Bullet>
{
    protected override Bullet CreatePooledItem()
    {
        var bullet = Instantiate(Prefab);
        bullet.transform.position = transform.position;
        bullet.SetDirection(transform.up);

        return bullet;
    }
}