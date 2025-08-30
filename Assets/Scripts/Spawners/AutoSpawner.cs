using System.Collections;
using UnityEngine;

public abstract class AutoSpawner<T> : BaseSpawner<T> where T : Element
{
    [SerializeField] private float _repeatRate = 2f;
    
    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
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
}