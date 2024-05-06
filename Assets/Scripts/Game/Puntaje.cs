using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Puntaje : MonoBehaviour
{
    public static Puntaje instance;
    public TextMeshProUGUI textMeshPro;
    public int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void UpdateScoreText()
    {
        textMeshPro.text = "Puntuacion: " + score.ToString();
    }
    public void AumenScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
}
