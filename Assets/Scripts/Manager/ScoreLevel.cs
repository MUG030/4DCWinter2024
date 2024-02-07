using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class ScoreLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI levelCountText;
    // [SerializeField] private Slider levelCountBar;

    private int scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GameManager.instance.GetScore().ToString() + "p";
    }

    void Update()
    {
        StartLevelCount();
        Debug.Log(scoreCount);
    }

    private void StartLevelCount()
    {
        int totalScore = GameManager.instance.GetTotalScore();  // トータルスコアを取得
        int levelCount = GameManager.instance.GetLevelCount();  // 現在レベルのカウント上限値を取得

        levelText.text = GameManager.instance.GetLevel().ToString();

        if (totalScore < levelCount)
        {
            StartCoroutine(CountScore());
        }
        else if (totalScore >= levelCount)
        {
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

        scoreCount = startScore;

        for (int i = startScore; i <= endScore; i++)
        {
            levelCountText.text = i.ToString() + "/" + GameManager.instance.GetLevelCount().ToString();
            yield return null; // 次のフレームまで待機
        }
    }
}
