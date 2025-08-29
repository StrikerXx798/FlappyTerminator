using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private ShipBulletSpawner _shipBulletSpawner;

    private void OnEnable()
    {
        _inputReader.PrimaryActionPerformed += Shoot;
    }

    private void OnDisable()
    {
        _inputReader.PrimaryActionPerformed += Shoot;
    }

    private void Shoot()
    {
        _shipBulletSpawner.GetItem();
    }
}