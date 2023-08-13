using _Scripts.Systems.Enemy;
using UnityEngine;

namespace _Scripts.Systems.Player
{
    public class ProjectileProfile : MonoBehaviour
    {
        [SerializeField] private float power, movePower;
        [SerializeField] private Rigidbody rb;

        public void SetPower(float newPow)
        {
            power = newPow;
        }
        

        public void Throw()
        {
            rb.AddForce(Vector3.forward * movePower, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemySystem enemySystem))
            {
                print(power);
                enemySystem.DecreaseHealth(power);
                gameObject.SetActive(false);
            }
        }
    }
}