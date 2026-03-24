using System;
using System.Collections.Generic;
using myScripts;
using UnityEngine;

public class myPlateKitchenObject : myKitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public myKitchenObjectSO KitchenObjectSO;
    }
    
    
    [SerializeField] private List<myKitchenObjectSO> validKitchenObjectSO;

    private List<myKitchenObjectSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<myKitchenObjectSO>();
    }

    public bool TryAddIngredient(myKitchenObjectSO KitchenObjectSO)
    {
        if (!validKitchenObjectSO.Contains(KitchenObjectSO))
        {
            // Not a valid ingredient
            return false;
        }
        if (kitchenObjectSOList.Contains(KitchenObjectSO))
        {
            // Already has this type
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(KitchenObjectSO);

            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
            {
                KitchenObjectSO =  KitchenObjectSO
            });
            
            return true;
        }
    }

    public List<myKitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
