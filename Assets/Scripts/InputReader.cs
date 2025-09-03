using UnityEngine;
using System;
using System.Collections;

public class InputReader : MonoBehaviour
{
    private const int AttackActionMouseButton = 0;
    private const string JumpButton = "space";

    [SerializeField] private float _primaryActionDelay;
    
    public event Action JumpActionPerformed;
    public event Action AttackActionPerformed;

    private void Update()
    {
        ReadJumpActionInput();
        ReadAttackActionInput();
    }

    private void ReadJumpActionInput()
    {
        if (Input.GetKeyDown(JumpButton))
        {
            JumpActionPerformed?.Invoke();
        }
    }

    private void ReadAttackActionInput()
    {
        if (Input.GetMouseButtonDown(AttackActionMouseButton))
        {
            AttackActionPerformed?.Invoke();
        }
    }
}