using UnityEngine;
using System;
using System.Collections;

public class InputReader : MonoBehaviour
{
    private const int PrimaryActionMouseButton = 0;
    private const string JumpButton = "space";

    [SerializeField] private float _primaryActionDelay;

    private bool _isPrimaryActionDelayed;

    public event Action JumpActionPerformed;
    public event Action PrimaryActionPerformed;

    private void Update()
    {
        ReadJumpActionInput();
        ReadPrimaryActionInput();
    }

    private void ReadJumpActionInput()
    {
        if (Input.GetKeyDown(JumpButton))
        {
            JumpActionPerformed?.Invoke();
        }
    }

    private void ReadPrimaryActionInput()
    {
        if (Input.GetMouseButtonDown(PrimaryActionMouseButton))
        {
            StartCoroutine(DelayPrimaryAction());
        }
    }

    private IEnumerator DelayPrimaryAction()
    {
        if (_isPrimaryActionDelayed)
            yield break;

        _isPrimaryActionDelayed = true;
        PrimaryActionPerformed?.Invoke();

        yield return new WaitForSeconds(_primaryActionDelay);

        _isPrimaryActionDelayed = false;
    }
}