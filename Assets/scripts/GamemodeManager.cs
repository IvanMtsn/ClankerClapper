using UnityEngine;
using UnityEngine.SceneManagement;

enum ActiveGameMode
{
    None,
    ScoreMode
}
public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance;
    ActiveGameMode _activeGameMode;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if(SceneManager.GetActiveScene().name == "SampleScene") { _activeGameMode = ActiveGameMode.ScoreMode; }
        else { _activeGameMode=ActiveGameMode.None; }
    }
    void Update()
    {
        switch (_activeGameMode)
        {
            case ActiveGameMode.ScoreMode: ScoreMode();
                break;
            default: return;
        }
    }
    void ScoreMode()
    {
        Debug.Log("Waha");
    }
}
