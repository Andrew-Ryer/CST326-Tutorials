using UnityEngine;

namespace myScripts
{
    public interface ImyKitchenObjectParent
    {
        public Transform GetKitchenObjectFollowTransform();

        public void SetKitchenObject(myKitchenObject kitchenObject);

        public myKitchenObject GetKitchenObject();

        public void ClearKitchenObject();

        public bool HasKitchenObject();
    
    }
}
