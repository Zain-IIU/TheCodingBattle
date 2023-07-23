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
        [SerializeField] private float openPos, closePos;
        [SerializeField] private bool isOpen;

        private void Start()
        {
            switchingText.text = "OPEN";
        }

        public void SetStateOfSystem()
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
        }

        public void SetBtnState(bool val)
        {
            switchingBtn.SetActive(val);
        }
    }
}