using UnityEngine;
using UnityEngine.Pool;

public abstract class BaseSpawner<T> : MonoBehaviour where T : Element
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _maxPoolSize;

    protected T Prefab => _prefab;
	private ObjectPool<T> _pool;

	protected void Awake()
    {
        _pool = new ObjectPool<T>
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

    protected virtual void OnGetPooledItem(T item)
    {
        item.gameObject.SetActive(true);
    }

    protected virtual void OnDestroyPooledItem(T item)
    {
        Destroy(item.gameObject);
    }

    private void OnReleasePooledItem(T item)
    {
        item.gameObject.SetActive(false);
    }
    
    protected void GetItem()
    {
        _pool.Get();
    }

    public void ClearActiveItems()
    {
        foreach (var item in FindObjectsByType<T>(FindObjectsSortMode.None))
        {
            Destroy(item.gameObject);
        }

        _pool.Dispose();
    }
}