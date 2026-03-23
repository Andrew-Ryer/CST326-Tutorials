using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace myScripts
{
    public class myCuttingCounter : myBaseCounter
    {
        public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
        public class OnProgressChangedEventArgs : EventArgs
        {
            public float progressNormalized;
        }

        public event EventHandler OnCut;
        
        [SerializeField] private myCuttingRecipeSO[] cuttingRecipeSOArray;

        private int cuttingProgress;
    
        public override void Interact(myPlayer player)
        {
            if (!HasKitchenObject())
            {
                // There is no KitchenObject here
                if (player.HasKitchenObject())
                {
                    // Player is carrying something
                    if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                    {
                        // Player carrying something that can be cut
                        player.GetKitchenObject().SetKitchenObjectParent(this);
                        cuttingProgress = 0;
                        
                        myCuttingRecipeSO cuttingRecipeSo = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                        OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                        {
                            progressNormalized = (float) cuttingProgress / cuttingRecipeSo.cuttingProgressMax
                        });
                    }
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
            if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
            {
                // There is a KitchenObject here AND it can be cut
                cuttingProgress++;
                
                OnCut?.Invoke(this, EventArgs.Empty);
                
                myCuttingRecipeSO cuttingRecipeSo = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                {
                    progressNormalized = (float) cuttingProgress / cuttingRecipeSo.cuttingProgressMax
                });
                
                if (cuttingProgress >= cuttingRecipeSo.cuttingProgressMax)
                {
                    myKitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
                
                    GetKitchenObject().DestroySelf();
                
                    myKitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
                }
            }
        }

        private bool HasRecipeWithInput(myKitchenObjectSO inputKitchenObjectSO)
        {
            myCuttingRecipeSO cuttingRecipeSo = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
            return cuttingRecipeSo != null;
        }

        private myKitchenObjectSO GetOutputForInput(myKitchenObjectSO inputKitchenObjectSO)
        {
            myCuttingRecipeSO cuttingRecipeSo = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
            if (cuttingRecipeSo != null)
            {
                return cuttingRecipeSo.output;
            }
            else
            {
                return null;
            }
        }

        private myCuttingRecipeSO GetCuttingRecipeSOWithInput(myKitchenObjectSO inputKitchenObjectSO)
        {
            foreach (myCuttingRecipeSO cuttingRecipeSo in cuttingRecipeSOArray)
            {
                if (cuttingRecipeSo.input == inputKitchenObjectSO)
                {
                    return cuttingRecipeSo;
                }
            }
            return null;
        }
        
    }
}
