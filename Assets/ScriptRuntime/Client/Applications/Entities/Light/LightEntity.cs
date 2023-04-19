using System.Collections;
using UnityEngine.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Light2D))]
public class LightEntity : MonoBehaviour
{
    // public GameObject ray;
    public Light2D light;
    public CircleCollider2D lightCollider;
    public AudioSource lightAudio;
    public AudioSource lightDeadAudio;
    public AudioClip[] lightMusic;

    void Start()
    {
        light = GetComponent<Light2D>();
        lightCollider = GetComponent<CircleCollider2D>();
        lightAudio = GetComponent<AudioSource>();
        GameObject lightAudioObject = Resources.Load<GameObject>("PublicAudio");
        GameObject AudioObject = Instantiate(lightAudioObject);
        lightDeadAudio = AudioObject.GetComponent<AudioSource>();
    }

    //关灯这里采用的声音数值还没测试
    // IEnumerator OnLightState(){

    // }


    public void OnLight(float volume)
    {

        if (volume < 10 && volume > 1 && light.pointLightOuterRadius < 50)
        {
            if (lightAudio.isPlaying == true) { lightAudio.Stop(); }
            lightAudio.clip = lightMusic[0];
            lightAudio.Play();
            lightAudio.loop = true;
            light.pointLightOuterRadius += Time.deltaTime * volume * 2;
        }
    }
    public void offLight(float volume)
    {
        if (volume > 12 || light.pointLightOuterRadius <= 0)
        {
            lightDeadAudio.Play();
            Destroy(gameObject);
        }
    }
    public void Auto()
    {
        if (light.pointLightOuterRadius >= 0)
        {
            float currentRadiu = light.pointLightOuterRadius;
            currentRadiu -= Time.deltaTime;
            light.pointLightOuterRadius = currentRadiu;
            lightCollider.radius = currentRadiu;
            light.pointLightInnerRadius = currentRadiu / 2;
        }
    }
}
