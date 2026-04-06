using myScripts;
using UnityEngine;

public class myDeliveryCounter : myBaseCounter
{

    public static myDeliveryCounter Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

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
