using DG.Tweening;
using UnityEngine;

namespace _Scripts.InGame.Lessons
{
    public class FunctionalLesson : MonoBehaviour
    {
        [SerializeField] private Transform playerTransforms;
        [SerializeField] private Animator playerAnim;
        [SerializeField] private float moveOffset,moveDelay;

        private bool _isMoving;
        private static readonly int Move = Animator.StringToHash("Move");

        public void MoveLeft()
        {
            if(_isMoving) return;
            var curTransforms = playerTransforms.localPosition;
            if(curTransforms.x<=-4) return;
            _isMoving = true;
            curTransforms.x -= moveOffset;
            playerAnim.SetBool(Move,true);
            playerTransforms.DOLocalRotate(new Vector3(0, -90, 0), .15f);
            playerTransforms.DOLocalMove(curTransforms, moveDelay).SetEase(Ease.Linear).OnComplete(() =>
            {
                playerAnim.SetBool(Move,false);
                _isMoving = false;
            });
        }

        public void MoveRight()
        {
            if(_isMoving) return;
            var curTransforms = playerTransforms.localPosition;
            if(curTransforms.x>=4) return;
            _isMoving = true;
            curTransforms.x += moveOffset;
            playerAnim.SetBool(Move,true);
            playerTransforms.DOLocalRotate(new Vector3(0, 90, 0), .15f);
            playerTransforms.DOLocalMove(curTransforms, moveDelay).SetEase(Ease.Linear).OnComplete(() =>
            {
                playerAnim.SetBool(Move,false);
                _isMoving = false;
            });
        }

        public void MoveFront()
        {
            if(_isMoving) return;
            var curTransforms = playerTransforms.localPosition;
            if(curTransforms.z>=4) return;
            _isMoving = true;
            curTransforms.z += moveOffset;
            playerAnim.SetBool(Move,true);
            playerTransforms.DOLocalRotate(new Vector3(0, 0, 0), .15f);
            playerTransforms.DOLocalMove(curTransforms, moveDelay).SetEase(Ease.Linear).OnComplete(() =>
            {
                playerAnim.SetBool(Move,false);
                _isMoving = false;
            });
        }

        public void MoveBack()
        {
            if(_isMoving) return;
            var curTransforms = playerTransforms.localPosition;
            if(curTransforms.z<=-4) return;
            _isMoving = true;
            curTransforms.z -= moveOffset;
            playerAnim.SetBool(Move,true);
            playerTransforms.DOLocalRotate(new Vector3(0, 180, 0), .15f);
            playerTransforms.DOLocalMove(curTransforms, moveDelay).SetEase(Ease.Linear).OnComplete(() =>
            {
                playerAnim.SetBool(Move,false);
                _isMoving = false;
            });
        }
    }
}
