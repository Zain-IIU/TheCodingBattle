using UnityEngine;

namespace _Scripts.Systems.Enemy
{
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField] private Animator enemyAnim;
        [SerializeField] private int totalHealth, curHealth;
        private static readonly int Die = Animator.StringToHash("Die");

        private void Start()
        {
            curHealth = totalHealth;
        }

        public void DecreaseHealth(int amount)
        {
            curHealth -= amount;
            if (curHealth <= 0)
                enemyAnim.SetTrigger(Die);
        }
    }
}