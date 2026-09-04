using UnityEngine;
using System.Collections;
using System;

namespace Objects
{
    public class GunPickup : Pickup, IDamageable
    {
        [SerializeField] private AudioClip newshootingSound;
        [SerializeField] private AudioClip shootingSound;
        [SerializeField] private AudioClip pickupSound;
        public override void OnPicked()
        {
            base.OnPicked();
            AudioSource.PlayClipAtPoint(pickupSound, new Vector3(0, 0, 0), 1f);
            Player player = GameManager.GetInstance().GetPlayer();
            player.StartCoroutine(ApplyTemporaryWeapon(player));
        }
        IEnumerator ApplyTemporaryWeapon(Player player)
        {
            player.weapon = new Weapon("machine gun", 1, 10, 0.1f);
            player.weapon.laserSound = newshootingSound;

            yield return new WaitForSeconds(5f);

            player.weapon = new Weapon("player gun", 1, 10, 1f);
            player.weapon.laserSound = shootingSound;
        }
        public Action OnPowerUpTimer;
        public static GunPickup instance;
        public static GunPickup GetInstance()
        {
            return instance;
        }
        public void GetDamage(float damage)
        {
            // using the idamageable interface to pick up the powerup with a bullet
            OnPicked();
        }
    }
}