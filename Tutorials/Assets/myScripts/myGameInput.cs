using System;
using UnityEngine;

public class myGameInput : MonoBehaviour
{
    private MyPlayerInputActions playerInputActions;
    private void Awake()
    { 
        playerInputActions = new MyPlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        
        inputVector = inputVector.normalized;
        
        return inputVector;
    }
}
