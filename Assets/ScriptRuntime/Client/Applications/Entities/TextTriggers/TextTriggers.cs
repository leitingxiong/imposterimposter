using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTriggers : MonoBehaviour
{
    public AudioSource textAudio;
    public TalkingSystem talkingSystem;
    public string talkName;
    public string talkStart;
    public string prompttext;
    public RoleEntity roleEntity;

    void Start()
    {
        textAudio = transform.GetComponent<AudioSource>();
        talkingSystem = FindObjectOfType<TalkingSystem>();

    }

    void OnTriggerEnter2D(Collider2D role)
    {
        if (role.TryGetComponent(out roleEntity))
        {
            textAudio.Play();
            talkingSystem.StartDialogue();
            talkingSystem.ShowText(talkStart, talkName, prompttext);
            Debug.Log("OK");
        }
    }

    void OnTriggerExit2D(Collider2D role)
    {
        if (role.TryGetComponent(out roleEntity))
        {
            talkingSystem.EndDialogue();
            // textTriggers.ShowSubtitle("");
        }
    }
}
