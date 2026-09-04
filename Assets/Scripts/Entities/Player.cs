using UnityEngine;
using System;
// In OOP there is 4 types of relationships
// inheritance , assoication, aggregation, composition
// "is a" , "knows of" , "has a", "part of"

namespace Objects
{
    [DefaultExecutionOrder(-10)]
    public class Player : PlayableObject // (Is a relationship) Player is a Playable object
    {
        [SerializeField] private Camera cam;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float weaponDamage = 1;
        [SerializeField] private float bulletSpeed = 10;
        [SerializeField] private Transform shootSpawn;
        [SerializeField] private string targetTag = "Enemy";

        [SerializeField] private AudioClip shootingSound;
        [SerializeField] private AudioClip nukeSound;

        public float nukeCount = 0;
        public float tempHealth;

        public Action OnDeath;


        private Rigidbody2D playerRB;

       [SerializeField] private UiManager uiManager;

        private void Start()
        {
            health = new Health(100, 0.5f);
            playerRB = GetComponent<Rigidbody2D>();
            weapon = new Weapon("Player Weapon", weaponDamage, bulletSpeed, 1f);
            weapon.laserSound = shootingSound; 
        }

        public override void Move(Vector2 direction, Vector2 target)
        {
            // 15mins, see if you can get the Rigidbody moving based on direction input
            // and if you get that done try to have the rigidbody look at the mouse/target

            playerRB.linearVelocity = direction * speed; // time is that it isnt going every frame

            Vector3 playerScreenPos = cam.WorldToScreenPoint(transform.position);
            target.x -= playerScreenPos.x;
            target.y -= playerScreenPos.y;

            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f,0f,(angle-90f));
        }

        public override void Shoot()
        {
            weapon.Shoot(bulletPrefab,shootSpawn,targetTag);
        }

        public override void Nuke()
        {
            if (nukeCount > 0)
            {
                Enemy[] enemies = UnityEngine.Object.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
                Pickup[] pickups = UnityEngine.Object.FindObjectsByType<Pickup>(FindObjectsSortMode.None);

                foreach (Enemy item in enemies)
                {
                    Destroy(item.gameObject);

                }

                foreach (Pickup pickup in pickups)
                {
                    Destroy(pickup.gameObject);
                }
                AudioSource.PlayClipAtPoint(nukeSound, new Vector3(0, 0, 0), 1f);
                nukeCount -= 1;
            }
        }

        public override void Die()
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }

        public override void Attack(float interval)
        {
            //this is here because the enemys need to attack,
            // and the abstract method needs to be here because contract 
            // This will do nothing, and that is fine. It prevents red errors.
        }

        public override void GetDamage(float damage)
        {
            health.RemoveHealth(damage);
            if(health.GetHealth() <= 0)
                Die();
        }
    }

}
