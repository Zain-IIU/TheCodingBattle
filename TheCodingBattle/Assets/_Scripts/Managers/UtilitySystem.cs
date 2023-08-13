using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Scripts.Managers
{
    public class UtilitySystem : MonoBehaviour
    {
        public static UtilitySystem Instance;

        private void Awake()
        {
            Instance = this;
        }

        [SerializeField] private GameObject switchingBtn;
        [SerializeField] private TextMeshProUGUI switchingText;
        [SerializeField] private Transform bridgePivot;
        [SerializeField] private GameObject invisibleCol;
        [SerializeField] private float openPos, closePos;
        [SerializeField] private bool isOpen,isKeyBased;

        private bool _gotKey;
        private void Start()
        {
            switchingText.text = "OPEN";
            invisibleCol.SetActive(true);
        }
        
        public void SetStateOfSystem()
        {
            if(!isKeyBased)
            {
                isOpen = !isOpen;
                if (isOpen)
                {
                    bridgePivot.DOLocalMoveY(openPos, .5f).SetEase(Ease.InSine);
                    switchingText.text = "CLOSE";
                }
                else
                {
                    bridgePivot.DOLocalMoveY(closePos, .5f).SetEase(Ease.InSine);
                    switchingText.text = "OPEN";
                }
                invisibleCol.SetActive(!isOpen);
            }
            else
            {
                if(!_gotKey) return;
                isOpen = !isOpen;
                if (isOpen && _gotKey)
                {
                    bridgePivot.DOLocalMoveY(openPos, .5f).SetEase(Ease.InSine);
                    switchingText.text = "CLOSE";
                }
                else
                {
                    bridgePivot.DOLocalMoveY(closePos, .5f).SetEase(Ease.InSine);
                    switchingText.text = "OPEN";
                }
                invisibleCol.SetActive(!isOpen);
            }
        }

        public void SetBtnState(bool val)
        {
            switchingBtn.SetActive(val);
        }

        private void OnEnable()
        {
            EventsManager.OnKeyPicked += SetKeyToActive;
        }

        private void OnDisable()
        {
            EventsManager.OnKeyPicked -= SetKeyToActive;   
        }

        private void SetKeyToActive()
        {
            if (isKeyBased)
                _gotKey = true;
        }
    }
}