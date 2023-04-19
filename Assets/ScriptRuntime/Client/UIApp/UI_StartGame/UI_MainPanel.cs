using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_MainPanel : MonoBehaviour
{
    public Image startGame;
    public Image exitGame;
    public GameObject loadingPanel;
    public AudioSource mainAudio;
    public AudioClip mainMusic;



    /// <summary>
    /// 加载场景
    /// </summary>
    public void ClickStartGame()
    {
        loadingPanel.SetActive(true);
        mainAudio.clip = mainMusic;
        mainAudio.Play();
        StartCoroutine(PrepareLoading());
    }

    IEnumerator PrepareLoading()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }

    public void ClickExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//如果是在unity编译器中
#else
        Application.Quit();//否则在打包文件中
#endif
    }

    public void EnterStartGame()
    {
        startGame.sprite = Resources.Load<Sprite>("开始游戏点击特效");
    }

    public void ExitStartGame()
    {
        startGame.sprite = Resources.Load<Sprite>("开始游戏按钮");
    }

    public void EnterExitGame()
    {
        startGame.sprite = Resources.Load<Sprite>("退出游戏点击特效");
    }

    public void ExitExitGame()
    {
        startGame.sprite = Resources.Load<Sprite>("退出游戏按钮");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
