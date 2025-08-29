using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public abstract class ManualSpawner<T> : MonoBehaviour where T : Element
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _maxPoolSize;

    protected T Prefab => _prefab;
    public ObjectPool<T> Pool { get; private set; }

    protected void Awake()
    {
        Pool = new ObjectPool<T>
        (
            createFunc: CreatePooledItem,
            actionOnGet: OnGetPooledItem,
            actionOnRelease: OnReleasePooledItem,
            actionOnDestroy: OnDestroyPooledItem,
            defaultCapacity: _maxPoolSize,
            maxSize: _maxPoolSize,
            collectionCheck: true
        );
    }

    protected virtual T CreatePooledItem()
    {
        return Instantiate(Prefab);
    }

    private void OnGetPooledItem(T item)
    {
        item.gameObject.SetActive(true);
    }

    private void OnReleasePooledItem(T item)
    {
        item.gameObject.SetActive(false);
    }

    private void OnDestroyPooledItem(T item)
    {
        Destroy(item.gameObject);
    }

    public void GetItem()
    {
        Pool.Get();
    }
}