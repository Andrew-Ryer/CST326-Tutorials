using System;
using myScripts;
using UnityEngine;

public class myTrashCounter : myBaseCounter
{

    public static event EventHandler OnAnyObjectTrashed;
    
    new public static void ResetStaticData()
    {
        OnAnyObjectTrashed = null;
    }
    
    public override void Interact(myPlayer player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
            
            OnAnyObjectTrashed?.Invoke(this, EventArgs.Empty);
        }
    }
}
