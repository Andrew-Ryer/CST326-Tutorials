using System;
using UnityEngine;

namespace myScripts
{
    public class myGameInput : MonoBehaviour
    {
        
        private const string PLAYER_PREFS_BINDINGS = "InputBindings";

        public static myGameInput Instance { get; private set; }
        
        public event EventHandler OnInteractAction;
        public event EventHandler OnInteractAlternateAction;
        public event EventHandler OnPauseAction;
        
        private MyPlayerInputActions playerInputActions;
        private void Awake()
        {
            Instance = this;
            
            playerInputActions = new MyPlayerInputActions();
            playerInputActions.Player.Enable();

            playerInputActions.Player.Interact.performed += Interact_performed;
            playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
            playerInputActions.Player.Pause.performed += Pause_performed;
        }
        
        private void OnDestroy() {
            playerInputActions.Player.Interact.performed -= Interact_performed;
            playerInputActions.Player.InteractAlternate.performed -= InteractAlternate_performed;
            playerInputActions.Player.Pause.performed -= Pause_performed;

            playerInputActions.Dispose();
        }
        
        private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
            OnPauseAction?.Invoke(this, EventArgs.Empty);
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
