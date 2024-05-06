using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyController : MonoBehaviour
{
    public int frame;
    public int lifeChanges;
    public int scoreValue;

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
            Destroy(gameObject);
        }
    }
}
