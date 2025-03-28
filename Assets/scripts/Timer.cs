using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    private class Timer
    {
        private float elapsedTime = 0f;
        private float score = 0f;
        private float scorePerSecond = 7f; 
        private float nextIncreaseTime;

        public Timer(int diff) 
        {
            // set nextincreasetime based on difficulty
            if (diff == 0) {
                nextIncreaseTime = 35f;  // Easy
            } else if (diff == 1) {
                nextIncreaseTime = 21f;  // Med
            } else {
                nextIncreaseTime = 8.5f;  // Hard
            }
        }

        public void UpdateTime()
        {
            elapsedTime += Time.deltaTime;
            score += scorePerSecond * Time.deltaTime; 

            if (elapsedTime >= nextIncreaseTime)
            {
                scorePerSecond *= 2; 
                nextIncreaseTime += nextIncreaseTime;  // keep increasing based on itself
            }
        }

        public float GetScore()
        {
            return score;
        }
    }

    private Timer timer;  
    public Text timerText;

    private PlayerMovement playerMovement;

    void Start()
    {
        // get difficulty
        int diff = PlayerPrefs.GetInt("difficulty", 1); 

        // initialize timer
        timer = new Timer(diff);

        // get pm component to check health
        GameObject playerObj = GameObject.FindGameObjectWithTag("User");
        if (playerObj != null)
        {
            playerMovement = playerObj.GetComponent<PlayerMovement>();
        }
    }

    void Update()
    {
        timer.UpdateTime();
        if (timerText != null)
        {
            timerText.text = "Score: " + timer.GetScore().ToString("F0");
        }

        // check player health using the health bar in pm
        if (playerMovement != null && playerMovement.healthBar != null && playerMovement.player.GetHealth() <= 0)
        {
            // save the final score 
            float finalScore = timer.GetScore();
            PlayerPrefs.SetFloat("finalScore", finalScore);
            PlayerPrefs.Save();

            // load the lose screen scene
            SceneManager.LoadScene("Lose Screen");
        }
    }
}
