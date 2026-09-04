using UnityEngine;

namespace Objects
{
    public abstract class Pickup : MonoBehaviour
    {
        public virtual void OnPicked()
        {

            Destroy(gameObject);
        }
    }
}
