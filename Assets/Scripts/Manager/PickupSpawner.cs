using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Objects
{
    public class PickupSpawner : MonoBehaviour
    {
        [SerializeField] private PickupSpawn[] pickUps;

        [Range(0, 1)]
        [SerializeField] private float pickupProbability;

        List<Pickup> pickupPool = new List<Pickup>();
        Pickup chosenPickup;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // populate a pool of pickups
            foreach (PickupSpawn spawn in pickUps)
            {
                for (int i = 0; i < spawn.spawnWeight; i++)
                {
                    pickupPool.Add(spawn.pickup);
                }
            }
        }

        public void SpawnPickup(Vector2 position)
        {
            if (pickupPool.Count <= 0)
                return;

            if (Random.Range(0.0f, 1.0f) < pickupProbability)
            {
                chosenPickup = pickupPool[Random.Range(0, pickupPool.Count)];
                Instantiate(chosenPickup, position, Quaternion.identity);
            }
        }
    }

    [System.Serializable]
    public struct PickupSpawn
    {
        public Pickup pickup;
        public int spawnWeight;
    }
}
