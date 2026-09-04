using UnityEngine;

namespace Objects
{
    public class EnemyBullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        [SerializeField] AudioClip damageSound;

        private string targetTag;

        public void SetBullet(float _damage, string _targetTag, float _speed = 10)
        {
            this.damage = _damage;
            this.speed = _speed;
            this.targetTag = _targetTag;
        }

        private void Start()
        {
            SetBullet(20, "Player");
            Invoke("DestroyObject", 5f);
        }

        private void Update()
        {
            Move();
        }

        void DestroyObject()
        {
            Destroy(gameObject);
        }

        void Move()
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        // comeback with gamemanager
        void Damage(IDamageable damageable)
        {
            if (damageable != null)
            {
                Debug.Log("Damged something!");
                damageable.GetDamage(damage);
                AudioSource.PlayClipAtPoint(damageSound, new Vector3(0, 0, 0), 1f);
                Destroy(gameObject); // destory bullet
            }
            else
            {
                // do nothing
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.gameObject.name);

            if (!collision.gameObject.CompareTag(targetTag))  // Oneline if statments have scope, do not need {}
                return;//

            IDamageable damageable = collision.GetComponent<IDamageable>();
            Damage(damageable);
        }

    }

}
