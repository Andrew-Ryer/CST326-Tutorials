using UnityEngine;
using UnityEngine.UI;


public class myGamePlayingClockUI : MonoBehaviour
{
    [SerializeField] private Image timerImage;


    private void Update() {
        timerImage.fillAmount = myKitchenGameManager.Instance.GetGamePlayingTimerNormalized();
    }
}
