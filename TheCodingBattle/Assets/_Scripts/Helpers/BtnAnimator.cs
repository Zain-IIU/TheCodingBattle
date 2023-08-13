using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts.Helpers
{
    public class BtnAnimator : MonoBehaviour
    {
        [SerializeField] private float animateDelay,scaleDecrement;
        [SerializeField] private Ease animateEase;

        // private AudioManager audioManager;
        //
        // private void Start()
        // {
        //     audioManager=AudioManager.instance;
        // }

        private void LateUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var item = EventSystem.current.currentSelectedGameObject;
                if(!item) return;
                if (item.CompareTag("Button"))
                {
                 //   audioManager.PlaySound("Btn");
                    DOTween.Kill(item);
                    item.transform.DOScale(1, 0).SetEase(Ease.Linear);
                    item.transform.DOScale(scaleDecrement, animateDelay).SetEase(animateEase).SetLoops(2,LoopType.Yoyo);
                }
            }
        }
    }
}