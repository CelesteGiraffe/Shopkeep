using UnityEngine;

public class CharacterSelect : MonoBehaviour {

    [SerializeField]
    private UnityEngine.UI.Button CharacterSelectBtn1, CharacterSelectBtn2;
    [SerializeField]
    private string CharacterName1, CharacterName2;
    [SerializeField]
    private int SceneID;

    private void Start() {
        CharacterSelectBtn1.onClick.AddListener(() => SelectCharacter(CharacterName1, SceneID));
        CharacterSelectBtn2.onClick.AddListener(() => SelectCharacter(CharacterName2, SceneID));
    }

    public void SelectCharacter(string characterName, int SceneID) {
        Debug.Log(SceneID + " " + characterName);
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneID);
    }

}
