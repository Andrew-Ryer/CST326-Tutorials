using myScripts;
using UnityEngine;
using TMPro;

public class myTutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUpText;
    [SerializeField] private TextMeshProUGUI keyMoveDownText;
    [SerializeField] private TextMeshProUGUI keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI keyMoveRightText;
    [SerializeField] private TextMeshProUGUI keyInteractText;
    [SerializeField] private TextMeshProUGUI keyInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyPauseText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyGamepadPauseText;


    private void Start() {
        myGameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        myKitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        UpdateVisual();

        Show();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (myKitchenGameManager.Instance.IsCountdownToStartActive()) {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e) {
        UpdateVisual();
    }

    private void UpdateVisual() {
        keyMoveUpText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Move_Up);
        keyMoveDownText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Move_Down);
        keyMoveLeftText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Move_Left);
        keyMoveRightText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Move_Right);
        keyInteractText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Interact);
        keyInteractAlternateText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.InteractAlternate);
        keyPauseText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Pause);
        keyGamepadInteractText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Gamepad_Interact);
        keyGamepadInteractAlternateText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Gamepad_InteractAlternate);
        keyGamepadPauseText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Gamepad_Pause);
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }
}