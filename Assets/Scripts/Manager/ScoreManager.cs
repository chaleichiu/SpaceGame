using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace Objects
{
    public class ScoreManager : MonoBehaviour
    {
        private int score;
        private int highScore;

        public UnityEvent OnScoreUpdate;
        public UnityEvent OnHighScoreUpdate;

        private Player player;

        private void Start()
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            player = GameManager.GetInstance().GetPlayer();
            OnHighScoreUpdate?.Invoke();
            GameManager.GetInstance().OnGameStart += OnGameStart;
        }
        public void SetHighScore()
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        public void OnGameStart()
        {
            player.OnDeath += SetHighScore;
            score = 0;
        }
        public int GetScore()
        {
            return score;
        }
        public int GetHighScore()
        {
            return highScore;
        }
        public void IncrementScore()
        {
            score++;
            OnScoreUpdate?.Invoke();

            if (score > highScore)
            {
                highScore= score;
                OnHighScoreUpdate?.Invoke();
            }
        }
    }
}
