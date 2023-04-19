using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneManage : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }
    public void ToStartGameScene()
    {
        SceneManager.LoadScene("UIStartGameScene");
    }
    public void ToGameScene()
    {
        SceneManager.LoadScene("UIFIghtChoice");
    }

    public void ToQuitScene()
    {
        Application.Quit();
    }

    public void ToFightFirstScene()
    {
        SceneManager.LoadScene("Fight1-1");
    }

    public void ToFightSecondScene()
    {
        SceneManager.LoadScene("Fight1-2");
    }

    public void ToFightThreeScene()
    {
        SceneManager.LoadScene("Fight1-3");
    }

    public void ToFightFourScene()
    {
        SceneManager.LoadScene("Fight1-4");
    }
    public void ToFightFiveScene()
    {
        SceneManager.LoadScene("Fight1-5");
    }
    public void ToFightSixScene()
    {
        SceneManager.LoadScene("Fight1-6");
    }
    public void ToFightSenvenScene()
    {
        SceneManager.LoadScene("Fight1-7");
    }
    public void ToFightEightScene()
    {
        SceneManager.LoadScene("Fight1-8");
    }
    public void ToFightNineScene()
    {
        SceneManager.LoadScene("Fight1-9");
    }
    public void ToFightTenScene()
    {
        SceneManager.LoadScene("Fight1-10");
    }
}
