using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEntity : MonoBehaviour
{
    private DoorSpeechKey doorSpeechKey;
    public Collider2D doorCollider;
    public AudioSource doorAudio;
    private RoleEntity roleEntity;

    private Animator doorAnimator;

    //閿熸枻鎷烽敓鏂ゆ嫹閿熺粸璁规嫹閿熸枻鎷烽敓鏂ゆ嫹閿熻娇鐚紃ue鏃堕敓鏂ゆ嫹閿熸帴杈炬嫹閿熸枻鎷烽敓鏂ゆ嫹閿熻浜ら敓鏂ゆ嫹閿熸枻鎷风ず鎬�
    [SerializeField] private bool entered=false;
    [SerializeField] private bool locked=true;

    //閿熺嫛鏂ゆ嫹鍊�
    [Header("閿熺嫛鏂ゆ嫹鍊�")]
    [SerializeField]
    private int decipheringValue=0;

    //閿熺嫛鏂ゆ嫹鍊�-閿熸枻鎷峰€�
    public int max_DecipheringValue;

    //閿熸埅纭锋嫹閿熸枻鎷�
    public List<string> keywords;

    void Start()
    {
        doorAudio = GetComponent<AudioSource>();
        doorAnimator = GetComponent<Animator>();
        doorSpeechKey = GetComponent<DoorSpeechKey>();
        StartCoroutine(StandbyState());
    }

    /// <summary>
    /// 閿熸枻鎷烽敓鏂ゆ嫹鐘舵€�
    /// </summary>
    /// <returns></returns>
    IEnumerator StandbyState()
    {
        while (!entered)
        { 
            yield return new WaitForSeconds(0.02f); 
        }
        StartCoroutine(InteractionbyState());
        doorAudio.clip = Resources.Load<AudioClip>("S004001");
        doorAudio.Play();
    }


    /// <summary>
    /// 閿熸枻鎷烽敓鏂ゆ嫹鐘舵€侀敓鏂ゆ嫹閿熸枻鎷烽敓鏂ゆ嫹閿熸枻鎷烽敓鏂ゆ嫹璇嗛敓鏂ゆ嫹
    /// </summary>
    /// <returns></returns>
    IEnumerator InteractionbyState()
    {
        while (entered&&locked)
        {
            for (int i=keywords.Count-1;i>=0;i--)
            {
                //閿熸枻鎷烽敓鏂ゆ嫹閿熸埅纭锋嫹閿熸枻鎷峰尮閿熸垝锛岄敓鏂ゆ嫹涔堥敓鐙℃枻鎷锋檼閿燂拷
                if (doorSpeechKey.GetKeyword().Equals(keywords[i]))
                {
                    Deciphering();
                    keywords.Remove(keywords[i]);
                }
            }
            yield return new WaitForSeconds(0.02f);
            //Debug.Log("閿熺嫛鏂ゆ嫹鐘舵€�");
        }
        if (!entered&&locked) 
        {
            StartCoroutine(StandbyState());
        }
    }


    /// <summary>
    /// 閿熺嫛鏂ゆ嫹鏅掗敓鏂ゆ嫹閿熸枻鎷烽敓鏂ゆ嫹閿熸枻鎷峰钩閿熻纰夋嫹閿熸枻鎷烽敓鏂ゆ嫹閿熸枻鎷峰钩閿熸枻鎷烽敓鍙嶆嫹閿熸枻鎷风灔閿熸枻鎷烽敓闃惰鎷锋竟顒婃嫹閿熶茎浼欐嫹閿熸枻鎷烽敓鏂ゆ嫹濯掓秾鍐㈤敓鏂ゆ嫹閿燂拷
    /// </summary>
    void Deciphering()
    {
        decipheringValue += 1;
        doorAudio.clip = Resources.Load<AudioClip>("S004003");
        doorAudio.Play();
        SuccessfullyDeciphering();
    }

    /// <summary>
    /// 閿熺嫛鏂ゆ嫹鍊奸敓鏂ゅ埌閿熸枻鎷峰€奸敓鏂ゆ嫹閿熸枻鎷烽敓鑴氾綇鎷烽敓鏂ゆ嫹閿熻剼鍖℃嫹閿熸枻鎷烽敓鏂ゆ嫹鏁堥敓鏂ゆ嫹閿熸枻鎷烽敓鑴氳鎷烽敓鏂ゆ嫹閿熸枻鎷烽敓鎴唻鎷烽敓鏂ゆ嫹鎾為敓鏂ゆ嫹
    /// </summary>
    void SuccessfullyDeciphering()
    {
        if (decipheringValue >= max_DecipheringValue)
        {
            doorAudio.clip = Resources.Load<AudioClip>("S004004");
            doorAudio.Play();

            doorAnimator.SetTrigger("Unlock");
            Debug.Log(doorAudio.clip);
            doorCollider.enabled = false;
            locked = false;
        }
    }


    void OnTriggerEnter2D(Collider2D role)
    {
        if (role.TryGetComponent(out roleEntity))
        {
        entered = true;
        Debug.Log("OK");
        }
    }

    void OnTriggerExit2D(Collider2D role)
    {
        if (role.TryGetComponent(out roleEntity))
        {
        entered = false;
        }
    }

}
