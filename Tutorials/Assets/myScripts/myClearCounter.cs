using UnityEngine;

public class myClearCounter : MonoBehaviour
{
    [SerializeField] private myKitchenObjectSO kitchenObjectSo;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private myClearCounter secondClearCounter;
    [SerializeField] private bool testing;
    
    private myKitchenObject kitchenObject;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetClearCounter(secondClearCounter);
            }
        }
    }
    
    public void Interact()
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<myKitchenObject>().SetClearCounter(this);
        }
        else
        {
            Debug.Log(kitchenObject.GetClearCounter());
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(myKitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public myKitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
