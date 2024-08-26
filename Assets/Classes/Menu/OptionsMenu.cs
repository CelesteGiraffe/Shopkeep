using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public void SetMasterVolume(float volume) {
        audioMixer.SetFloat("MasterVolume", volume);
        Debug.Log("Master Volume: " + volume);
    }

    public void SetMusicVolume(float volume) {
        audioMixer.SetFloat("MusicVolume", volume);
        Debug.Log("Music Volume: " + volume);
    }

    public void FullscreenToggle(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen: " + isFullscreen);
    }

    public void OnExitPress(int sceneID) {
        SceneManager.LoadScene(sceneID);
        Debug.Log("Back to Main Menu");
    }
}
