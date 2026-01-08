using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public static Action<Vector2> OnMove;

    private InputSystem_Actions actions;
    
    private void Start()
    {
        actions = new InputSystem_Actions();
        actions.Enable();
    }
    

    private void Update()
    {
        Vector2 moveInput = actions.Player.Move.ReadValue<Vector2>();
        OnMove?.Invoke(moveInput);
    }

    private void OnMovePlayer(InputAction.CallbackContext obj)
    {
        OnMove?.Invoke(obj.ReadValue<Vector2>());
    }

}
