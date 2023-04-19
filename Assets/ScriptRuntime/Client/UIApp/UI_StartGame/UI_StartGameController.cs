using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StartGameController : MonoBehaviour
{

    public GameObject GuidePanel;

    public Image word;
    public Image microphone;


    void Start()
    {
        StartCoroutine(GuideShow());
    }

    IEnumerator GuideShow()
    {
        for (int i =0; i <= 25; i += 5)
        {
            yield return new WaitForSeconds(0.1f);
            word.color = new Color32(255, 255, 255, (byte)i);
            microphone.color = new Color32(255, 255, 255, (byte)i);
        }
        StartCoroutine(GuideDisappear());
    }

    IEnumerator GuideDisappear()
    {
        for (int i = 255; i >= 0; i -= 5)
        {
            yield return new WaitForSeconds(0.1f);
            word.color = new Color32(255, 255, 255, (byte)i);
            microphone.color = new Color32(255, 255, 255, (byte)i);
        }
        GuidePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
