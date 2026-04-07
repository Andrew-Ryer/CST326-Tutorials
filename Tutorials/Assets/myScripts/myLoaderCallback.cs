using UnityEngine;

public class myLoaderCallback : MonoBehaviour
{
    private bool isFirstUpdate = true;

    private void Update() {
        if (isFirstUpdate) {
            isFirstUpdate = false;

            myLoader.LoaderCallback();
        }
    }
}
