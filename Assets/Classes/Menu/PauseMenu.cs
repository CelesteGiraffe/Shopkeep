using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame() {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void GoToMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame() {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void OnOptionsPress() {
        SceneManager.LoadScene("PauseMenuOptions");
    }
}
