using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody2D myRB;
    [SerializeField]
    private float speed;
    private float yMovement;
    private float limitSuperior;
    private float limitInferior;
    public int player_lives = 4;
    private bool invulnerable = false;
    public TextMeshProUGUI lifeText;
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
        UpdateLifeText();
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
    private IEnumerator MakePlayerInvulnerable()
    {
        invulnerable = true;
        yield return new WaitForSeconds(1f); 
        invulnerable = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }
        if (other.tag == "Power")
        {
            PowerGenerator.instance.ManagePower(other.gameObject.GetComponent<Power>(), this);
        }
        else if(other.tag == "Enemy")
        {
            EnemysGenerator.instance.ManageEnemy(other.gameObject.GetComponent<Enemys>(), this);
            StartCoroutine(MakePlayerInvulnerable());
            ResetPlayerPosition();
        }
    }
    private void ResetPlayerPosition()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = 0f; 
        transform.position = newPosition;
    }
    public void OnMovementY(InputAction.CallbackContext context)
    {
        yMovement = context.ReadValue<float>();
    }
    private void UpdateLifeText()
    {
        lifeText.text = "x" + player_lives.ToString();
    }
}
