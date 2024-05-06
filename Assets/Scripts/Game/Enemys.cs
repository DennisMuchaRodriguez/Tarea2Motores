using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
  
    public int lifeChanges;
    public int frame;
    void Update()
    {
        if (transform.position.x <= -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x)
        {
           EnemysGenerator.instance.ManageEnemy(this);
        }

    }

}
