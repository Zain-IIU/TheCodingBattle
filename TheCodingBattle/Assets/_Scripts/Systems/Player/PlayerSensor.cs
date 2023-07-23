using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.Systems.Player
{
    public class PlayerSensor : MonoBehaviour
    {
        [SerializeField] private Transform castingPos;
        [SerializeField] private float castingRadius;
        [SerializeField] private LayerMask switchingLayer;


        private void FixedUpdate()
        {
            CheckForHidingSpot();
        }

        private void CheckForHidingSpot()
        {
            // ReSharper disable once Unity.PreferNonAllocApi
            var hitColliders = Physics.OverlapSphere(castingPos.position, castingRadius, switchingLayer);

            if (hitColliders.Length == 0)
            {
                UtilitySystem.Instance.SetBtnState(false);
                return;
            }

            UtilitySystem.Instance.SetBtnState(true);
        }
    }
}