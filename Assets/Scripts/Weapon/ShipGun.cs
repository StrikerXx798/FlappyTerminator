using System.Collections;
using UnityEngine;

public class ShipGun : ManualSpawner<Bullet>
{
    [SerializeField] private float _shootDelay;
    [SerializeField] private InputReader _inputReader;

    private bool _isAttackActionDelayed;

    private void OnEnable()
    {
        _inputReader.AttackActionPerformed += Shoot;
    }

    private void OnDisable()
    {
        _inputReader.AttackActionPerformed -= Shoot;
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
        StartCoroutine(DelayAttackAction());
    }

    private IEnumerator DelayAttackAction()
    {
        if (_isAttackActionDelayed)
            yield break;

        _isAttackActionDelayed = true;
        Spawn();

        yield return new WaitForSeconds(_shootDelay);

        _isAttackActionDelayed = false;
    }
}