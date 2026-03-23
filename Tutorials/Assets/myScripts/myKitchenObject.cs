using UnityEngine;

namespace myScripts
{
    public class myKitchenObject : MonoBehaviour
    {
        [SerializeField] private myKitchenObjectSO kitchenObjectSO;
    
        private ImyKitchenObjectParent kitchenObjectParent;
    
        public myKitchenObjectSO GetKitchenObjectSO()
        {
            return kitchenObjectSO;
        }

        public void SetKitchenObjectParent(ImyKitchenObjectParent kitchenObjectParent)
        {
            if (this.kitchenObjectParent != null)
            {
                this.kitchenObjectParent.ClearKitchenObject();
            }
        
            this.kitchenObjectParent = kitchenObjectParent;

            if (kitchenObjectParent.HasKitchenObject())
            {
                Debug.LogError("IKitchenObjectParent already has a KitchenObject!");
            }
            kitchenObjectParent.SetKitchenObject(this);
        
            transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
            transform.localPosition = Vector3.zero;
        }

        public ImyKitchenObjectParent GetKitchenObjectParent()
        {
            return kitchenObjectParent;
        }

        public void DestroySelf()
        {
            kitchenObjectParent.ClearKitchenObject();
            
            Destroy(gameObject);
        }

        public static myKitchenObject SpawnKitchenObject(myKitchenObjectSO kitchenObjectSO,
            ImyKitchenObjectParent kitchenObjectParent)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            
            myKitchenObject kitchenObject = kitchenObjectTransform.GetComponent<myKitchenObject>();
            
            kitchenObject.SetKitchenObjectParent(kitchenObjectParent);

            return kitchenObject;
        }
    }
}
