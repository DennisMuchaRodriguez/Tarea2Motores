using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CandyController : MonoBehaviour
{
    public int frame;
    public int lifeChanges;
    public int scoreValue;
    public AudioClip candySound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No se encontró un AudioSource en la escena.");
        }
    }
    void Update()
    {
        if (transform.position.x <= -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x)
        {
            CandyGenerator.instance.ManageCandy(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Puntaje.instance.AumenScore(scoreValue);
            PlayCandySound();
            Destroy(gameObject);
        }
    }
    private void PlayCandySound()
    {
        if (audioSource != null && candySound != null)
        {
            audioSource.PlayOneShot(candySound);
        }
    }
}
