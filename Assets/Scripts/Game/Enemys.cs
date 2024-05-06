using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
  
    public int lifeChanges;
    public int frame;
    public AudioClip EnemySound;
    public AudioClip PlayerSound;
    private AudioSource audioSource;
    private AudioSource audioSource1;
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource1 = FindObjectOfType<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("No se encontró un AudioSource en la escena.");
        }
    }
    void Update()
    {
        if (transform.position.x <= -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x)
        {
           EnemysGenerator.instance.ManageEnemy(this);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            PlayPowerSound();
            Destroy(gameObject);
        }
    }

    private void PlayPowerSound()
    {
        if (audioSource != null && EnemySound != null)
        {
            audioSource.PlayOneShot(EnemySound);
        }
        if (audioSource1 != null && PlayerSound != null)
        {
            audioSource1.PlayOneShot(PlayerSound);
        }
    }
}
