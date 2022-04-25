using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    // Start is called before the first frame update
    public enum StatePlayer { Idle, Move, Jump, Attack, Die};
    public float velocity;
    public bool isProcessing;
    public StatePlayer state { get; set; }


    public Animator animator;
    
    void Start()
    {
        state = StatePlayer.Idle;
    }
    // Update is called once per frame
    void Update()
    {
        HandleState();
    }
    private void HandleState() {
        if(state == StatePlayer.Move)
        {
            animator.SetBool("IsMoving", true);
            animator.SetBool("IsAttack", false);
        }
            
        else if(state == StatePlayer.Attack)
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsAttack", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsAttack", false);
            animator.Play("Idle");
        }
    }

}
