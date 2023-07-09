using UnityEngine;

namespace _Scripts.CustomClass
{
    public class PlayerSystemBase : MonoBehaviour
    {
        public virtual void ThrowProjectile()
        {
        }
        public virtual void SetMovement()
        {
        }

        public virtual void IncrementOrDecrementValue(bool toIncrement)
        {
        }

        public virtual void AddPower(bool val)
        {
        }
    }
}