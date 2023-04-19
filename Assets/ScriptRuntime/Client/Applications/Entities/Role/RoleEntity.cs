using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class RoleEntity : MonoBehaviour
{

    Light2D avatarLight; //对这个灯光设置pointLightOuterRadius属性就行了

    public bool isHide = false;
    // public RoleStatusController roleStatus;
    private Rigidbody2D roleRb;
    private Animator roleAnim;
    public Animator volumeAnim;
    private LightEntity lightEntity;
    private Transform roleTransform;
    private ExportEntity exportEntity;
    private UseMicrophone useMicrophone;
    public AudioClip[] roleMusic;
    public AudioSource roleAudioSource;
    public float jumpForce = 30f;
    [SerializeField] private float groundCheckDistance = 7f;
    [SerializeField] private LayerMask groundLayer;
    RaycastHit2D hit;

    public Image hpImage;
    public Image oxygenImage;
    public Rigidbody2D rb;
    private bool isGrounded;
    public GameObject light;

    public GameObject pauseMenu;

    public float speed;
    [Tooltip("氧气值")]
    [SerializeField]
    public float oxygen ;
    public float maxOxygen = 180;
    private float t = 1f;

    public RoleStatusController roleStatus;
    public RoleStatusController volumeStatus;
    public float HP = 3;

    public float playerPositon_Y;
    public enum Climbing
    {
        Out = 1,
        Up = 2,
        Down = 3,
    }
    public Climbing climbing = Climbing.Out;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
        groundLayer = LayerMask.GetMask(LayerMask.LayerToName(6));
        if (!TryGetComponent(out roleTransform)) ;
        if (!TryGetComponent(out useMicrophone))
            Debug.LogError(gameObject.name + "没有麦克风啊！");
        if (!TryGetComponent(out roleStatus))
            Debug.LogError(gameObject.name + "没附加角色的动画");
        if (!TryGetComponent(out roleAnim))
            Debug.LogError(gameObject.name + "没附加Animator!");
        if (!TryGetComponent(out roleAudioSource))
            Debug.LogError("没有音乐");
        if (transform.Find("音量UI动画/音量UI").TryGetComponent(out volumeAnim)) ;
        if (transform.Find("音量UI动画/音量UI").TryGetComponent(out volumeStatus)) ;


    }

    void Update()
    {
        UIRoleState();
        UIVolume(useMicrophone.GetMaxVolume());
        this.speed = 3f;
        roleStatus.Unset_Shift();
        roleStatus.Unset_Moving();
        roleAudioSource.loop = false;
        Vector3 offset = Vector3.zero;
        if (isDead())
        {
            Destroy(gameObject);
            roleStatus.Set_Die();
            if (roleAudioSource.isPlaying == true) { roleAudioSource.Stop(); }
            roleAudioSource.clip = roleMusic[6];
            roleAudioSource.Play();
            TogglePause();
        }
        //人物按键效果

        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            this.speed = 15f;
            this.oxygen -= Time.deltaTime * 2;
            volumeStatus.Set_Warning();
            roleStatus.Set_Shift();
            if (roleAudioSource.isPlaying != true || roleAudioSource.clip != roleMusic[1])
            {
                roleAudioSource.clip = roleMusic[1];
                roleAudioSource.Play();
                roleAudioSource.loop = true;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            offset.x += speed * Time.deltaTime;
            roleTransform.eulerAngles = new Vector3(0, 0, 0);
            roleStatus.Set_Moving();
            if (roleAudioSource.isPlaying != true || roleAudioSource.clip != roleMusic[0])
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    roleAudioSource.clip = roleMusic[0];
                    roleAudioSource.loop = true;
                    roleAudioSource.Play();
                }
            }

        }
        else if (Input.GetKey(KeyCode.A))
        {
            offset.x -= speed * Time.deltaTime;
            roleTransform.eulerAngles = new Vector3(0, 180, 0);
            roleStatus.Set_Moving();
            if (roleAudioSource.isPlaying != true || roleAudioSource.clip != roleMusic[0])
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    roleAudioSource.clip = roleMusic[0];
                    roleAudioSource.loop = true;
                    roleAudioSource.Play();
                }
            }
        }



        if (climbing != Climbing.Out)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (climbing == Climbing.Down && transform.position.y >= playerPositon_Y) return;
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, 0);
                roleStatus.Set_Climbing();
                if (roleAudioSource.isPlaying != true || roleAudioSource.clip != roleMusic[4]) 
                {
                    roleAudioSource.clip = roleMusic[4];
                    roleAudioSource.loop = true;
                    roleAudioSource.Play();
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (climbing == Climbing.Up && transform.position.y >= playerPositon_Y) return;
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, 0);
                roleStatus.Set_Climbing();
                if (roleAudioSource.isPlaying == true && roleAudioSource.clip == roleMusic[4])
                {
                    roleAudioSource.clip = roleMusic[4];
                    roleAudioSource.loop = true;
                    roleAudioSource.Play();
                }
            }
        }
        else
        {
            roleStatus.Unset_Climbing();
        }

        hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        if (hit != false)
        { isGrounded = true; }
        else isGrounded = false;
        // 检测是否按下了跳跃键并且人物在地面上
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // 给人物施加向上的力，让人物跳跃
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log(1);
            roleStatus.Set_Jump();
            if (roleAudioSource.isPlaying == true) { roleAudioSource.Stop(); }
            roleAudioSource.clip = roleMusic[2];
            roleAudioSource.Play();
        }
        else if (!isGrounded)
        {
            if (roleAudioSource.isPlaying == true) { roleAudioSource.Stop(); }
            roleAudioSource.clip = roleMusic[3];
            roleAudioSource.Play();
            roleStatus.Unset_Jump();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!transform.Find("Light(Clone)"))
            {
                var go = Instantiate(light);
                lightEntity = go.GetComponent<LightEntity>();
                go.transform.SetParent(transform, false);
                go.GetComponent<SunEntity>().roleEntity = GetComponent<RoleEntity>();
            }

        }

        if (transform.Find("Light(Clone)"))
        {
            lightEntity.OnLight(useMicrophone.GetMaxVolume());
            lightEntity.offLight(useMicrophone.GetMaxVolume());
            lightEntity.Auto();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        transform.position += offset;

        if (Input.GetKeyDown(KeyCode.K))
        {

        }
        // export();

    }
    // public void export(){
    //     if(GameObject.Find("export").TryGetComponent(out exportEntity))
    //     exportEntity.GetMaxVolumeValue(useMicrophone.GetMaxVolume());
    // }
    //暂停窗口
    void TogglePause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    //音量UI
    void UIVolume(float volume)
    {
        if (volume > 5 && volume < 8)
        {
            volumeStatus.Set_Warning();
        }
        else if (volume > 10)
        {
            volumeStatus.Set_Visiable();
        }
        else
        {
            volumeStatus.Unset_Warning();
            volumeStatus.Unset_Visiable();
        }
    }

    // 人物的血条，氧气等UI
    void UIRoleState()
    {
        this.oxygen -= Time.deltaTime;
        oxygenImage.fillAmount = oxygen / maxOxygen;
        hpImage.fillAmount = HP / 3;
    }
    //隐藏和显示角色
    public void HideRole()
    {
        Debug.Log("hide");
        this.isHide = true;

    }

    public void VisibleRole()
    {
        Debug.Log("visiable");
        this.isHide = false;
    }

    bool isDead()
    {
        if (oxygen <= 0)
        {
            return true;
        }
        else if (HP <= 0)
        {
            return true;
        }
        return false;
    }
}
