using UnityEngine;
using UnityEngine.UI;

public class LoseScreenManager : MonoBehaviour
{
    public Text finalScoreText; 

    void Start()
    {
        // retrieve final score, if not found, default to 0
        float finalScore = PlayerPrefs.GetFloat("finalScore", 0f);

        // update text component
        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + finalScore.ToString("F0");
        }
    }
}
