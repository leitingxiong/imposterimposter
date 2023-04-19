using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStatusController : MonoBehaviour
{
    public Animator animator;


    public void Set_Warning()
    {
        animator.SetBool("Warning", true);
    }

    public void UnSet_Warning()
    {
        animator.SetBool("Warning", false);
    }


    public void Set_Patorl()
    {
        animator.SetBool("Patorl", true);
    }

    public void UnSet_Patorl()
    {
        animator.SetBool("Patorl", false);
    }


    public void Set_Attack()
    {
        animator.SetTrigger("Attack");
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
