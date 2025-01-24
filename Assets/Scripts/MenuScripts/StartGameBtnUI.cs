using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class StartGameBtnUI : MonoBehaviour
{

    [SerializeField] private string newGameLevel = "TestSecene";

    public void newGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
