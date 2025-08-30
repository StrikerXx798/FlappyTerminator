using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var vector3 = transform.position;
        vector3.z = 0;
        transform.position = vector3;
        transform.Translate(transform.up * (_speed * Time.deltaTime), Space.World);
    }
}