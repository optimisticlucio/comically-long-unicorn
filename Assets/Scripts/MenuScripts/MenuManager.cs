using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{

    [SerializeField] private string newGameLevel = "testScene1";

    public void StartGame()
    {
        Debug.Log("Start Game Clicked!");
        SceneManager.LoadScene(newGameLevel);
    }

    public void OpenSettings()
    {
        Debug.Log("Settings Clicked!");
    }

    public void OpenInfo()
    {
        Debug.Log("Info Clicked!");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game Clicked!");
        Application.Quit();
    }
}
