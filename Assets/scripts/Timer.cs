using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private class Timer
    {
        private float elapsedTime = 0f;
        private float score = 0f;
        private float scorePerSecond = 7f; // Starting Score
        private float nextIncreaseTime = 15f; // Increase time

        public void UpdateTime()
        {
            elapsedTime += Time.deltaTime;
            score += scorePerSecond * Time.deltaTime; 

            if (elapsedTime >= nextIncreaseTime)
            {
                scorePerSecond *= 2; // Rate at 15 seconds
                nextIncreaseTime += 15f;
            }
        }

        public float GetScore()
        {
            return score;
        }
    }

    private Timer timer = new Timer();
    public Text timerText;

    void Update()
    {
        timer.UpdateTime();

        if (timerText != null)
        {
            timerText.text = "Score: " + timer.GetScore().ToString("F0"); // No decimals
        }
    }
}
