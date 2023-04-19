using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepSceneCamera : MonoBehaviour
{

    [Header("远景移动速率-纵轴")]
    public float Prospect_Moving_Speed_Y;

    [Header("远景移动速率-横轴")]
    public float Prospect_Moving_Speed_X;

    [Header("远景偏移-纵轴")]
    public float Prospect_Deviation_Y;

    [Header("远景偏移-横轴")]
    public float Prospect_Deviation_X;

    [Header("次远景移动速率-纵轴")]
    public float Second_Prospect_Moving_Speed_Y;

    [Header("次远景移动速率-横轴")]
    public float Second_Prospect_Moving_Speed_X;

    [Header("次远景偏移-纵轴")]
    public float Second_Prospect_Deviation_Y;

    [Header("次远景偏移-横轴")]
    public float Second_Prospect_Deviation_X;

    [Header("远景位置")]
    [SerializeField]
    Vector2 Prospect_Position;
    public Transform Prospect_Transform;

    [Header("次远景位置")]
    [SerializeField]
    Vector2 Second_Prospect_Position;
    public Transform Second_Prospect_Transform;


    [Header("相机位置")]
    [SerializeField]
    Vector2 Camera_Position;
    public Transform Camera_Transform;



    public void prospect_Following()     //远景跟随，其中尚有偏移参数需要调整
    {
        float X_Position = -Camera_Transform.position.x * Prospect_Moving_Speed_X / 100 + Prospect_Deviation_X + Camera_Transform.position.x;
        float Y_Positon = -Camera_Transform.position.y * Prospect_Moving_Speed_Y / 100 + Prospect_Deviation_Y + Camera_Transform.position.y;
        Prospect_Transform.position = new Vector3(X_Position, Y_Positon);
    }

    public void second_Prospect_Following()
    {
        float Second_X_Position = -Camera_Transform.position.x * Second_Prospect_Moving_Speed_X / 100 + Second_Prospect_Deviation_X + Camera_Transform.position.x;
        float Second_Y_Positon = -Camera_Transform.position.y * Second_Prospect_Moving_Speed_Y / 100 + Second_Prospect_Deviation_Y + Camera_Transform.position.y;
        Second_Prospect_Transform.position = new Vector3(Second_X_Position, Second_Y_Positon);
    }




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        prospect_Following();
        second_Prospect_Following();
    }
}
