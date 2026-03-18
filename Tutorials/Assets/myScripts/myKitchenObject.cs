using UnityEngine;

public class myKitchenObject : MonoBehaviour
{
    [SerializeField] private myKitchenObjectSO kitchenObjectSO;
    
    private myClearCounter clearCounter;
    
    public myKitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(myClearCounter clearCounter)
    {
        if (this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();
        }
        
        this.clearCounter = clearCounter;

        if (clearCounter.HasKitchenObject())
        {
            Debug.LogError("Counter already has a KitchenObject!");
        }
        clearCounter.SetKitchenObject(this);
        
        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public myClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
