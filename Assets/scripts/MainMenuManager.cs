using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadScene1()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("GameMode2");
    }
}
