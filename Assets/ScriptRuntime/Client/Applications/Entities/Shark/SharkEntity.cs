using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkEntity : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 1;
    public RoleEntity roleEntity;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out roleEntity))
        {
            roleEntity.HP -= damage;
            roleEntity.roleStatus.Set_Injured();
            RedFlash.Flash(0.2f);
            if (roleEntity.roleAudioSource.isPlaying == true) { roleEntity.roleAudioSource.Stop(); }
            roleEntity.roleAudioSource.clip = roleEntity.roleMusic[5];
            roleEntity.roleAudioSource.Play();
            Debug.Log("HP-1");
        }
    }
}
