using _Scripts.CustomClass;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Scripts.Systems.Player
{
    public class PlayerProjectileSystem : PlayerSystemBase
    {
        [SerializeField] protected Animator playerAnim;
        [SerializeField] private ProjectileProfile projectilePrefab;
        [SerializeField] private Transform spawnPos;
        [SerializeField] private int throwPower, incrementingValue, addingOffset, minPower, maxPower;
        [SerializeField] private TextMeshProUGUI curIncrementingValText, curPowerTxt;
        private static readonly int Attack = Animator.StringToHash("Attack");

        private void Start()
        {
            curIncrementingValText.text = incrementingValue.ToString();
            curPowerTxt.text = throwPower.ToString();
        }

        public override void ThrowProjectile()
        {
            playerAnim.SetTrigger(Attack);
            DOVirtual.DelayedCall(.5f, () =>
            {
                var projectile = Instantiate(projectilePrefab, spawnPos.position, Quaternion.identity);
                projectile.SetPower(throwPower);
                projectile.Throw();
            });
        }

        public override void IncrementOrDecrementValue(bool toIncrement)
        {
            if (toIncrement)
            {
                incrementingValue += addingOffset;
                if (incrementingValue > 10)
                    incrementingValue = 10;
            }
            else
            {
                incrementingValue -= addingOffset;
                if (incrementingValue < 0)
                    incrementingValue = 0;
            }

            curIncrementingValText.text = incrementingValue.ToString();
        }

        public override void AddPower(bool val)
        {
            if (val)
            {
                throwPower += incrementingValue;
                if (throwPower > maxPower)
                    throwPower = maxPower;
            }
            else
            {
                throwPower -= incrementingValue;
                if (throwPower < minPower)
                    throwPower = minPower;
            }

            curPowerTxt.text = throwPower.ToString();
        }
    }
}