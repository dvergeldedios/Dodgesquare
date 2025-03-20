using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void BackButtonMenuGame()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

}
