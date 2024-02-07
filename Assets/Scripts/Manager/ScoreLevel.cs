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
    [SerializeField] private Slider levelCountBar;

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
        int startScore = GameManager.instance.totalScoreList;   // 直前Sceneのトータルスコア（初期値）を取得
        int endScore = GameManager.instance.GetTotalScore();    // 今回のSceneのトータルスコアを取得
        int levelUpScore = GameManager.instance.GetLevelCount(); // 現在のレベルカウント上限値を取得

        for (int i = startScore; i <= endScore; i++)
        {
            LevelScrollBar(startScore, levelUpScore, i);
            levelCountText.text = i.ToString() + "/" + GameManager.instance.GetLevelCount().ToString();
            yield return null; // 次のフレームまで待機
        }
    }

    private void LevelScrollBar(int startScore, int endScore, int currentScore)
    {
        levelCountBar.value = (float)(currentScore - startScore) / (float)(endScore - startScore);
    }
}
