using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance;
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
}
