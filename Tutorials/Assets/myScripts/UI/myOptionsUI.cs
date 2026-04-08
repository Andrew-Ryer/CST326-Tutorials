using System;
using myScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class myOptionsUI : MonoBehaviour
{
    public static myOptionsUI Instance { get; private set; }


    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button gamepadInteractButton;
    [SerializeField] private Button gamepadInteractAlternateButton;
    [SerializeField] private Button gamepadPauseButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI interactAlternateText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private TextMeshProUGUI gamepadInteractText;
    [SerializeField] private TextMeshProUGUI gamepadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI gamepadPauseText;
    [SerializeField] private Transform pressToRebindKeyTransform;


    private Action onCloseButtonAction;


    private void Awake()
    {
        Instance = this;

        soundEffectsButton.onClick.AddListener(() =>
        {
            mySoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        musicButton.onClick.AddListener(() =>
        {
            myMusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
            onCloseButtonAction();
        });

        moveUpButton.onClick.AddListener(() => { RebindBinding(myGameInput.Binding.Move_Up); });
        moveDownButton.onClick.AddListener(() => { RebindBinding(myGameInput.Binding.Move_Down); });
        moveLeftButton.onClick.AddListener(() => { RebindBinding(myGameInput.Binding.Move_Left); });
        moveRightButton.onClick.AddListener(() => { RebindBinding(myGameInput.Binding.Move_Right); });
        interactButton.onClick.AddListener(() => { RebindBinding(myGameInput.Binding.Interact); });
        interactAlternateButton.onClick.AddListener(() => { RebindBinding(myGameInput.Binding.InteractAlternate); });
        pauseButton.onClick.AddListener(() => { RebindBinding(myGameInput.Binding.Pause); });
        gamepadInteractButton.onClick.AddListener(() => { RebindBinding(myGameInput.Binding.Gamepad_Interact); });
        gamepadInteractAlternateButton.onClick.AddListener(() =>
        {
            RebindBinding(myGameInput.Binding.Gamepad_InteractAlternate);
        });
        gamepadPauseButton.onClick.AddListener(() => { RebindBinding(myGameInput.Binding.Gamepad_Pause); });
    }

    private void Start()
    {
        myKitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;

        UpdateVisual();

        HidePressToRebindKey();
        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectsText.text = "Sound Effects: " + Mathf.Round(mySoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(myMusicManager.Instance.GetVolume() * 10f);

        moveUpText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Move_Up);
        moveDownText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Move_Down);
        moveLeftText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Move_Left);
        moveRightText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Move_Right);
        interactText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Interact);
        interactAlternateText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.InteractAlternate);
        pauseText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Pause);
        gamepadInteractText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Gamepad_Interact);
        gamepadInteractAlternateText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Gamepad_InteractAlternate);
        gamepadPauseText.text = myGameInput.Instance.GetBindingText(myGameInput.Binding.Gamepad_Pause);
    }

    public void Show(Action onCloseButtonAction)
    {
        this.onCloseButtonAction = onCloseButtonAction;

        gameObject.SetActive(true);

        soundEffectsButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ShowPressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }

    private void HidePressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }

    private void RebindBinding(myGameInput.Binding binding)
    {
        ShowPressToRebindKey();
        myGameInput.Instance.RebindBinding(binding, () =>
        {
            HidePressToRebindKey();
            UpdateVisual();
        });
    }
}