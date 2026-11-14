using System;
using UnityEngine;

public class InputProcessor : MonoBehaviour
{
    private static readonly string HorizontalAxis = "Horizontal";
    private static readonly string JumpButton = "Jump";
    private static readonly string SprintButton = "Sprint";

    public event Action JumpPressed;
    public event Action<float> MovePressed;
    public event Action<float> SprintPresssed;

    private void Update()
    {
        ProcessMove();
        ProcessJump();
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
}
