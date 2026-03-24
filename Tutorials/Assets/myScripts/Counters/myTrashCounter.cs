using myScripts;
using UnityEngine;

public class myTrashCounter : myBaseCounter
{
    public override void Interact(myPlayer player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
        }
    }
}
