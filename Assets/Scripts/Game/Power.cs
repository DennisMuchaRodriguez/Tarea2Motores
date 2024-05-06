using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public int frame;
    public int lifeChanges;
    public int scoreValue;
    public AudioClip powerSound; 
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
            PowerGenerator.instance.ManagePower(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Puntaje.instance.AumenScore(scoreValue);
            PlayPowerSound();
            Destroy(gameObject);
        }
    }

    private void PlayPowerSound()
    {
        if (audioSource != null && powerSound != null)
        {
            audioSource.PlayOneShot(powerSound); 
        }
    }
}
