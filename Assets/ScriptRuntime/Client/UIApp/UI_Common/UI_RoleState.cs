using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RoleState : MonoBehaviour
{
    public Image health;
    public Image oxygen;
    private RoleEntity roleEntity;
    void Start()
    {
        roleEntity = FindObjectOfType<RoleEntity>();
    }

    // Update is called once per frame
    void Update()
    {
        oxygen.fillAmount = roleEntity.oxygen / roleEntity.maxOxygen;
        health.fillAmount = roleEntity.HP / 2;//2是否应该写在roleentity里，最大值？
    }
}
