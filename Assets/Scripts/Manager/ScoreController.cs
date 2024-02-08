using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private ScoreView scoreView;

    // Start is called before the first frame update
    void Start()
    {
        InitializeScoreView();
    }

    // ScoreViewの初期化
    private void InitializeScoreView()
    {
        Debug.Log("InitializeScoreViewの呼び出し");
        scoreView = GetComponent<ScoreView>();
        scoreView.UpdateScore(0);
    }

    // スコアを更新し、それをScoreViewに反映
    public void UpdateScoreView(int scoreToAdd)
    {
        GameManager.instance.AddScore(scoreToAdd);
        GameManager.instance.AddTotalScore(scoreToAdd);
        scoreView.UpdateScore(GameManager.instance.GetScore());
    }
}
