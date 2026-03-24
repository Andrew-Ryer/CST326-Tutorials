using myScripts;
using UnityEngine;

[CreateAssetMenu()]
public class myFryingRecipeSO : ScriptableObject
{

    public myKitchenObjectSO input;
    public myKitchenObjectSO output;
    public float fryingTimerMax;
}
