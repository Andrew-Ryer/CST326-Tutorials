using myScripts;
using UnityEngine;

[CreateAssetMenu()]
public class myCuttingRecipeSO : ScriptableObject
{

    public myKitchenObjectSO input;
    public myKitchenObjectSO output;
    public int cuttingProgressMax;
}
