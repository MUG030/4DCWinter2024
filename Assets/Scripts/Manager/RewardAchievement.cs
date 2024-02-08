using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 実績データと実績解除の処理を行うクラス
public class RewardAchievement
{
    private int[] IkuraGetJudge;    // イクラを取得した数の判定
    private int[] TotalScoreJudge;  // 合計スコアの判定
    private int[] TotalClearJudge;  // 合計クリア数の判定
    private int[] TotalDeathJudge;  // 合計死亡数の判定

    /*public RewardAchievement()
    {
        IkuraGetJudge = new int[] {10, 50, 100};       // イクラを取得した数の判定
        TotalScoreJudge = new int[] {1000, 10000, 100000};     // 合計スコアの判定
        TotalClearJudge = new int[] {1, 5, 25};     // 合計クリア数の判定
        TotalDeathJudge = new int[] {1, 5, 25};     // 合計死亡数の判定
    }*/

    public RewardAchievement()
    {
        IkuraGetJudge = new int[3];       // イクラを取得した数の判定
        TotalScoreJudge = new int[4];     // 合計スコアの判定
        TotalClearJudge = new int[4];     // 合計クリア数の判定
        TotalDeathJudge = new int[4];     // 合計死亡数の判定
    }

    public void IkuraJudge(int ikuraCount)
    {
        if (ikuraCount == IkuraGetJudge[0])
        {
            GameManager.instance.isIkuraGetAchievement1 = true;
        } else if (ikuraCount == IkuraGetJudge[1])
        {
            GameManager.instance.isIkuraGetAchievement2 = true;
        } else if (ikuraCount == IkuraGetJudge[2])
        {
            GameManager.instance.isIkuraGetAchievement3 = true;
        }
    }

    public void TotalJudge(int totalScore)
    {
        if (totalScore == TotalScoreJudge[1])
        {
            GameManager.instance.isTotalScoreAchievement1 = true;
        } else if (totalScore == TotalScoreJudge[2])
        {
            GameManager.instance.isTotalScoreAchievement2 = true;
        } else if (totalScore == TotalScoreJudge[3])
        {
            GameManager.instance.isTotalScoreAchievement3 = true;
        }
    }

    public void ClearJudge(int clearCount)
    {
        if (clearCount == TotalClearJudge[1])
        {
            GameManager.instance.isClearAchievement1 = true;
        } else if (clearCount == TotalClearJudge[2])
        {
            GameManager.instance.isClearAchievement2 = true;
        } else if (clearCount == TotalClearJudge[3])
        {
            GameManager.instance.isClearAchievement3 = true;
        }
    }

    public void DeathJudge(int deathCount)
    {
        if (deathCount == TotalDeathJudge[1])
        {
            GameManager.instance.isGameoverAchievement1 = true;
        } else if (deathCount == TotalDeathJudge[2])
        {
            GameManager.instance.isGameoverAchievement2 = true;
        } else if (deathCount == TotalDeathJudge[3])
        {
            GameManager.instance.isGameoverAchievement3 = true;
        }
    }
}
