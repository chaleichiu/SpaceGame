using TMPro;
using UnityEngine;

namespace Objects
{
    public class NukePickup : Pickup, IDamageable
    {
        [SerializeField] private AudioClip pickupSound;
        public override void OnPicked()
        {
            base.OnPicked();
            AudioSource.PlayClipAtPoint(pickupSound, new Vector3(0, 0, 0), 1f);
            Player player = GameManager.GetInstance().GetPlayer();
            player.nukeCount++;

            Debug.Log("nuke added to inventory");
        }

        public void GetDamage(float damage)
        {
            // using the idamageable interface to pick up the powerup with a bullet
            OnPicked();
        }
    }
}
