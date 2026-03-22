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
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab);
            kitchenObjectTransform.GetComponent<myKitchenObject>().SetKitchenObjectParent(player);
            
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
