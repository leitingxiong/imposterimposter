using UnityEngine;

//不要手动挂到GameObject上, 需要时直接调用静态方法Flash就行
public class RedFlash : MonoBehaviour
{
    #region 静态API
    /// <summary>
    /// 设置或获取闪烁时的颜色, 默认为纯红色
    /// </summary>
    public static Color Color
    {
        get => Instance.mat.GetColor("_Color");
        set => Instance.mat.SetColor("_Color", value);
    }

    /// <summary>
    /// 当前的强度, 随着时间自动衰减
    /// </summary>
    public static float CurrIntensity
    {
        get => Instance.currIntensity;
        set => Instance.currIntensity = value;
    }

    /// <summary>
    /// 衰减率, 值越高衰减越快
    /// </summary>
    public static float FallRate
    {
        get => Instance.fallRate;
        set => Instance.fallRate = value;
    }

    /// <summary>
    /// 触发红色闪烁. 可选是否指定单次闪烁的强度
    /// </summary>
    public static void Flash(float intensity = 0.5f) => CurrIntensity = intensity;
    #endregion

    //单例
    static RedFlash Instance 
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RedFlash>();
                if (instance == null)
                    instance = new GameObject("(自动创建)渲染用红闪单例").AddComponent<RedFlash>();
            }
            return instance;
        }
    }
    static RedFlash instance;

    #region 封装的单例成员
    float currIntensity;
    float fallRate = 4;
    Material mat;//材质

    void Awake()
    {
        Mesh quadMesh = new()
        {
            name = "四个顶点俩三角形的网格",
            vertices = new Vector3[4],
            bounds = new(default, Vector3.one * float.MaxValue)
        };
        quadMesh.SetIndices(new ushort[] { 0, 2, 3, 0, 3, 1 }, MeshTopology.Triangles, 0, false);
        gameObject.AddComponent<MeshFilter>().mesh = quadMesh;
        gameObject.AddComponent<MeshRenderer>().sharedMaterial = mat = new(Shader.Find("RedFlashShader"));
    }

    void Update()
    {
        mat.SetFloat("_Intensity", currIntensity);
        currIntensity -= currIntensity * fallRate * Time.deltaTime;
    }
    #endregion
}
