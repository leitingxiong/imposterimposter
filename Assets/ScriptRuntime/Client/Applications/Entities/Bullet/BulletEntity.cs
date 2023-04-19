using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEntity : MonoBehaviour
{
    public float speed = 80f;
    public AudioSource audioSource;
    private RoleEntity roleEntity;


    void Update()
    {
        transform.Translate(Time.deltaTime * speed*transform.localScale.x, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("OK");
        if (collider.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
        else if (collider.TryGetComponent(out roleEntity))
        {
            Debug.Log("命中");
            audioSource.clip = Resources.Load<AudioClip>("S003005");
            audioSource.Play();
            Destroy(gameObject);
        }
    }

}
