using UnityEngine;

// interfaces link unrealated objects if they have a common method they need to call
// you can inherit multiple interfaces to a single object. Where a class can only inherit one class.
// interfaces can have methods with a body, where abstract classes cannot.

namespace Objects
{
    public interface IDamageable
    {
        void GetDamage(float damage);
    }
}
