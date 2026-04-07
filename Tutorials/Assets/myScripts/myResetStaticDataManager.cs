using myScripts;
using UnityEngine;

public class myResetStaticDataManager : MonoBehaviour
{
    private void Awake() {
        myCuttingCounter.ResetStaticData();
        myBaseCounter.ResetStaticData();
        myTrashCounter.ResetStaticData();
    }
}
