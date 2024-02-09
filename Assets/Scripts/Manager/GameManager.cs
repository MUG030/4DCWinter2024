using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
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
        rewardAchievement = new RewardAchievement();
        StartGame();
    }

    // 実績に関する処理
    private RewardAchievement rewardAchievement;

    public int  ikuraGetCount,
                clearCount,
                gameoverCount,
                totalScore;

    public bool isIkuraGetAchievement1,
                isIkuraGetAchievement2,
                isIkuraGetAchievement3;
    public bool isGameoverAchievement1,
                isGameoverAchievement2,
                isGameoverAchievement3;
                
    public bool isClearAchievement1,
                isClearAchievement2,
                isClearAchievement3;
    
    public bool isTotalScoreAchievement1,
                isTotalScoreAchievement2,
                isTotalScoreAchievement3;

    public bool isFallDead;

    

    public GameObject[] achivements;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /*private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }*/

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "InGameScene" || scene.name == "MUGScene")
        {
            StartGame();
        }

        if (scene.name == "ClearScene" || scene.name == "ClearDemo")
        {
            if (isIkuraGetAchievement1)
            {
                achivements[0].SetActive(true);
            }
            else
            {
                achivements[0].SetActive(false);
            }
        }
    }

    private void StartGame()
    {
        score = 0;
        totalScoreList = GetTotalScore();
        int fortune = UnityEngine.Random.Range(0, 100);
        if (fortune == 77)
        {
            Debug.Log("運が良い");
        }
    }

    public void FallDead()
    {
        isFallDead = true;
    }

    public void AddTotalScore(int amount)
    {
        totalScore += amount;
    }

    public void AddIkuraGetCount()
    {
        ikuraGetCount++;
        rewardAchievement.IkuraJudge(ikuraGetCount);
    }

    public void AddClearCount()
    {
        clearCount++;
        rewardAchievement.ClearJudge(clearCount);
    }

    public void AddGameoverCount()
    {
        gameoverCount++;
        rewardAchievement.DeathJudge(gameoverCount);
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
        rewardAchievement.LevelJudge(level);
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

    /*private void Update()
    {
        if (!(SceneManager.GetActiveScene().name == "ClearScene" || SceneManager.GetActiveScene().name == "ClearDemo"))
        {
            return;
        }
        if (isIkuraGetAchievement)
        {
            achivements[1].SetActive(true);
        }
        else
        {
            achivements[1].SetActive(false);
        }
    }*/
}
