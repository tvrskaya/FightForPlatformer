using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private static readonly string HorizontalAxis = "Horizontal";
    private static readonly string JumpButton = "Jump";
    private static readonly string SprintButton = "Sprint";
    private static readonly string AttackButton = "Attack";

    public event Action JumpPressed;
    public event Action<float> MovePressed;
    public event Action<float> SprintPresssed;
    public event Action AttackPressed;

    private void Update()
    {
        ProcessMove();
        ProcessJump();
        ProcessAttack();
    }

    private void ProcessMove()
    {
        float horizontalInput = Input.GetAxis(HorizontalAxis);
        
        if (horizontalInput != 0f && Input.GetButton(SprintButton))
            SprintPresssed?.Invoke(horizontalInput);
        else
            MovePressed?.Invoke(horizontalInput);
    }

    private void ProcessJump()
    {
        if (Input.GetButtonDown(JumpButton))
        {
            JumpPressed?.Invoke();
        }
    }

    private void ProcessAttack()
    {
        if (Input.GetButtonDown(AttackButton))
        {
            AttackPressed?.Invoke();
        }
    }
}
