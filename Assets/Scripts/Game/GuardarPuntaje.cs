using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HighScoreData", menuName = "ScriptableObjects/HighScoreData", order = 1)]
public class GuardarPuntaje : ScriptableObject
{
    public int highestScore;
}
