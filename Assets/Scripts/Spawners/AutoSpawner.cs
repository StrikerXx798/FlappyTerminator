using System.Collections;
using UnityEngine;

public abstract class AutoSpawner<T> : BaseSpawner<T> where T : Element
{
    [SerializeField] private float _repeatRate = 2f;

    private Coroutine _spawnCoroutine;

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    private void OnDestroy()
    {
        RemoveCoroutine();
    }

    private void OnDisable()
    {
        RemoveCoroutine();
    }

    private IEnumerator SpawnCoroutine()
    {
        var wait = new WaitForSeconds(_repeatRate);

        while (enabled)
        {
            GetItem();

            yield return wait;
        }
    }

    private void RemoveCoroutine()
    {
        if (_spawnCoroutine is not null)
        {
            StopCoroutine(_spawnCoroutine);
        }
    }
}