using UnityEngine;
using System;

namespace Objects
{
    public class Enemy : PlayableObject // (" Is a " relationship) Enemy is a Playable object
    {

        private EnemyType enemyType;
        protected Transform target; // this is currently null because its empty
        public AudioClip deathSound;
        /// <summary>
        /// Finds player dyanmically
        /// </summary>
        protected virtual void Start()
        {
            try
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }catch(NullReferenceException e)
            {
                Debug.Log("Enemy could not find target player " + e);
                Destroy(gameObject);
            }

           
        }

        protected virtual void Update()
        {
            if(target != null) // null check
            {
                // move towards player
                Move(target.position);
            }
            else
            {
                // move forward without target.
                Move(speed);
            }
        }

        public override void Move(Vector2 direction, Vector2 target)
        {
           
        }
        /// <summary>
        /// Moves in a line 
        /// </summary>
        /// <param name="speed"></param>
        public override void Move(float speed)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        /// <summary>
        /// Rotating the enemy to look at the player, then moving in a line.
        /// </summary>
        /// <param name="direction">Where the enemy is moving too.</param>
        public override void Move(Vector2 direction)
        {
            direction.x -= transform.position.x;
            direction.y -= transform.position.y;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, (angle));

            Move(speed);
        }

        public override void Shoot()
        {
           
        }

        public override void Nuke()
        {
            
        }

        public override void GetDamage(float damage)
        {
            health.RemoveHealth(damage);
            if(health.GetHealth() <= 0)
                Die();
        }

        public override void Attack(float interval)
        {
            Debug.Log("Attacking");
        }

        public override void Die()
        {
            Debug.Log("Enemy Died");
            AudioSource.PlayClipAtPoint(deathSound, new Vector3(0, 0, 0), 1f);
            GameManager.GetInstance().NotifyDeath(this);
            Destroy(gameObject);
        }

        public void SetEnemyType(EnemyType enemyType)
        {
            this.enemyType = enemyType;
        }

    }

}
