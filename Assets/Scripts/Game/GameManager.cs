using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GuardarPuntaje highScoreData;
    public TextMeshProUGUI scoreText;
    public void GameOver(int finalScore)
    {
        
        if (finalScore > highScoreData.highestScore)
        {
            highScoreData.highestScore = finalScore;
       
        }

       
        SceneManager.LoadScene("GameOver");
        scoreText.text = "Puntaje final: " + finalScore.ToString();
    }

}
