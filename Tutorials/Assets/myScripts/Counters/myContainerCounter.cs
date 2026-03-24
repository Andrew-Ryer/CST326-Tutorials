using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace myScripts
{
    public class myContainerCounter : myBaseCounter
    {

        public event EventHandler OnPlayerGrabbedObject;
        
        [SerializeField] private myKitchenObjectSO kitchenObjectSo;

        public override void Interact(myPlayer player)
        {
            if (!player.HasKitchenObject())
            {
                // Player is not carrying anything
                myKitchenObject.SpawnKitchenObject(kitchenObjectSo, player);
                
                OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
