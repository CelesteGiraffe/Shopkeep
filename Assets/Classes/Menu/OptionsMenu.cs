using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void MasterVolume(float volume) {
        Debug.Log("Master Volume: " + volume);
    }

    public void MusicVolume(float volume) {
        Debug.Log("Music Volume: " + volume);
    }

    public void OnExitPress() {
        Debug.Log("Back to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }
}
