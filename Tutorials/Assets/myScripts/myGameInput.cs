using System;
using UnityEngine;

namespace myScripts
{
    public class myGameInput : MonoBehaviour
    {
        public event EventHandler OnInteractAction;
        private MyPlayerInputActions playerInputActions;
        private void Awake()
        { 
            playerInputActions = new MyPlayerInputActions();
            playerInputActions.Player.Enable();

            playerInputActions.Player.Interact.performed += Interact_performed;
        }

        private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnInteractAction?.Invoke(this, EventArgs.Empty);
        }

        public Vector2 GetMovementVectorNormalized()
        {
            Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        
            inputVector = inputVector.normalized;
        
            return inputVector;
        }
    }
}
