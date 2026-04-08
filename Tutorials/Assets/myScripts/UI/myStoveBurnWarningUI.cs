using UnityEngine;

public class myStoveBurnWarningUI : MonoBehaviour
{
    [SerializeField] private myStoveCounter stoveCounter;



    private void Start() {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;

        Hide();
    }

    private void StoveCounter_OnProgressChanged(object sender, ImyHasProgress.OnProgressChangedEventArgs e) {
        float burnShowProgressAmount = .5f;
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;

        if (show) {
            Show();
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
