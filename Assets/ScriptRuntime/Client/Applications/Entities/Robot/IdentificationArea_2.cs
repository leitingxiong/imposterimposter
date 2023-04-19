using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentificationArea_2 : MonoBehaviour
{
    public UseMicrophone useMicrophone;

    private RoleEntity roleEntity;

    /// <summary>
    /// 警戒识别
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out roleEntity) && collision.TryGetComponent(out useMicrophone))
        {
            useMicrophone.SetWarning();
        }
    }

    /// <summary>
    /// 放松警戒
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out roleEntity) && collision.TryGetComponent(out useMicrophone))
        {
            useMicrophone.StopWarning();
        }
    }

}
