using myScripts;
using UnityEngine;

public class mySoundManager : MonoBehaviour
{
    private const string PLAYER_PREFS_SOUND_EFFECTS_VOLUME = "SoundEffectsVolume";
    
    public static mySoundManager Instance { get; private set; }

    [SerializeField] private myAudioClipRefsSO audioClipRefsSO;


    private float volume = 1f;


    private void Awake() {
        Instance = this;

        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, 1f);
    }

    private void Start() {
        myDeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        myDeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        myCuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        myPlayer.Instance.OnPickedSomething += Player_OnPickedSomething;
        myBaseCounter.OnAnyObjectPlacedHere += BaseCounter_OnAnyObjectPlacedHere;
        myTrashCounter.OnAnyObjectTrashed += TrashCounter_OnAnyObjectTrashed;
    }

    private void TrashCounter_OnAnyObjectTrashed(object sender, System.EventArgs e) {
        myTrashCounter trashCounter = sender as myTrashCounter;
        PlaySound(audioClipRefsSO.trash, trashCounter.transform.position);
    }
    
    private void BaseCounter_OnAnyObjectPlacedHere(object sender, System.EventArgs e) {
        myBaseCounter baseCounter = sender as myBaseCounter;
        PlaySound(audioClipRefsSO.objectDrop, baseCounter.transform.position);
    }
    
    private void Player_OnPickedSomething(object sender, System.EventArgs e) {
        PlaySound(audioClipRefsSO.objectPickup, myPlayer.Instance.transform.position);
    }
    
    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e) {
        myCuttingCounter cuttingCounter = sender as myCuttingCounter;
        PlaySound(audioClipRefsSO.chop, cuttingCounter.transform.position);
    }

    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e) {
        myDeliveryCounter deliveryCounter = myDeliveryCounter.Instance;
        PlaySound(audioClipRefsSO.deliveryFail, deliveryCounter.transform.position);
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e) {
        myDeliveryCounter deliveryCounter = myDeliveryCounter.Instance;
        PlaySound(audioClipRefsSO.deliverySuccess, deliveryCounter.transform.position);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f) {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f) {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * volume);
    }

    public void PlayFootstepsSound(Vector3 position, float volume) {
        PlaySound(audioClipRefsSO.footstep, position, volume);
    }
    
    // public void PlayCountdownSound() {
    //     PlaySound(audioClipRefsSO.warning, Vector3.zero);
    // }
    //
    // public void PlayWarningSound(Vector3 position) {
    //     PlaySound(audioClipRefsSO.warning, position);
    // }

    // public void ChangeVolume() {
    //     volume += .1f;
    //     if (volume > 1f) {
    //         volume = 0f;
    //     }
    //
    //     PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, volume);
    //     PlayerPrefs.Save();
    // }
    //
    // public float GetVolume() {
    //     return volume;
    // }


}
