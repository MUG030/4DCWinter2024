using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 実績データと実績解除の処理を行うクラス
public class RewardAchievement
{
    int IkuraGetJudge = 2;

    int TotalScoreJudge = 500;

    public void IkuraJudge(int ikuraCount)
    {
        if (ikuraCount == IkuraGetJudge)
        {
            GameManager.instance.isIkuraGetAchievement = true;
            Debug.Log("イクラゲット実績解除");
        }
    }

    public void TotalJudge(int totalScore)
    {
        if (totalScore == TotalScoreJudge)
        {
            GameManager.instance.isTotalScoreAchievement = true;
            Debug.Log("スコア500点達成実績解除");
        }
    }
}
