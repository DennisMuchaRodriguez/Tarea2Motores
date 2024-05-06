using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


public class EnemysGenerator : MonoBehaviour
{
    public static EnemysGenerator instance;
    public List<GameObject> Enemies = new List<GameObject>();
    private float timeToCreate = 4f;
    private float actualTime = 0f;
    private float limitSuperior;
    private float limitInferior;
    public List<GameObject> EnemyActual = new List<GameObject>();
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    void Start()
    {
        SetMinMax();
    }

    void Update()
    {
        actualTime += Time.deltaTime;
        if (timeToCreate <= actualTime)
        {
            GameObject enemy = Instantiate(Enemies[Random.Range(0, Enemies.Count)],
            new Vector3(transform.position.x, Random.Range(limitInferior, limitSuperior), 0f), Quaternion.identity);
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0);
            actualTime = 0f;
            EnemyActual.Add(enemy);
        }
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -(bounds.y * 0.9f);
        limitSuperior = (bounds.y * 0.9f);
    }
    public void ManageEnemy(Enemys enemysController, PlayerMovement player_script = null)
    {
        if (player_script == null)
        {
            Destroy(enemysController.gameObject);
            return;
        }
        if (enemysController.frame == 3)
        {
            SceneManager.LoadScene("GameOver");
            return;
        }
        int lives = player_script.player_lives;
        int live_changer = enemysController.lifeChanges;
        lives += live_changer;
  
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        player_script.player_lives = lives;
        Destroy(enemysController.gameObject);
    }
}
