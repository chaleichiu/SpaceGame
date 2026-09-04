using UnityEngine;
using TMPro;

namespace Objects
{
    [DefaultExecutionOrder(-9)]
    public class UiManager : MonoBehaviour
    {
        [Header("GamePlay")]
        [SerializeField] private TMP_Text txtHealth;
        [SerializeField] private TMP_Text txtScore;
        [SerializeField] private TMP_Text txtHighScore;
        [SerializeField] private TMP_Text txtNukeCount;

        [Header("Menu")]
        [SerializeField] private GameObject menuObj;
        [SerializeField] private GameObject gameoverObj;
        [SerializeField] private GameObject newgameObj;
        [SerializeField] private GameObject powerupTimer;
        [SerializeField] private AudioClip failSound;

        private Player player;
        private ScoreManager scoreManager;


        private void Start()
        {
            scoreManager = GameManager.GetInstance().scoreManager;

            GameManager.GetInstance().OnGameStart += GameStarted;
            GameManager.GetInstance().OnGameOver += GameOver;
            GunPickup.GetInstance().OnPowerUpTimer += PowerUpTimer;
        }

        public void GameStarted()
        {
            Debug.Log("GameStarted - UiManager");
            menuObj.SetActive(false);
            gameoverObj.SetActive(false);
            player = GameManager.GetInstance().GetPlayer();
            player.health.OnHealthUpdate += UpdateHealth;
            UpdateHealth(player.health.GetHealth());
        }
        public void FixedUpdate()
        {
            UpdateNukeCount();
        }
        public void UpdateScore()
        {
            txtScore.SetText("Score: " + scoreManager.GetScore().ToString());
        }
        public void UpdateHighScore()
        {
            txtHighScore.SetText("Game Over \n Highscore: " + scoreManager.GetHighScore().ToString());
        }

        public void UpdateNukeCount()
        {
            txtNukeCount.SetText("Nuke: " + player.nukeCount.ToString());
        }

        public void GameOver()
        {
            menuObj.SetActive(true);
            gameoverObj.SetActive(true);
            newgameObj.SetActive(true);
            AudioSource.PlayClipAtPoint(failSound, new Vector3(0, 0, 0), 1f);

        }

        public void PowerUpTimer()
        {
            if (powerupTimer != null)
            {
                powerupTimer.SetActive(true);
            }
        }

        public void UpdateHealth(float currentHealth)
        {
            int roundedValue = Mathf.RoundToInt(currentHealth);
            txtHealth.SetText(roundedValue.ToString());
        }
    }
}
