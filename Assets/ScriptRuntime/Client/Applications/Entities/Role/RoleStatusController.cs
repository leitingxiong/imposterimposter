using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleStatusController : MonoBehaviour
{
    public Animator animator;



    public void Set_Injured()
    {
        animator.SetTrigger("Injured");
    }

    public void Set_Die()
    {
        animator.SetTrigger("Die");
    }

    public void Set_PropInteraction()
    {
        animator.SetTrigger("PropInteraction");
    }

    public void Set_SceneInteraction()
    {
        animator.SetTrigger("SceneInteraction");
    }

    /// <summary>
    /// 落地时调用
    /// </summary>
    public void Set_OnGround()
    {
        animator.SetBool("OnGround", true);
        animator.SetBool("Jumping", false);
    }

    //攀爬调用
    public void Set_Climbing()
    {
        animator.SetBool("Climbing", true);
    }

    /// <summary>
    /// 下蹲时调用
    /// </summary>
    public void Set_Crouch()
    {
        animator.SetBool("Crouch", true);
    }

    /// <summary>
    /// 开始移动 
    /// </summary>
    public void Set_Moving()
    {
        animator.SetBool("Moving", true);
    }

    /// <summary>
    /// 开始跳跃 
    /// </summary>
    public void Set_Jump()
    {
        animator.SetBool("Jumping", true);
    }

    /// <summary>
    /// 开始奔跑 
    /// </summary>
    public void Set_Shift()
    {
        animator.SetBool("Shift", true);
    }

    /// <summary>
    /// 开始警告 
    /// </summary>
    public void Set_Warning()
    {
        animator.SetBool("Warning", true);
    }

    /// <summary>
    /// 开始暴露 
    /// </summary>
    public void Set_Visiable()
    {
        animator.SetBool("Visiable", true);
    }

    public void Unset_Warning()
    {
        animator.SetBool("Warning", false);
    }

    public void Unset_Visiable()
    {
        animator.SetBool("Visiable", false);
    }





    /// <summary>
    /// 离开地面时调用
    /// </summary>
    public void Unset_OnGround()
    {
        animator.SetBool("OnGround", false);
    }

    /// <summary>
    /// 取消攀爬时调用
    /// </summary>
    public void Unset_Climbing()
    {
        animator.SetBool("Climbing", false);
    }


    /// <summary>
    /// 起身时调用
    /// </summary>
    public void Unset_Crouch()
    {
        animator.SetBool("Crouch", false);
    }

    /// <summary>
    /// 停止移动
    /// </summary>
    public void Unset_Moving()
    {
        animator.SetBool("Moving", false);
    }

    /// <summary>
    /// 开始跳跃 
    /// </summary>s
    public void Unset_Jump()
    {
        animator.SetBool("Jumping", false);
    }

    public void Unset_Shift()
    {
        animator.SetBool("Shift", false);
    }

}
