using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportEntity : MonoBehaviour
{
    float max_volumevalue;
    public AudioSource audioSource;

    private RoleEntity roleEntity;

    private RoleStatusController roleStatus;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out roleEntity))
        {
            roleStatus = collision.GetComponent<RoleStatusController>();
            roleStatus.Set_SceneInteraction();
            // roleEntity.export();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out roleEntity))
        {
        }
    }

    /// <summary>
    /// 将音量大小赋给音源
    /// </summary>
    /// <param name="maxvolume"></param>
    public void GetMaxVolumeValue(float maxvolume)
    {
        max_volumevalue = maxvolume;
        audioSource.volume = max_volumevalue;
    }

}
