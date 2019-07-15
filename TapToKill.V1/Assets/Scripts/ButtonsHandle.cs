using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsHandle : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu, gameoverPanel;
    public static bool isPaused;

    private void Start()
    {
        isPaused = false;
        if(pauseMenu != null) pauseMenu.SetActive(false);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseButton()
    {
        if(!gameoverPanel.activeInHierarchy)
        if(pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            isPaused = true;
        } 
    }

    public void SceneLoadButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}