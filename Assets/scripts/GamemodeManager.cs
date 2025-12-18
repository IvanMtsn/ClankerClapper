using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance;

    [SerializeField] int score = 0;
    [SerializeField] GameObject gameOverUI;

    public float CountdownTimer;
    public int health;

    public TMP_Text timeDisplay;
    public TMP_Text scoreDisplay;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        if (CountdownTimer > 0)
        {
            CountdownTimer -= Time.deltaTime;
        }
        if (CountdownTimer < 0)
        {
            GameOver();
            CountdownTimer = 0;
        }
        timeDisplay.text = Mathf.RoundToInt(CountdownTimer).ToString();
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if(SceneManager.GetActiveScene().name == "SampleScene") { Debug.Log("Waha"); }
        else { Debug.Log("nop"); }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreDisplay.text = score.ToString();
    }

    public void DecreaseScore(int points)
    {
        score -= points;
        scoreDisplay.text = score.ToString();
    }

    public void AddTime(int sek)
    {
        CountdownTimer += sek;
    }

    public void LoseHeart(int hearts)
    {
        health -= hearts;
        if(health == 0)
        {
            CountdownTimer = 0;
            GameOver();
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        Debug.Log("Game is over!");
        List<EnemyDroid> allBots = GameObject.FindObjectsByType<EnemyDroid>(FindObjectsSortMode.None).ToList<EnemyDroid>();
        foreach (EnemyDroid enemy in allBots)
        {
            enemy.enabled = false;
            enemy.gameObject.SetActive(false);
            //enemy.gameObject.GetComponent<Rigidbody>().useGravity = true;

        }
        gameOverUI.SetActive(true);
        Debug.Log($"Your Score: {score}");
    }
}
