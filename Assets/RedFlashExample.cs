using UnityEngine;

/// <summary>
/// 这是幕红色闪烁示范用的类, 了解用法后可以放心删除
/// </summary>
public class RedFlashExample : MonoBehaviour
{
    public float 测试闪烁间隔 = 2;
    float timer;

    void Start()
    {
        //这两个参数可以但不必须手动设置, 这里只是展示API+展示默认值
        //RedFlash.Color = Color.red;
        //RedFlash.fallRate = 4;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 测试闪烁间隔)
        {
            timer = 0;
            //触发屏幕红色闪烁
            RedFlash.Flash();
        }
    }
}
