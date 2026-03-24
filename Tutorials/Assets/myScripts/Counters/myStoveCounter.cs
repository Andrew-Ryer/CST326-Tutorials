using System;
using myScripts;
using UnityEngine;

public class myStoveCounter : myBaseCounter, ImyHasProgress
{
    public event EventHandler<ImyHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;

    public class OnStateChangedEventArgs : EventArgs
    {
        public State state;
    }

    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burned,
    }
    
    [SerializeField] private myFryingRecipeSO[] fryingRecipeSOArray;
    [SerializeField] private myBurningRecipeSO[] burningRecipeSOArray;


    private State state;
    private float fryingTimer;
    private myFryingRecipeSO fryingRecipeSO;
    private float burningTimer;
    private myBurningRecipeSO burningRecipeSO;

    private void Start()
    {
        state = State.Idle;
    }
    
    private void Update()
    {
        if (HasKitchenObject())
        {
            switch (state)
            {
                case State.Idle:
                    break;
                case State.Frying: 
                    fryingTimer += Time.deltaTime; 
                    
                    OnProgressChanged?.Invoke(this, new ImyHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = fryingTimer / fryingRecipeSO.fryingTimerMax
                    });
                    
                    if (fryingTimer > fryingRecipeSO.fryingTimerMax) 
                    { 
                        // Fried
                        GetKitchenObject().DestroySelf();
                        
                        myKitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this); 
                        
                        state = State.Fried;
                        burningTimer = 0f;
                        burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = state
                        });
                    }
                    break;
                case State.Fried: 
                    burningTimer += Time.deltaTime; 
                    
                    OnProgressChanged?.Invoke(this, new ImyHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = burningTimer / burningRecipeSO.burningTimerMax
                    });
                    
                    if (burningTimer > burningRecipeSO.burningTimerMax) 
                    { 
                        // Fried
                        GetKitchenObject().DestroySelf();
                        
                        myKitchenObject.SpawnKitchenObject(burningRecipeSO.output, this); 
                        
                        state = State.Burned;
                        
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = state
                        });
                        
                        OnProgressChanged?.Invoke(this, new ImyHasProgress.OnProgressChangedEventArgs
                        {
                            progressNormalized = 0f
                        });
                    }
                    break;
                case State.Burned: 
                    break;
            }
        }
    }

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
                    // Player carrying something that can be fried
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    
                    fryingRecipeSO = GetfryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    
                    state = State.Frying;
                    fryingTimer = 0f;
                    
                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        state = state
                    });
                    
                    OnProgressChanged?.Invoke(this, new ImyHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = fryingTimer / fryingRecipeSO.fryingTimerMax
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
                if (player.GetKitchenObject().TryGetPlate(out myPlateKitchenObject plateKitchenObject))
                {
                    // Player is holding a Plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                        
                        state = State.Idle;
                
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = state
                        });
                
                        OnProgressChanged?.Invoke(this, new ImyHasProgress.OnProgressChangedEventArgs
                        {
                            progressNormalized = 0f
                        });
                    }
                }
            }
            else
            {
                // Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
                
                state = State.Idle;
                
                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                {
                    state = state
                });
                
                OnProgressChanged?.Invoke(this, new ImyHasProgress.OnProgressChangedEventArgs
                {
                    progressNormalized = 0f
                });
            }
        }
    }
    
    private bool HasRecipeWithInput(myKitchenObjectSO inputKitchenObjectSO)
    {
        myFryingRecipeSO fryingRecipeSo = GetfryingRecipeSOWithInput(inputKitchenObjectSO);
        return fryingRecipeSo != null;
    }

    private myKitchenObjectSO GetOutputForInput(myKitchenObjectSO inputKitchenObjectSO)
    {
        myFryingRecipeSO fryingRecipeSo = GetfryingRecipeSOWithInput(inputKitchenObjectSO);
        if (fryingRecipeSo != null)
        {
            return fryingRecipeSo.output;
        }
        else
        {
            return null;
        }
    }

    private myFryingRecipeSO GetfryingRecipeSOWithInput(myKitchenObjectSO inputKitchenObjectSO)
    {
        foreach (myFryingRecipeSO fryingRecipeSo in fryingRecipeSOArray)
        {
            if (fryingRecipeSo.input == inputKitchenObjectSO)
            {
                return fryingRecipeSo;
            }
        }
        return null;
    }
    
    private myBurningRecipeSO GetBurningRecipeSOWithInput(myKitchenObjectSO inputKitchenObjectSO)
    {
        foreach (myBurningRecipeSO burningRecipeSO in burningRecipeSOArray)
        {
            if (burningRecipeSO.input == inputKitchenObjectSO)
            {
                return burningRecipeSO;
            }
        }
        return null;
    }
}
