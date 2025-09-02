using UnityEngine;

public class ShipGun : ManualSpawner<Bullet>
{
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.PrimaryActionPerformed += Shoot;
    }

    private void OnDisable()
    {
        _inputReader.PrimaryActionPerformed += Shoot;
    }

    protected override Bullet CreatePooledItem()
    {
        var bullet = Instantiate(Prefab);
        bullet.transform.position = transform.position;
        bullet.SetDirection(transform.up);

        return bullet;
    }

    private void Shoot()
    {
        Spawn();
    }
}