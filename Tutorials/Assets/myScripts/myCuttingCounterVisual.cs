using System;
using myScripts;
using UnityEngine;

public class myCuttingCounterVisual : MonoBehaviour
{
    private const string CUT = "Cut";
    
    [SerializeField] private myCuttingCounter cuttingCounter;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        animator.SetTrigger(CUT);
    }
}
