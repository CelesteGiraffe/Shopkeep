using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuScript : MonoBehaviour {

    public UnityEngine.UI.Button CharacterSelectBtn1;
    public UnityEngine.UI.Button CharacterSelectBtn2;
    private void Start() {
        CharacterSelectBtn1.onClick.AddListener(() => SelectCharacter("Character1", 2));
        CharacterSelectBtn2.onClick.AddListener(() => SelectCharacter("Character2", 2));
    }

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
    
    public void SelectCharacter(string characterName , int SceneID) {
        Debug.Log(SceneID + " " + characterName);
        SceneManager.LoadScene(SceneID);
    }
}
