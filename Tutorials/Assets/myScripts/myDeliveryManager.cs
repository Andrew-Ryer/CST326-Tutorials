using System;
using System.Collections.Generic;
using myScripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class myDeliveryManager : MonoBehaviour
{
    
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;

    public event EventHandler OnRecipeSuccess;
    public event EventHandler OnRecipeFailed;
    

    public static myDeliveryManager Instance { get; private set; }
    
    [SerializeField] private myRecipeListSO recipeListSO;
    
    
    private List<myRecipeSO> waitingRecipeSOList;
    
    private float spawnRecipeTImer;
    private float spawnRecipeTImerMax = 4f;
    private int waitingRecipeSOMax = 4;
    private int successfulRecipesAmount;

    private void Awake()
    {
        Instance = this;
        
        waitingRecipeSOList = new List<myRecipeSO>();
    }
    
    private void Update()
    {
        spawnRecipeTImer -= Time.deltaTime;
        if (spawnRecipeTImer <= 0f)
        {
            spawnRecipeTImer = spawnRecipeTImerMax;
            
            if (myKitchenGameManager.Instance.IsGamePlaying() && waitingRecipeSOList.Count < waitingRecipeSOMax){
                myRecipeSO waitingRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
                
                waitingRecipeSOList.Add(waitingRecipeSO);
                
                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void DeliverRecipe(myPlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingRecipeSOList.Count; i++)
        {
            myRecipeSO waitingRecipeSO = waitingRecipeSOList[i];

            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {
                // Has the same number of ingredients
                bool plateContentMatchesRecipe = true;
                foreach (myKitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    // Cycling through all ingredients in the recipe
                    bool ingredientsFound = false;
                    foreach (myKitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        // Cycling through all ingredients in the Plate
                        if (plateKitchenObjectSO == recipeKitchenObjectSO)
                        {
                            // Ingredient matches!
                            ingredientsFound = true;
                            break;
                        }
                    }

                    if (!ingredientsFound)
                    {
                        // This Recipe ingredient was not found on the Plate
                        plateContentMatchesRecipe = false;
                    }
                }

                if (plateContentMatchesRecipe)
                {
                    // Player delivered the correct recipe!
                    successfulRecipesAmount++;
                    
                    waitingRecipeSOList.RemoveAt(i);
                    
                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }
        
        // No matches found!
        // Player did not deliver the correct recipe
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);
        //Debug.Log("Player did not deliver the correct recipe");
    }

    public List<myRecipeSO> GetWaitingRecipeSOList()
    {
        return waitingRecipeSOList;
    }

    public int GetSuccessfulRecipesAmount()
    {
        return successfulRecipesAmount;
    }

}
