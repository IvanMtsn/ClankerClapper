using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance;

    [SerializeField] int score = 0;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject HealthDisplay;
    [SerializeField] GameObject heart;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject Bloodscreen;

    public float CountdownTimer;
    public int maxHealth;
    private int health;
    [SerializeField] float InvincTime;
    public float InvincTimer { private set; get; }
    public bool displayBlood, endlessMode;

    public TMP_Text timeDisplay;
    public TMP_Text scoreDisplay;

    private RectTransform orgHealthRect;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        orgHealthRect = HealthDisplay.GetComponent<RectTransform>();
        health = maxHealth;
        DisplayHealth();
    }
    void Update()
    {
        if (!endlessMode)
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
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if(SceneManager.GetActiveScene().name == "SampleScene") { Debug.Log("Waha"); }
        else { Debug.Log("nop"); }
        if (MainMenu.Instance.endless)
        {
            GameModeManager.Instance.endlessMode = true;
            GameModeManager.Instance.timeDisplay.gameObject.SetActive(false);
        }
        else
        {
            GameModeManager.Instance.endlessMode = false;
            GameModeManager.Instance.timeDisplay.gameObject.SetActive(true);
        }
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
        SoundManager.instance.PlayScoreSound();
    }

    public void DecreaseScore(int points)
    {
        score -= points;
        scoreDisplay.text = score.ToString();
        SoundManager.instance.PlayFehlerSound();
    }

    public void AddTime(int sek)
    {
        CountdownTimer += sek;
    }

    public async Task LoseHeart(int hearts)
    {
        InvincTimer = InvincTime;
        if (displayBlood) ShowBlood();
        Debug.Log("Aua");
        health -= hearts;
        DisplayHealth();
        if(health <= 0)
        {
            CountdownTimer = 0;
            GameOver();
        }
        while(InvincTimer > 0)
        {
            InvincTimer -= Time.deltaTime;
            await Task.Yield();
        }
    }

    private async void ShowBlood()
    {
        Color imgCol = Bloodscreen.GetComponent<Image>().color;
        imgCol = new Color(imgCol.r, imgCol.g, imgCol.b, 1f);
        Bloodscreen.GetComponent<Image>().color = imgCol;

        while (InvincTimer > 0)
        {
            imgCol = new Color(imgCol.r, imgCol.g, imgCol.b, InvincTimer / InvincTime);
            Bloodscreen.GetComponent<Image>().color = imgCol;
            await Task.Yield();
        }
        imgCol = new Color(imgCol.r, imgCol.g, imgCol.b, 0f);
        Bloodscreen.GetComponent<Image>().color = imgCol;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        InvincTimer = 0f;
        Debug.Log("Game is over!");
        List<EnemyDroid> allBots = GameObject.FindObjectsByType<EnemyDroid>(FindObjectsSortMode.None).ToList<EnemyDroid>();
        spawner.GetComponent<EnemySpawner>().CanSpawnEnemies = false;
        foreach (EnemyDroid enemy in allBots)
        {
            StartCoroutine("DeactivateBot", enemy);
        }
        gameOverUI.SetActive(true);
        Debug.Log($"Your Score: {score}");
    }

    public IEnumerator DeactivateBot(EnemyDroid enemy)
    {
        enemy.enabled = false;
        enemy.gameObject.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(5);
        enemy.gameObject.SetActive(false);
    }

    public void DisplayHealth()
    {
        RectTransform HealthRect = HealthDisplay.GetComponent<RectTransform>();
        HealthRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, orgHealthRect.sizeDelta.y);
        foreach (Transform t in HealthDisplay.transform)
        {
            Destroy(t.gameObject);
        }

        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newHeart = Instantiate(heart);
            RectTransform rect = newHeart.GetComponent<RectTransform>();
            rect.SetParent(HealthDisplay.transform, false);
            rect.localScale = Vector3.one;
            if(i+1 > health)
            {
                Color color = newHeart.GetComponent<Image>().color;
                color = new Color(color.r, color.g, color.b, 0.5f);
                newHeart.GetComponent<Image>().color = color;
            }
        }
    }
}
