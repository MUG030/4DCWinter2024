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
        scoreView = GetComponent<ScoreView>();
        UpdateScoreView(GameManager.instance.GetScore());
    }

    // スコアを更新し、それをScoreViewに反映
    public void UpdateScoreView(int scoreToAdd)
    {
        GameManager.instance.AddScore(scoreToAdd);
        scoreView.UpdateScore(GameManager.instance.GetScore());
    }
}
