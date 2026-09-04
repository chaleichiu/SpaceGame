using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

namespace Objects
{
    /// <summary>
    /// This is a singleton
    /// </summary>
    public class GameManager : MonoBehaviour
    {

        private Weapon peaShooter = new Weapon();

        [Header("Entities")]
        [SerializeField] private GameObject[] enemyPrefab;
        [SerializeField] private Transform[] spawnPoints;

        /// <summary>
        /// Things that affect fun of gameplay.
        /// </summary>
        [Header("Game Variables")]
        [SerializeField] private float enemySpawnRate;
        [SerializeField] private Weapon enemyWeapon = new Weapon("Melee", 1f, 0f,1f);
        [SerializeField] private float powerUpSpawnRate;
        [SerializeField] public AudioClip deathSound;

        [Header("Game Logic Control")]
        private GameObject tempEnemy;
        private bool isEnemySpawning;
        private bool isPowerupSpawning;
        private bool isPlaying;

        public Action OnGameStart;
        public Action OnGameOver;

        [SerializeField] private Player player;
        [SerializeField] private UiManager uiManager;
        public ScoreManager scoreManager;
        public PickupSpawner pickupSpawner;







        #region sudo code
        //Bullet - BulletCount - FireRate
        // public ScoreManager scoreManager;
        // power ups 
        // obstacles - Rocks 
        // Score - ScoreManager -> Enemies destroyed
        // Enemies - > SpawnRate -> EnemyType -> EnemyPrefab -> Bosses.
        // Ui Manager - > GameOverMethod -> GameOverScreen
        // ParticleEffect Manager -> VFX Graph(Isnt supported WebGL) // Optional
        // AnimationManager -> EnemyChange to AttackState -> Enemy turn red.
        // SoundsManager -> 
        #endregion

        #region SingleTon
        public static GameManager instance;

        public static GameManager GetInstance()
        {
            return instance;
        }

        void SetSingleton()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            instance = this;
        }
        #endregion

        private void Awake()
        {
            SetSingleton();
        }

        private void Start()
        {
          StartGame();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void NotifyDeath(Enemy enemy)
        {
            pickupSpawner.SpawnPickup(enemy.transform.position);
        }

        public bool IsPlaying()
        {
            return isPlaying;
        }
        public Player GetPlayer()
        {
            return player;
        }

        public void StartGame()
        {
            isEnemySpawning = true;
            StartCoroutine(EnemySpawner());
            // you create player here
            isPlaying = true;

            //Subscribing to Health OnDeath action
            player.OnDeath += StopGame;
            OnGameStart?.Invoke(); // broadcasts to all objects the game is starting and to call its subscribed methods
        }
        public void StopGame()
        {
            isEnemySpawning = false;
            StartCoroutine(GameStopper());
        }

        IEnumerator GameStopper()
        {
            yield return new WaitForSeconds(2.0f);
            isPlaying = false;
            Enemy[] enemies = UnityEngine.Object.FindObjectsByType<Enemy>(FindObjectsSortMode.None);

            foreach(Enemy item in enemies)
            {
                Destroy(item.gameObject);
            }

            OnGameOver?.Invoke();
        }


        void CreateEnemy()
        {
            int randomInt = UnityEngine.Random.Range(0, 2);
            if (randomInt == 0)
            {
                tempEnemy = Instantiate(enemyPrefab[0]);
                tempEnemy.transform.position = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].position;
                //tempEnemy.GetComponent<Enemy>().weapon = enemyWeapon;
                tempEnemy.GetComponent<MeleeEnemy>().SetMeleeEnemy(2f, 1f, deathSound);
            }
            if (randomInt == 1)
            {
                tempEnemy = Instantiate(enemyPrefab[1]);
                tempEnemy.transform.position = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].position;
                //tempEnemy.GetComponent<Enemy>().weapon = enemyWeapon;
                tempEnemy.GetComponent<MachineGunEnemy>().SetMachineGunEnemy(5f, 1f, deathSound);
            }
        }

        IEnumerator EnemySpawner()
        {
            float rateIncrease = 0.02f;
            float maxSpawnRate = 5.0f;
            while (isEnemySpawning)
            {
                yield return new WaitForSeconds(1.0f / enemySpawnRate);
                CreateEnemy();

                enemySpawnRate = Mathf.Min(maxSpawnRate, enemySpawnRate + rateIncrease);
            }
        }
    }
}
