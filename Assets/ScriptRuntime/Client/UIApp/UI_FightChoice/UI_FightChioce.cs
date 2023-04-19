using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FightChioce : MonoBehaviour
{
    public AudioSource fightChoiceAudio;
    public AudioClip fightClip;

    public void PlayAudio()
    {
        StartCoroutine(PrepareLoading());


    }

    IEnumerator PrepareLoading()
    {
        fightChoiceAudio.clip = fightClip;
        fightChoiceAudio.Play();
        yield return new WaitForSeconds(4f);
    }
}
