using myScripts;
using UnityEngine;

public class myPlayerSounds : MonoBehaviour
{
    private myPlayer player;
    private float footstepTimer;
    private float footstepTimerMax = .1f;


    private void Awake() {
        player = GetComponent<myPlayer>();
    }

    private void Update() {
        footstepTimer -= Time.deltaTime;
        if (footstepTimer < 0f) {
            footstepTimer = footstepTimerMax;

            if (player.IsWalking()) {
                float volume = 1f;
                mySoundManager.Instance.PlayFootstepsSound(player.transform.position, volume);
            }
        }
    }
}
