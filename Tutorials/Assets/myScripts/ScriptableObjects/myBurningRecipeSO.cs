using myScripts;
using UnityEngine;

[CreateAssetMenu()]
public class myBurningRecipeSO : ScriptableObject
{

    public myKitchenObjectSO input;
    public myKitchenObjectSO output;
    public float burningTimerMax;
}
