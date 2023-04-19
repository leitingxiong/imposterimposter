using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class SunEntity : MonoBehaviour
{
    public RoleEntity roleEntity;
    private void OnTriggerEnter2D(Collider2D role)
    {
        if (role.TryGetComponent(out roleEntity))
        {
            roleEntity.VisibleRole();
        }
    }

    private void OnTriggerExit2D(Collider2D role)
    {
        if (role.TryGetComponent(out roleEntity))
        {
            roleEntity.HideRole();
        }
    }
}
