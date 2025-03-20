using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGameButton() {
        SceneManager.LoadSceneAsync("Game");
    }

    public void SettingsButton() {
        SceneManager.LoadSceneAsync("Settings");
    }
    
    public void QuitGame() {
        Application.Quit();
    }
}