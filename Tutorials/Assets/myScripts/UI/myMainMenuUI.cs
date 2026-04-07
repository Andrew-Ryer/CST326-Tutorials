using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class myMainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;


    private void Awake() {
        playButton.onClick.AddListener(() => {
            myLoader.Load(myLoader.Scene.myGameScene);
        });
        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });

        Time.timeScale = 1f;
    }
}
