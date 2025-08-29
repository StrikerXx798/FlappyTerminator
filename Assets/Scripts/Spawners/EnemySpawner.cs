using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : AutoSpawner<Enemy>
{
    [SerializeField] ScoreCounter _scoreCounter;
    [SerializeField] private BoxCollider2D _spawnArea;

    protected override Enemy CreatePooledItem()
    {
        var randomPosition = GenerateRandomPosition();
        var enemy = Instantiate(Prefab, randomPosition, Prefab.transform.rotation);

        enemy.Died += _scoreCounter.AddScore;

        return enemy;
    }

    protected override void OnGetPooledItem(Enemy enemy)
    {
        enemy.transform.position = GenerateRandomPosition();
        enemy.gameObject.SetActive(true);
    }

    protected override void OnDestroyPooledItem(Enemy enemy)
    {
        enemy.Died -= _scoreCounter.AddScore;
        base.OnDestroyPooledItem(enemy);
    }

    private Vector3 GenerateRandomPosition()
    {
        var randomYPosition = Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y);

        return new Vector3(transform.position.x, randomYPosition, 0);
    }
}