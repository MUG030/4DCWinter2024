using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    private int level = 1;          // 初期レベル
    public int levelCount = 7000;    // 初期レベルカウント上限値
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
    public bool isFortune;
    public bool secretComand;
    public bool ikuraZero;

    

    public GameObject[] achivements;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private List<KeyCode> konamiCode = new List<KeyCode> { KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A };
    private int konamiCodeIndex = 0;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(konamiCode[konamiCodeIndex]))
            {
                konamiCodeIndex++;
                if (konamiCodeIndex >= konamiCode.Count)
                {
                    Debug.Log("Secret Command!");
                    secretComand = true;
                    konamiCodeIndex = 0;
                }
            }
            else
            {
                konamiCodeIndex = 0;
            }
        }
    }

    /*private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }*/
    public GameObject activeObject;

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "InGameScene" || scene.name == "MUGScene")
        {
            StartGame();
        }

        if (scene.name == "ClearScene" || scene.name == "ClearDemo")
        {
            activeObject.SetActive(true);
            if (isGameoverAchievement1)
            {
                achivements[0].SetActive(true);
            }
            else
            {
                achivements[0].SetActive(false);
            }

            if (isGameoverAchievement2)
            {
                achivements[1].SetActive(true);
            }
            else
            {
                achivements[1].SetActive(false);
            }
            
            if (isGameoverAchievement3)
            {
                achivements[2].SetActive(true);
            }
            else
            {
                achivements[2].SetActive(false);
            }

            if (isIkuraGetAchievement1)
            {
                achivements[3].SetActive(true);
            }
            else
            {
                achivements[3].SetActive(false);
            }

            if (isIkuraGetAchievement2)
            {
                achivements[4].SetActive(true);
            }
            else
            {
                achivements[4].SetActive(false);
            }

            if (isIkuraGetAchievement3)
            {
                achivements[5].SetActive(true);
            }
            else
            {
                achivements[5].SetActive(false);
            }

            if (isClearAchievement1)
            {
                achivements[6].SetActive(true);
            }
            else
            {
                achivements[6].SetActive(false);
            }  

            if (isClearAchievement2)
            {
                achivements[7].SetActive(true);
            }
            else
            {
                achivements[7].SetActive(false);
            }

            if (isClearAchievement3)
            {
                achivements[8].SetActive(true);
            }
            else
            {
                achivements[8].SetActive(false);
            }

            if (isTotalScoreAchievement1)
            {
                achivements[9].SetActive(true);
            }
            else
            {
                achivements[9].SetActive(false);
            }

            if (isTotalScoreAchievement2)
            {
                achivements[10].SetActive(true);
            }
            else
            {
                achivements[10].SetActive(false);
            }

            if (isTotalScoreAchievement3)
            {
                achivements[11].SetActive(true);
            }
            else
            {
                achivements[11].SetActive(false);
            }

            if (isFallDead)
            {
                achivements[12].SetActive(true);
            }
            else
            {
                achivements[12].SetActive(false);
            }

            if (secretComand)
            {
                achivements[13].SetActive(true);
            }
            else
            {
                achivements[13].SetActive(false);
            }

            if (isFortune)
            {
                achivements[15].SetActive(true);
            }
            else
            {
                achivements[15].SetActive(false);
            }

            if (ikuraZero)
            {
                achivements[14].SetActive(true);
            }
            else
            {
                achivements[14].SetActive(false);
            }
        }
        else
        {
            activeObject.SetActive(false);
        }
    }

    private void StartGame()
    {
        score = 0;
        totalScoreList = GetTotalScore();
        int fortune = UnityEngine.Random.Range(0, 100);
        if (fortune == 77)
        {
            isFortune = true;
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

    public void AddDeadCount()
    {
        gameoverCount++;
        rewardAchievement.DeathJudge(gameoverCount);
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
