using UnityEngine;
using UnityEngine.SceneManagement;

public static class myLoader {


    public enum Scene {
        myMainMenuScene,
        myGameScene,
        myLoadingScene
    }


    private static Scene targetScene;


    public static void Load(Scene targetScene) {
        myLoader.targetScene = targetScene;
        
        SceneManager.LoadScene(Scene.myLoadingScene.ToString());
    }
    

    public static void LoaderCallback() {
        SceneManager.LoadScene(targetScene.ToString());
    }

}
