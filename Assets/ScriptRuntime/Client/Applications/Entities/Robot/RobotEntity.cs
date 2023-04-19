using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEntity : MonoBehaviour
{
    private RobotStatusController robotStatusController;
    private float initPosition;

    [Header("警戒值")]
    [SerializeField]
    private float warningValue;

    [Header("警戒值A")]
    [SerializeField]
    private float warningValue_A;

    [Header("警戒值B")]
    [SerializeField]
    private float warningValue_B;

    [Header("放松状态警戒值减少量，每秒执行50次")]
    [Tooltip("每秒会执行50次")]
    [SerializeField]
    private float reduceWarningValue;

    [Header("戒备状态警戒值增加倍率")]
    [Tooltip("警戒值增加基础值与音量大小有关，这个需要策划自己调试")]
    [SerializeField]
    private float addWarningMultiple;

    [Header("左巡逻x坐标")]
    public float leftPatrol;

    [Header("右巡逻x坐标")]
    public float rightPatrol;

    [Header("移动速度")]
    public float speed;

    public Transform shoot;
    public AudioSource audioSource;

    public enum RobotFSM
    {
        Patrol_Left = 1,//左方向前进的戒备状态
        Patrol_Right = 2,//右方向前进的戒备状态
        Warning = 3,
        Attacking = 4,
    }
    public RobotFSM robotFSM;

    void Start()
    {
        initPosition = transform.position.x;
        robotFSM = (RobotFSM)Random.Range(1, 3);//随机左走或者右走
        robotStatusController = GetComponent<RobotStatusController>();
        StatusJudge();
    }

    /// <summary>
    /// 死亡函数，播放动画
    /// </summary>
    public void IsDead()
    {

    }

    /// <summary>
    /// 增加警戒值
    /// </summary>
    public void AddWarning(float addWarningValue)
    {
        warningValue += addWarningValue * addWarningMultiple;
    }

    /// <summary>
    /// 进入攻击状态
    /// </summary>
    public void EnterAttackingStatus()
    {
        warningValue += warningValue_B;
    }

    /// <summary>
    /// 根据不同状态标识，切换协程状态
    /// </summary>
    private void StatusJudge()
    {
        // Debug.Log("状态判定");
        if (robotFSM == RobotFSM.Patrol_Left || robotFSM == RobotFSM.Patrol_Right)
        {
            StartCoroutine(PatorlStatus());
            // audioSource.clip= Resources.Load<AudioClip>("");
        }
        else if (robotFSM == RobotFSM.Warning)
        {
            StartCoroutine(WarningStatus());
            audioSource.clip = Resources.Load<AudioClip>("S003002");
            audioSource.Play();
        }
        else if (robotFSM == RobotFSM.Attacking)
        {
            StartCoroutine(AttackingStatus());
            audioSource.clip = Resources.Load<AudioClip>("S003003");
            audioSource.Play();
        }
    }

    /// <summary>
    /// 戒备阶段的协程状态
    /// </summary>
    /// <returns></returns>
    IEnumerator PatorlStatus()
    {
        robotStatusController.Set_Patorl();
        while (robotFSM == RobotFSM.Patrol_Left || robotFSM == RobotFSM.Patrol_Right)
        {
            // Debug.Log("巡逻");
            Turning();
            Moving();
            WarningValueJudge();
            yield return new WaitForSeconds(0.02f);
        }
        robotStatusController.UnSet_Patorl();
        StatusJudge();
    }


    /// <summary>
    /// 警戒阶段的协程状态
    /// </summary>
    /// <returns></returns>
    IEnumerator WarningStatus()
    {
        robotStatusController.Set_Warning();
        while (robotFSM == RobotFSM.Warning)
        {
            // Debug.Log("警戒");
            WarningValueJudge();
            yield return new WaitForSeconds(0.02f);
        }
        robotStatusController.UnSet_Warning();
        StatusJudge();
    }

    IEnumerator AttackingStatus()
    {
        while (robotFSM == RobotFSM.Attacking)
        {
            //  Debug.Log("攻击");
            warningValue = (warningValue_B +warningValue_A)/2;
            AttackingEnemy();
            WarningValueJudge();
            yield return new WaitForSeconds(0.02f);
        }
        StatusJudge();
    }

    /// <summary>
    /// 警戒值判定函数，负责警戒值减少与模式识别
    /// </summary>
    private void WarningValueJudge()
    {
        if (robotFSM == RobotFSM.Patrol_Left || robotFSM == RobotFSM.Patrol_Right||robotFSM == RobotFSM.Warning) ReduceWarningValue();
        if (warningValue < 0) warningValue = 0;

        if (warningValue < warningValue_A && robotFSM != RobotFSM.Patrol_Left && robotFSM != RobotFSM.Patrol_Right) robotFSM = (RobotFSM)Random.Range(1, 3);
        else if (warningValue < warningValue_B && warningValue > warningValue_A) robotFSM = RobotFSM.Warning;
        else if (warningValue >= warningValue_B) robotFSM = RobotFSM.Attacking;
    }

    /// <summary>
    /// 在A、B之间徘徊的行动函数
    /// </summary>
    private void Moving()
    {
        //移动
        if (robotFSM == RobotFSM.Patrol_Right)
            transform.position = new Vector2(transform.position.x + 0.02f * speed, transform.position.y);
        else if (robotFSM == RobotFSM.Patrol_Left)
            transform.position = new Vector2(transform.position.x - 0.02f * speed, transform.position.y);
    }

    /// <summary>
    /// 转向函数（这里是否需要将人物方向rotation改变？）
    /// </summary>
    private void Turning()
    {
        if (transform.position.x > initPosition + rightPatrol)
        {
            robotFSM = RobotFSM.Patrol_Left;
            transform.localScale = new Vector2(-3, 3);
        }   //左转向
        else if (transform.position.x < initPosition + leftPatrol)
        {
            robotFSM = RobotFSM.Patrol_Right;
            transform.localScale = new Vector2(3, 3);
        }//右转向
    }

    /// <summary>
    /// 识别敌人并进行攻击，减少警戒值，播放攻击动画
    /// </summary>
    private void AttackingEnemy()
    {
        Debug.Log("攻击");
        audioSource.clip = Resources.Load<AudioClip>("S003004");
        audioSource.Play();
        GameObject bulletPrefab = Resources.Load<GameObject>("Bullet");
        GameObject insPerfab = Instantiate(bulletPrefab, shoot.position, transform.rotation);
        insPerfab.transform.localScale = transform.localScale.normalized;
        robotStatusController.Set_Attack();
    }


    public void ReduceWarningValue()
    {
        warningValue -= reduceWarningValue/5;//随时间定量减少
    }

}

