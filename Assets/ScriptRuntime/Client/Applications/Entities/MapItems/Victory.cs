using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Victory : MonoBehaviour
{
    public int fightNumber;
    public RoleEntity roleEntity;
    private void OnTriggerEnter2D(Collider2D role)
    {
        if (role.TryGetComponent(out roleEntity))
        {
            SceneManager.LoadScene(fightNumber);
            roleEntity.HP = 3;
        }
    }


}
