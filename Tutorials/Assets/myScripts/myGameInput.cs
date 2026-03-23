using System;
using UnityEngine;

namespace myScripts
{
    public class myGameInput : MonoBehaviour
    {
        public event EventHandler OnInteractAction;
        public event EventHandler OnInteractAlternateAction;
        private MyPlayerInputActions playerInputActions;
        private void Awake()
        { 
            playerInputActions = new MyPlayerInputActions();
            playerInputActions.Player.Enable();

            playerInputActions.Player.Interact.performed += Interact_performed;
            playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        }

        private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
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
