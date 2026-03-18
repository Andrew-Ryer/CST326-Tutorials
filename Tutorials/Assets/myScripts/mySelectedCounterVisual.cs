using UnityEngine;

public class mySelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private myClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;
    
    private void Start()
    {
        myPlayer.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, myPlayer.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        visualGameObject.SetActive(true);
    }

    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
