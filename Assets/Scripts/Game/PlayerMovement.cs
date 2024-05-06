using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myRB;
    [SerializeField]
    private float speed;
    private float yMovement;
    private float limitSuperior;
    private float limitInferior;
    public int player_lives = 4;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        SetMinMax();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckLimit();
    }
    void Move()
    {
        myRB.velocity = new Vector2(0, yMovement * speed);
    }
    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y ;
        limitSuperior = bounds.y ;
    }
    void CheckLimit()
    {
        Vector2 newPosition = transform.position;
        newPosition.y = Mathf.Clamp(newPosition.y, limitInferior, limitSuperior);
        transform.position = newPosition;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }
        else if(other.tag == "Enemy")
        {
            EnemysGenerator.instance.ManageEnemy(other.gameObject.GetComponent<Enemys>(), this);
        }
    }
    public void OnMovementY(InputAction.CallbackContext context)
    {
        yMovement = context.ReadValue<float>();
    }
}
