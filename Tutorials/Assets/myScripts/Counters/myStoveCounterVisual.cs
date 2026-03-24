using UnityEngine;

public class myStoveCounterVisual : MonoBehaviour
{

    [SerializeField] private myStoveCounter stoverCounter;
    [SerializeField] private GameObject stoveOnGameObject;
    [SerializeField] private GameObject particlesGameObject;

    private void Start()
    {
        stoverCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, myStoveCounter.OnStateChangedEventArgs e)
    {
        bool showVisual = e.state == myStoveCounter.State.Frying || e.state == myStoveCounter.State.Fried;
        stoveOnGameObject.SetActive(showVisual);
        particlesGameObject.SetActive(showVisual);
    }
    
}
