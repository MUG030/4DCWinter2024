using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
