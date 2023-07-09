using DG.Tweening;
using UnityEngine;

namespace _Scripts.Profiles
{
    public class DoorSystem : MonoBehaviour
    {
        [SerializeField] private Transform doorPivot, lockPivot;
        [SerializeField] private float lockPos, openPos, lookPivotNormal, lockPivotOpen;

        private void Start()
        {
            CloseTheGate();
        }

        public void OpenTheGate()
        {
            lockPivot.DOLocalMoveY(lockPivotOpen, .25f);
            doorPivot.DOLocalMoveY(openPos, .5f);
        }

        public void CloseTheGate()
        {
            lockPivot.DOLocalMoveY(lookPivotNormal, .25f);
            doorPivot.DOLocalMoveY(lockPos, .5f);
        }
    }
}