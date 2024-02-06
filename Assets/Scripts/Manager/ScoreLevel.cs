using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI levelCountText;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GameManager.instance.GetScore().ToString() + "p";
        levelText.text = GameManager.instance.GetLevel().ToString();

        while (GameManager.instance.GetTotalScore() >= GameManager.instance.levelCount)
        {
            GameManager.instance.AddLevel();
            GameManager.instance.GetLevel();
            levelText.text = GameManager.instance.GetLevel().ToString();
            GameManager.instance.AddLevelCount(300);
        }

        levelCountText.text = GameManager.instance.GetTotalScore().ToString() + "/" + GameManager.instance.GetLevelCount().ToString();
    }
}
