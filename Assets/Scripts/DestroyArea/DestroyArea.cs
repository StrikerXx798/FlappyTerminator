using UnityEngine;

public abstract class DestroyArea<T> : MonoBehaviour where T : Element
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out T element))
        {
            Destroy(element.gameObject);
        }
    }
}