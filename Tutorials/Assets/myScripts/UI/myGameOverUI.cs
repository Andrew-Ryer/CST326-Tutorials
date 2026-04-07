using UnityEngine;
using TMPro;

public class myGameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliveredText;


    private void Start() {
        myKitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (myKitchenGameManager.Instance.IsGameOver()) {
            Show();

            recipesDeliveredText.text = myDeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
        } else {
            Hide();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }
}
