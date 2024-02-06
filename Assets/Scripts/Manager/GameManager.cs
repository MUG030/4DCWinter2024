using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    // シングルトン化（どこからでもアクセスできるようにする）
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // 実績に関する処理
    private RewardAchievement rewardAchievement;

    public int  ikuraGetCount,
                gameoverCount,
                clearCount,
                totalScore;

    public bool isIkuraGetAchievement,
                isGameoverAchievement,
                isClearAchievement,
                isTotalScoreAchievement;

    public GameObject demo01,
                      demo02;

    private void Start()
    {
        rewardAchievement = new RewardAchievement();
    }

    public void AddTotalScore(int amount)
    {
        totalScore += amount;
        rewardAchievement.TotalJudge(totalScore);
    }

    public void AddIkuraGetCount()
    {
        ikuraGetCount++;
        rewardAchievement.IkuraJudge(ikuraGetCount);
    }
    
    public void AddScore(int amount)
    {
        score += amount;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }    

    public int GetScore()
    {
        return score;
    }

    private void Update()
    {
        if (isIkuraGetAchievement && SceneManager.GetActiveScene().name == "ClearDemo")
        {
            demo01.SetActive(true);
        }
    }
}
