using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public void NewGame() {
        SceneManager.LoadScene("Shop");
    }

    public void LoadGame() {
        SceneManager.LoadScene("Shop");
    }

    public void QuitGame() { 
        Application.Quit();
    }

    public void GoToOptions() {
        SceneManager.LoadScene("Options");
    }
}
