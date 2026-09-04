using UnityEngine;
using System;

// Spend 10 or so minuites creating inheritance for the sub classes of enemy
// Feel free to add one method to enemy if you need to


namespace Objects
{
    public class MeleeEnemy : Enemy
    {
        [SerializeField] private float attackRange = 0.5f;
        [SerializeField] private float attackTime = 0.1f;
        [SerializeField] private AudioClip meleeSound;
        private Weapon meleeWeapon = new Weapon("Melee", 50f, 0f, 0f);

        private float timer = 0f;
        private float setSpeed = 3f;

        protected override void Start()
        {
            base.Start();
            health = new Health(2f, 0f, 2f);
            setSpeed = speed;
            weapon = meleeWeapon;
            timer = attackTime;
        }

        protected override void Update()
        {
            base.Update();

            if (target == null)
                return;

            if (Vector2.Distance(transform.position, target.position) < attackRange)
            {
                speed = 0f;
                Attack(attackTime);
            }
            else
            {
                speed = setSpeed;
            }
        }

        public override void Attack(float interval)
        {
            if (timer <= interval)
            {
                timer += Time.deltaTime;
                return;
            }
            else
            {
                timer = 0f;
                var damageable = target.GetComponent<IDamageable>();
                AudioSource.PlayClipAtPoint(meleeSound, new Vector3(0, 0, 0), 1f);
                damageable?.GetDamage(weapon.GetDamage());
            }
        }

        public void SetMeleeEnemy(float _attackRange, float _attackTime, AudioClip _deathSound)
        {
            attackRange = _attackRange;
            attackTime= _attackTime;
            deathSound = _deathSound;
        }

    }
}
