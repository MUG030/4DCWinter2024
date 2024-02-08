using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int level = 1;          // 初期レベル
    public int levelCount = 300;    // 初期レベルカウント上限値
    public int totalScoreList;

    // シングルトン化（どこからでもアクセスできるようにする）
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "InGameScene")
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        score = 0;
        totalScoreList = GetTotalScore();
        rewardAchievement = new RewardAchievement();
        Debug.Log("totalScoreList: " + totalScoreList);
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

    public void AddLevel()
    {
        level++;
    }

    public void AddLevelCount(int amount)
    {
        levelCount += amount;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetLevelCount()
    {
        return levelCount;
    }

    private void Update()
    {
        if (isIkuraGetAchievement && SceneManager.GetActiveScene().name == "ClearDemo")
        {
            demo01.SetActive(true);
        }
        else
        {
            demo01.SetActive(false);
        }
    }
}
