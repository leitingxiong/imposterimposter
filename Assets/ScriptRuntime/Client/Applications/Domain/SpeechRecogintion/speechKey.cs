using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;//引入命名空间  利用
using SpeechLib;

/// <summary>
/// 语音识别（主要是别关键字）
/// </summary>
public class speechKey : MonoBehaviour
{
    // 短语识别器
    private PhraseRecognizer m_PhraseRecognizer;
    // 关键字
    public string[] keywords = { "你好", "石破天惊","停止" };
    // 可信度
    public ConfidenceLevel m_confidenceLevel = ConfidenceLevel.Medium;

    /// <summary>
    /// 显示的文字
    /// </summary>
    private Text ShowText;
    // Use this for initialization
    void Start()
    {
        ShowText = GameObject.Find("Role").GetComponent<Text>();
        if (m_PhraseRecognizer == null)
        {
            //创建一个识别器
            m_PhraseRecognizer = new KeywordRecognizer(keywords, m_confidenceLevel);
            //通过注册监听的方法
            m_PhraseRecognizer.OnPhraseRecognized += M_PhraseRecognizer_OnPhraseRecognized;
            //开启识别器
            m_PhraseRecognizer.Start();
          
            Debug.Log("创建识别器成功");
        }
    }

    /// <summary>
    ///  当识别到关键字时，会调用这个方法
    /// </summary>
    /// <param name="args"></param>
    private void M_PhraseRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        SpeechRecognition();
        ShowText.text = "识别内容：" + args.text;
        print(args.text);
        
        if (args.text.Equals("石破天惊"))
        {
            SpVoice v = new SpVoice();
            v.Voice = v.GetVoices(string.Empty, string.Empty).Item(0);
            v.Speak("盖亚");
            Debug.Log("盖亚");
        }
        if (args.text.Equals("雷神天明闪"))
        {
            SpVoice v = new SpVoice();
            v.Voice = v.GetVoices(string.Empty, string.Empty).Item(0);
            v.Speak("雷伊");
            Debug.Log("雷伊");
        }
        if (args.text.Equals("绝命火焰"))
        {
            SpVoice v = new SpVoice();
            v.Voice = v.GetVoices(string.Empty, string.Empty).Item(0);
            v.Speak("魔焰猩猩");
            Debug.Log("魔焰猩猩");
        }
        if (args.text.Equals("克制"))
        {
            SpVoice v = new SpVoice();
            v.Voice = v.GetVoices(string.Empty, string.Empty).Item(0);
            v.Speak("巴鲁斯");
            Debug.Log("巴鲁斯");
        }
        if (args.text.Equals("双重暗影"))
        {
            SpVoice v = new SpVoice();
            v.Voice = v.GetVoices(string.Empty, string.Empty).Item(0);
            v.Speak("布莱克");
            Debug.Log("布莱克");
        }
        if (args.text.Equals("哥们这瓜多少钱一斤"))
        {
            SpVoice v = new SpVoice();
            v.Voice = v.GetVoices(string.Empty, string.Empty).Item(0);
            v.Speak("刘华强");
            Debug.Log("刘华强");
        }
        if (args.text.Equals("我就是大名鼎鼎的重庆军统"))
        {
            SpVoice v = new SpVoice();
            v.Voice = v.GetVoices(string.Empty, string.Empty).Item(0);
            v.Speak("穿山甲");
            Debug.Log("穿山甲");
        }
    }
    private void OnDestroy()
    {
        //判断场景中是否存在语音识别器，如果有，释放
        if (m_PhraseRecognizer != null)
        {
            //用完应该释放，否则会带来额外的开销
            m_PhraseRecognizer.Dispose();
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 识别到语音的操作
    /// </summary>
    void SpeechRecognition()
    {
       
    }  
}