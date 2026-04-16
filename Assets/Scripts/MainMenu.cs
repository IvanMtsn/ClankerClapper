using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool endless2;
    public static MainMenu Instance;
    public void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void LoadScene(bool endless) 
    {
        endless2 = endless;
        if(endless)
        {
        SceneManager.LoadScene("GameMode2");
        }
        else
        {
        SceneManager.LoadScene("SampleScene");
        }
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
