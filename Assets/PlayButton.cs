using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayButtonGame()
    {
        SceneManager.LoadSceneAsync("Game Menu");
    }

    public void SettingsButtonGame()
    {
        SceneManager.LoadSceneAsync("Settings Menu");
    } 
}
