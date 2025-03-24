using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private class Timer
    {
        private float elapsedTime = 0f;

        public void UpdateTime()
        {
            elapsedTime += Time.deltaTime;
        }

        public float GetElapsedTime()
        {
            return elapsedTime;
        }
    }

    // 

    private Timer timer = new Timer();
    public Text timerText;

    void Update()
    {
        timer.UpdateTime();

        if (timerText != null)
        {
            timerText.text = "Time: " + timer.GetElapsedTime().ToString("F1"); // "F2" --> Amount of decimals
        }
    }
}
