using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 语音识别音频可视化
/// </summary>
public class UseMicrophone : MonoBehaviour
{
    // public GameObject[] obj;
    public bool warning = false;
    public static float volume;
    private AudioClip micRecord;

    public ExportEntity exportEntity;
    string device;
    public RobotEntity robotEntity;
    void Start()
    {
        robotEntity = FindObjectOfType<RobotEntity>();

        device = Microphone.devices[0];//获取设备麦克风
        micRecord = Microphone.Start(device, true, 999, 44100);//44100音频采样率   固定格式
    }
    private void FixedUpdate()
    {
        volume = GetMaxVolume();
        // if (Input.GetKey(KeyCode.Escape))
        // {
        //     Application.Quit();
        // }
        if (TryGetComponent(out robotEntity))
        {
            if (warning == true)
            {
                robotEntity.AddWarning(volume);
                // Debug.Log(volume);
            }
            else
            {
                if (robotEntity.robotFSM == RobotEntity.RobotFSM.Warning) robotEntity.ReduceWarningValue();
            }
        }

    }
    public void SetWarning()
    {
        warning = true;
    }

    public void StopWarning()
    {
        warning = false;
    }

    /// <summary>
    /// 每一振处理那一帧接收的音频文件
    /// </summary>
    /// <returns></returns>
    public float GetMaxVolume()
    {
        float maxVolume = 0f;
        //剪切音频
        float[] volumeData = new float[128];
        int offset = Microphone.GetPosition(device) - 128 + 1;
        if (offset < 0)
        {
            return 0;
        }
        micRecord.GetData(volumeData, offset);
        maxVolume = Mathf.Max(volumeData);

        return maxVolume * 20;
    }
}