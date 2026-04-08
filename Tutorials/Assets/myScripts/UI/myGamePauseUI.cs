using UnityEngine;
using UnityEngine.UI;

public class myGamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionsButton;


    private void Awake() {
        resumeButton.onClick.AddListener(() => {
            myKitchenGameManager.Instance.TogglePauseGame();
        });
        mainMenuButton.onClick.AddListener(() => {
            myLoader.Load(myLoader.Scene.myMainMenuScene);
        });
        optionsButton.onClick.AddListener(() => {
            Hide();
            myOptionsUI.Instance.Show(Show);
        });
    }

    private void Start() {
        myKitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnGamePaused;
        myKitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;

        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e) {
        Hide();
    }

    private void KitchenGameManager_OnGamePaused(object sender, System.EventArgs e) {
        Show();
    }

    private void Show() {
        gameObject.SetActive(true);

        resumeButton.Select();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}