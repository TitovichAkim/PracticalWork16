using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal
    {
        get; private set;
    }
    public bool JumpPass
    {
        get; set;
    }

    public void OnMove (InputValue value)
    {
        Horizontal = value.Get<Vector2>().x;
    }

    public void OnJump (InputValue value)
    {
        JumpPass = value.isPressed;
    }
}
