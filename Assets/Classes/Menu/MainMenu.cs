using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public void NewGame(int sceneID) {
        SceneManager.LoadScene(sceneID);
    }

    public void LoadGame(int sceneID) {
        SceneManager.LoadScene(sceneID);
    }

    public void QuitGame() { 
        Application.Quit();
    }

    public void GoToOptions(int sceneID) {
        SceneManager.LoadScene(sceneID);
    }

    public void GoToMainMenu(int sceneID) {
        SceneManager.LoadScene(sceneID);
    }
}
