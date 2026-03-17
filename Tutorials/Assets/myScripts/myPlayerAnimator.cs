using System;
using UnityEngine;

public class myPlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    [SerializeField] private myPlayer player;
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
