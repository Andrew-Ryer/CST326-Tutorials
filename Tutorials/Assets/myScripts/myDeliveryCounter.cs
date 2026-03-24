using myScripts;
using UnityEngine;

public class myDeliveryCounter : myBaseCounter
{
    public override void Interact(myPlayer player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetKitchenObject().TryGetPlate(out myPlateKitchenObject plateKitchenObject))
            {
                // Only accepts Plates

                myDeliveryManager.Instance.DeliverRecipe(plateKitchenObject);
                
                player.GetKitchenObject().DestroySelf();
            }
        }
    }
}
