using _Scripts.Managers;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Profiles
{
    public class DoorSystem : MonoBehaviour
    {
        public enum DoorType
        {
            TriggerBased,
            KeyBased
        }

        [SerializeField] private DoorType doorType;
        [SerializeField] private Transform doorPivot, lockPivot;
        [SerializeField] private float lockPos, openPos, lookPivotNormal, lockPivotOpen;
        [SerializeField] private int totalKeysToUnlock, curPickedKeys;

        private void OnEnable()
        {
            EventsManager.OnKeyPicked += CheckForKeysPicked;
        }

        private void OnDisable()
        {
            EventsManager.OnKeyPicked -= CheckForKeysPicked;
        }

        private void CheckForKeysPicked()
        {
            if (doorType == DoorType.TriggerBased) return;
            curPickedKeys++;
            if (curPickedKeys >= totalKeysToUnlock)
            {
                OpenTheGate();
            }
        }

        private void Start()
        {
            CloseTheGate();
            if (doorType == DoorType.KeyBased)
                lockPivot.gameObject.SetActive(false);
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

        public DoorType GetDoorType() => doorType;
    }
}