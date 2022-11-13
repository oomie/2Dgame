using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    public void BacktoMainScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

