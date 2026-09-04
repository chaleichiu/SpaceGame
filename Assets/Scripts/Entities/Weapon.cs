using UnityEngine;

namespace Objects
{
    public class Weapon
    {
        private string name;
        private float damage;
        private float bulletSpeed;

        private float fireRate = 1f;
        private float nextFireTime = 0f;
        public AudioClip laserSound;
        public AudioClip enemylaserSound;
        public Weapon(string _name, float _damage, float _bulletSpeed, float _fireRate)
        {
            name = _name;
            damage = _damage;
            bulletSpeed = _bulletSpeed;
            fireRate = _fireRate;
        }

        public Weapon() { }

        public void Shoot(Bullet _bullet, Transform _shootPositon, string _targetTag)
        {
            if (Time.time < nextFireTime)
            {
                return; 
            }
            nextFireTime = Time.time + fireRate;

            Debug.Log("Shooting from Weapon");

            Bullet tempBullet = GameObject.Instantiate(_bullet, _shootPositon.position, _shootPositon.rotation);
            tempBullet.SetBullet(damage, _targetTag, bulletSpeed);
            AudioSource.PlayClipAtPoint(laserSound, new Vector3 (0,0,0), 1f);
        }
        public void enemyShoot(EnemyBullet _bullet, Transform _shootPositon, string _targetTag)
        {
            if (Time.time < nextFireTime)
            {
                return;
            }
            nextFireTime = Time.time + fireRate;

            Debug.Log("Shooting from Weapon");

            EnemyBullet tempBullet = GameObject.Instantiate(_bullet, _shootPositon.position, _shootPositon.rotation);
            tempBullet.SetBullet(damage, _targetTag, bulletSpeed);
            AudioSource.PlayClipAtPoint(enemylaserSound, new Vector3(0, 0, 0), 1f);
        }

        public float GetDamage()
        {
            return damage;
        }
    }

}
