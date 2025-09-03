using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Mover _ship;
    [SerializeField] private float _xOffset;

    private void LateUpdate()
    {
        var position = transform.position;
        position.x = _ship.transform.position.x + _xOffset;
        transform.position = position;
    }
}