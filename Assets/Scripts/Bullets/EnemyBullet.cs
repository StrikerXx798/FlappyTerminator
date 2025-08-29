using UnityEngine;

public class EnemyBullet : Bullet, IInteractable
{
    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }
    
    private new void Update()
    {
        transform.Translate(transform.up * (Speed * Time.deltaTime), Space.World);
    }
}