using UnityEngine;
using System;

// Spend 10 or so minuites creating inheritance for the sub classes of enemy
// Feel free to add one method to enemy if you need to


namespace Objects
{
    public class MachineGunEnemy : Enemy
    {
        [SerializeField] private float attackRange = 5f;
        [SerializeField] private float attackTime = 0.1f;
        [SerializeField] private EnemyBullet bulletPrefab;
        [SerializeField] private Transform shootSpawn;
        [SerializeField] private string targetTag = "Player";
        [SerializeField] private AudioClip shootingSound;
        private Weapon rangedWeapon = new Weapon("Ranged", 5f, 5f, 2f);

        private float timer = 0f;
        private float setSpeed = 2f;

        protected override void Start()
        {
            base.Start();
            health = new Health(1f, 0f, 1f);
            speed = setSpeed;
            weapon = rangedWeapon;
            timer = attackTime;
            rangedWeapon.enemylaserSound = shootingSound;
        }

        protected override void Update()
        {
            base.Update();

            if (target == null)
                return;

            if (Vector2.Distance(transform.position, target.position) < attackRange)
            {
                setSpeed = 0f;
                speed = 0f;
                rangedWeapon.enemyShoot(bulletPrefab, shootSpawn, targetTag);
            }
            else
            {
                speed = setSpeed;
            }
        }

        public void SetMachineGunEnemy(float _attackRange, float _attackTime, AudioClip _deathSound)
        {
            attackRange = _attackRange;
            attackTime = _attackTime;
            deathSound = _deathSound;
        }

    }
}