using UnityEngine;

namespace Objects
{
    // Abstract classes are a way to structure your project by making a contract to force 
    // inherited objects to implment SOME verison of the abustract method.
    public abstract class PlayableObject : MonoBehaviour, IDamageable
    {
        public Health health = new Health();
        public Weapon weapon;

       [SerializeField] protected string nickName;
        [SerializeField] protected float speed = 3f;


        // virtual keyword allows subclasses to override the method with its own verison if needed.

        public abstract void Move(Vector2 direction, Vector2 target); // this method must be used by inheritated classes
        // prevents red errors.
        public virtual void Move(Vector2 direction) { }
        public virtual void Move(float speed) { }

        public abstract void Shoot();
        public abstract void Nuke();

        public abstract void Attack(float interval);

        public abstract void Die();

        public abstract void GetDamage(float damage);

    }
}
