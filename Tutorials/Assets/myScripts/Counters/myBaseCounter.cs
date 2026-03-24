using UnityEngine;
namespace myScripts
{
    public class myBaseCounter : MonoBehaviour, ImyKitchenObjectParent
    {
        
        [SerializeField] private Transform counterTopPoint;
    
        private myKitchenObject kitchenObject;
        
        public virtual void Interact(myPlayer player)
        {
            Debug.LogError("BaseCounter.Interact();");
        }
        
        public virtual void InteractAlternate(myPlayer player)
        {
            //Debug.LogError("BaseCounter.InteractAlternate();");
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

        public virtual void QueryTriggerInteraction(myPlayer player)
        {
            throw new System.NotImplementedException();
        }
    }
}
