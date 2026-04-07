using TMPro;
using UnityEngine;

public class myGameStartCountdownUI : MonoBehaviour
{
    private const string NUMBER_POPUP = "NumberPopup";


    [SerializeField] private TextMeshProUGUI countdownText;


    private Animator animator;
    private int previousCountdownNumber;

    
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        myKitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (myKitchenGameManager.Instance.IsCountdownToStartActive()) {
            Show();
        } else {
            Hide();
        }
    }

    private void Update() {
        int countdownNumber = Mathf.CeilToInt(myKitchenGameManager.Instance.GetCountdownToStartTimer());
        countdownText.text = countdownNumber.ToString();

        if (previousCountdownNumber != countdownNumber) {
            previousCountdownNumber = countdownNumber;
            animator.SetTrigger(NUMBER_POPUP);
            //mySoundManager.Instance.PlayCountdownSound();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}