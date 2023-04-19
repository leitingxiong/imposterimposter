using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingSystem : MonoBehaviour
{

    public GameObject talking;
    public Text speaker;
    public Text Dialogue;
    public Text prompt;

    /// <summary>
    /// 对话人显示
    /// </summary>
    /// <param name="text"></param>
    public void ShowSpeakerText(string text)
    {
        speaker.text = text;
    }

    /// <summary>
    /// 对话内容显示
    /// </summary>
    /// <param name="text"></param>
    public void ShowDialogueText(string text)
    {
        Dialogue.text = text;
    }

    /// <summary>
    /// 对话提示显示
    /// </summary>
    /// <param name="text"></param>
    public void ShowPromptText(string text)
    {
        prompt.text = text;
    }

    /// <summary>
    /// 字幕淡出，全部
    /// </summary>
    /// <returns></returns>
    IEnumerator Clear()
    {
        for (int i = 255; i >= 0; i -= 1)
        {
            yield return new WaitForSeconds(0.02f);
            speaker.color = new Color32(255, 255, 255, (byte)i);
            Dialogue.color = new Color32(255, 255, 255, (byte)i);
            prompt.color = new Color32(80, 255, 10, (byte)i);
        }

    }

    /// <summary>
    /// 字幕淡出，不包括说话者speaker的淡出
    /// </summary>
    /// <returns></returns>
    IEnumerator Part_Clear()
    {
        for (int i = 255; i >= 0; i -= 1)
        {
            yield return new WaitForSeconds(0.02f);
            Dialogue.color = new Color32(255, 255, 255, (byte)i);
            prompt.color = new Color32(80, 255, 10, (byte)i);
        }
    }

    /// <summary>
    /// 字幕显示
    /// </summary>
    /// <returns></returns>
    IEnumerator Show()
    {
        for (int i = 0; i <= 255; i += 5)
        {
            yield return new WaitForSeconds(0.02f);
            speaker.color = new Color32(255, 255, 255, (byte)i);
            Dialogue.color = new Color32(255, 255, 255, (byte)i);
            prompt.color = new Color32(80, 255, 10, (byte)i);
        }
    }

    /// <summary>
    /// 部分字幕显示
    /// </summary>
    /// <returns></returns>
    IEnumerator Part_Show()
    {
        for (int i = 0; i <= 255; i += 5)
        {
            yield return new WaitForSeconds(0.02f);
            Dialogue.color = new Color32(255, 255, 255, (byte)i);
            prompt.color = new Color32(0, 255, 10, (byte)i);
        }
    }


    public void ShowText(string dialoguetext, string speakertext = null, string prompttext = null)
    {
        Dialogue.text = dialoguetext;
        if (speakertext != null) speaker.text = speakertext;
        if (prompttext != null) prompt.text = prompttext;
        //说话者不改变与说话者改变的情况
        if (speakertext == null || speakertext.Equals(speaker.text)) StartCoroutine(Part_Clear());
        else StartCoroutine(Clear());
    }

    public void EndDialogue()
    {
        talking.SetActive(false);
    }

    public void StartDialogue()
    {
        talking.SetActive(true);
    }






    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
