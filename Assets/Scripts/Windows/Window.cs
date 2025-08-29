using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private Button _button;
    
    public Action ButtonClicked;
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickHandler);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickHandler);
    }

    private void OnClickHandler()
    {
        ButtonClicked?.Invoke();
    }
}