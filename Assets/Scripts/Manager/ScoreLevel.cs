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
    }

    void Update()
    {
        StartLevelCount();
    }

    private void StartLevelCount()
    {
        levelText.text = GameManager.instance.GetLevel().ToString();

        while (GameManager.instance.GetTotalScore() >= GameManager.instance.levelCount)
        {
            StartCoroutine(CountScore());

            GameManager.instance.AddLevel();
            GameManager.instance.GetLevel();
            levelText.text = GameManager.instance.GetLevel().ToString();
            GameManager.instance.AddLevelCount(300);
        }

        
    }

    private IEnumerator CountScore()
    {
        int startScore = GameManager.instance.totalScoreList; // 仮定: totalScoreListはint型
        int endScore = GameManager.instance.GetTotalScore();

        for (int i = startScore; i <= endScore; i++)
        {
            levelCountText.text = i.ToString() + "/" + GameManager.instance.GetLevelCount().ToString();
            yield return null; // 次のフレームまで待機
        }
    }
}
