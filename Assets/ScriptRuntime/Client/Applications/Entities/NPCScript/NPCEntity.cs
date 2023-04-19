using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCEntity : MonoBehaviour
{
    public Animator NPCAnimation;
    private AudioSource NPCaudio;
    public AudioClip NPCMusic;
    private NPCSpeechKey NPCSpeech;
    public TalkingSystem talkingSystem;
    public bool entered = false;
    private RoleEntity roleEntity;

    public string talkStart;
    public string prompttext;
    public List<string> keywords;
    public List<string> talks;
    void Start()
    {
        NPCSpeech = GetComponent<NPCSpeechKey>();
        NPCAnimation = GetComponent<Animator>();
        NPCaudio = GetComponent<AudioSource>();
        talkingSystem = FindObjectOfType<TalkingSystem>();
        StartCoroutine(standbyState());
    }

    IEnumerator standbyState()
    {
        while (!entered)
        {
            // NPCtext
            yield return new WaitForSeconds(0.02f);
        }
        StartCoroutine(InteractionbyState());
    }

    IEnumerator InteractionbyState()
    {
        while (entered)
        {
            for (int i = keywords.Count - 1; i >= 0; i--)
            {
                if (NPCSpeech.GetKeyword().Equals(keywords[i]))
                {
                    Debug.Log("ok");
                    talkingSystem.ShowText(talks[i], gameObject.name);
                }
            }
            yield return new WaitForSeconds(0.02f);
        }
        if (!entered)
        {
            StartCoroutine(standbyState());
        }
    }


    void OnTriggerEnter2D(Collider2D role)
    {
        if (role.TryGetComponent(out roleEntity))
        {
            talkingSystem.StartDialogue();
            talkingSystem.ShowText(talkStart, gameObject.name, prompttext);
            roleEntity.roleStatus.Set_SceneInteraction();
            Set_Interaction();
            entered = true;
        }
    }

    void OnTriggerExit2D(Collider2D role)
    {
        if (role.TryGetComponent(out roleEntity))
        {
            entered = false;
            talkingSystem.EndDialogue();
            // textTriggers.ShowSubtitle("");
            Unset_Interaction();
        }
    }
    /// <summary>
    /// 交互时调用
    /// </summary>
    public void Set_Interaction()
    {
        NPCAnimation.SetBool("Interaction", true);
        NPCaudio.clip = NPCMusic;
        NPCaudio.Play();
    }
    /// <summary>
    /// 待命时调用
    /// </summary>
    public void Unset_Interaction()
    {
        NPCAnimation.SetBool("Interaction", false);
    }


}