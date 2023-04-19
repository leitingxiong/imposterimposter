using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;//引入命名空间  利用
using SpeechLib;


/// <summary>
/// 密码门的语音识别脚本
/// </summary>
public class DoorSpeechKey : MonoBehaviour
{
    // 短语识别器
    private PhraseRecognizer m_PhraseRecognizer;
    // 识别后的关键词
    private string keyword;
    // 关键字
    public string[] keywords;
    // 可信度
    public ConfidenceLevel m_confidenceLevel = ConfidenceLevel.Medium;

    void Start()
    {
        keyword = "";
        keywords = GetComponent<DoorEntity>().keywords.ToArray();
        
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

    private void M_PhraseRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        keyword = args.text;
        Debug.Log(keyword);
    }


    /// <summary>
    /// 获取最新识别后的关键词
    /// </summary>
    /// <returns></returns>
    public string GetKeyword()
    {
        return keyword;
    }
    

}
