using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void SetMasterVolume(float volume) {
        Debug.Log("Master Volume: " + volume);
    }

    public void SetMusicVolume(float volume) {
        Debug.Log("Music Volume: " + volume);
    }

    public void FullscreenToggle(bool isFullscren) {
        decimal isFullscreenDecimal = isFullscren ? 1 : 0;
        Debug.Log("Fullscreen: " + isFullscreenDecimal);
    }

    public void OnExitPress() {
        Debug.Log("Back to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }
}
