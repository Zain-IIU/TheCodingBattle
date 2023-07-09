using _Scripts.Systems.Enemy;
using UnityEngine;

namespace _Scripts.Systems.Player
{
    public class ProjectileProfile : MonoBehaviour
    {
        [SerializeField] private int power, movePower;
        [SerializeField] private Rigidbody rb;

        public void SetPower(int newPow)
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
                enemySystem.DecreaseHealth(power);
                gameObject.SetActive(false);
            }
        }
    }
}