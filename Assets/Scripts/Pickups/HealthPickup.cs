using UnityEngine;

namespace Objects
{
    public class HealthPickup : Pickup, IDamageable
    {
        [SerializeField] private float healthMin = 5f;
        [SerializeField] private float healthMax = 20f;
        [SerializeField] private AudioClip pickupSound;

        public override void OnPicked()
        {
            base.OnPicked();
            AudioSource.PlayClipAtPoint(pickupSound, new Vector3(0, 0, 0), 1f);
            float health = Random.Range(healthMin, healthMax);
            Player player = GameManager.GetInstance().GetPlayer();
            player.health.AddHealth(health);

            Debug.Log("health added to player " + health);
        }

        public void GetDamage(float damage)
        {
            // using the idamageable interface to pick up the powerup with a bullet
            OnPicked();
        }
    }
}
