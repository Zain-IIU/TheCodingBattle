using _Scripts.Managers;
using TMPro;
using UnityEngine;

namespace _Scripts.Systems.Enemy
{
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField] private Animator enemyAnim;
        [SerializeField] private float totalHealth, curHealth;
        [SerializeField] private Collider enemyCol;
        [SerializeField] private TextMeshProUGUI healthText;
        private static readonly int Die = Animator.StringToHash("Die");

        private void Start()
        {
            curHealth = totalHealth;
            enemyCol = GetComponent<Collider>();
            healthText.text = "Health: " + curHealth;
        }

        public void DecreaseHealth(float amount)
        {
            curHealth -= amount;
            healthText.text = "Health: " + curHealth;
            if (!(curHealth <= 0)) return;
            curHealth = 0;
            healthText.text = "Health: " + curHealth;
            enemyAnim.SetTrigger(Die);
            enemyCol.enabled = false;
            EventsManager.LevelCompleteEvent();
        }
    }
}