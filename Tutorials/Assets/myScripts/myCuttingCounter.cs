using UnityEngine;

namespace myScripts
{
    public class myCuttingCounter : myBaseCounter
    {
        [SerializeField] private myKitchenObjectSO cutKitchenObjectSo;
    
        public override void Interact(myPlayer player)
        {
            if (!HasKitchenObject())
            {
                // There is no KitchenObject here
                if (player.HasKitchenObject())
                {
                    // Player is carrying something
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
                else
                {
                    // Player not carrying anything
                }
            }
            else
            {
                // There is a KitchenObject here
                if (player.HasKitchenObject())
                {
                    // Player is carrying something
                }
                else
                {
                    // Player is not carrying anything
                    GetKitchenObject().SetKitchenObjectParent(player);
                }
            }
        }

        public override void InteractAlternate(myPlayer player)
        {
            if (HasKitchenObject())
            {
                // There is a KitchenObject here
                GetKitchenObject().DestroySelf();
                
                myKitchenObject.SpawnKitchenObject(cutKitchenObjectSo, this);
            }
        }
        
    }
}
