using myScripts;
using UnityEngine;
using UnityEngine.UI;

public class myPlateIconsSingleUI : MonoBehaviour
{

    [SerializeField] private Image image;

    public void SetKitchenObjectSO(myKitchenObjectSO kitchenObjectSO)
    {
        image.sprite = kitchenObjectSO.sprite;
    }
}
