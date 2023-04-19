using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;   // 人物Transform组件
    public float smoothSpeed = 0.125f;  // 相机跟随速度

    void LateUpdate()
    {
        // 计算相机的目标位置
        Vector3 desiredPosition = target.position + new Vector3(20,20,0);
        desiredPosition.z = transform.position.z;

        // 使用SmoothDamp函数实现相机跟随
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}

