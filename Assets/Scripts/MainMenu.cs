using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool endless;
    public static MainMenu Instance;
    public void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void LoadScene(bool endless) 
    {
        this.endless = endless;
        SceneManager.LoadScene("SampleScene");
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
