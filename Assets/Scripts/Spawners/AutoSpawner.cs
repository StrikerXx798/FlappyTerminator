using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public abstract class AutoSpawner<T> : MonoBehaviour where T : Element
{
    [SerializeField] private T _prefab;
    [SerializeField] private float _repeatRate = 2f;
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

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void GetItem()
    {
        Pool.Get();
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

    private void OnReleasePooledItem(T item)
    {
        item.gameObject.SetActive(false);
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

    public void ClearActiveItems()
    {
        foreach (var item in FindObjectsByType<T>(FindObjectsSortMode.None))
        {
            Destroy(item.gameObject);
        }

        Pool.Dispose();
    }
}