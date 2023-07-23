using UnityEngine;

namespace _Scripts.Systems.Enemy
{
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField] private Animator enemyAnim;
        [SerializeField] private float totalHealth, curHealth;
        [SerializeField] private Collider enemyCol;
        private static readonly int Die = Animator.StringToHash("Die");

        private void Start()
        {
            curHealth = totalHealth;
            enemyCol = GetComponent<Collider>();
        }

        public void DecreaseHealth(float amount)
        {
            curHealth -= amount;
            if (!(curHealth <= 0)) return;
            enemyAnim.SetTrigger(Die);
            enemyCol.enabled = false;
        }
    }
}