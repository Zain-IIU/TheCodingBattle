using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Helpers;
using _Scripts.Profiles;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.InGame.Lessons
{
    public class LoopLesson : MonoBehaviour
    {
        [SerializeField] private List<MoveAction> actions = new();
        [SerializeField] private MoveAction[] allActions;
        [SerializeField] private Transform playerTransforms, frameParent;
        [SerializeField] private Animator playerAnim;
        [SerializeField] private ActionPreview previewPrefab;
        [SerializeField] private float moveOffset, moveDelay;
        private bool _isMoving, _actionsWorking;
        private static readonly int Move = Animator.StringToHash("Move");

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (_actionsWorking) return;
                ExecuteAllActions();
            }
        }

        private void ExecuteAllActions()
        {
            StartCoroutine(nameof(Action_CO));
        }

        private IEnumerator Action_CO()
        {
            _actionsWorking = true;
            for (var i = 0; i < actions.Count; i++)
            {
                switch (actions[i].actionType)
                {
                    case ActionType.Front:
                        MoveFront();
                        break;
                    case ActionType.Back:
                        MoveBack();
                        break;
                    case ActionType.Left:
                        MoveLeft();
                        break;
                    case ActionType.Right:
                        MoveRight();
                        break;
                    case ActionType.Loop:
                        for (var j = 0; j < i; j++)
                        {
                            switch (actions[j].actionType)
                            {
                                case ActionType.Front:
                                    MoveFront();
                                    break;
                                case ActionType.Back:
                                    MoveBack();
                                    break;
                                case ActionType.Left:
                                    MoveLeft();
                                    break;
                                case ActionType.Right:
                                    MoveRight();
                                    break;
                                case ActionType.Loop:
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            yield return new WaitForSeconds(.6f);
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                yield return new WaitForSeconds(.6f);
            }

            actions.Clear();
            _actionsWorking = false;
        }

        private void MoveLeft()
        {
            if (_isMoving) return;
            var curTransforms = playerTransforms.localPosition;
            if (curTransforms.x <= -4) return;
            _isMoving = true;
            curTransforms.x -= moveOffset;
            playerAnim.SetBool(Move, true);
            playerTransforms.DOLocalRotate(new Vector3(0, -90, 0), .15f);
            playerTransforms.DOLocalMove(curTransforms, moveDelay).SetEase(Ease.Linear).OnComplete(() =>
            {
                playerAnim.SetBool(Move, false);
                _isMoving = false;
            });
        }

        private void MoveRight()
        {
            if (_isMoving) return;
            var curTransforms = playerTransforms.localPosition;
            if (curTransforms.x >= 4) return;
            _isMoving = true;
            curTransforms.x += moveOffset;
            playerAnim.SetBool(Move, true);
            playerTransforms.DOLocalRotate(new Vector3(0, 90, 0), .15f);
            playerTransforms.DOLocalMove(curTransforms, moveDelay).SetEase(Ease.Linear).OnComplete(() =>
            {
                playerAnim.SetBool(Move, false);
                _isMoving = false;
            });
        }

        private void MoveFront()
        {
            if (_isMoving) return;
            var curTransforms = playerTransforms.localPosition;
            if (curTransforms.z >= 4) return;
            _isMoving = true;
            curTransforms.z += moveOffset;
            playerAnim.SetBool(Move, true);
            playerTransforms.DOLocalRotate(new Vector3(0, 0, 0), .15f);
            playerTransforms.DOLocalMove(curTransforms, moveDelay).SetEase(Ease.Linear).OnComplete(() =>
            {
                playerAnim.SetBool(Move, false);
                _isMoving = false;
            });
        }

        private void MoveBack()
        {
            if (_isMoving) return;
            var curTransforms = playerTransforms.localPosition;
            if (curTransforms.z <= -4) return;
            _isMoving = true;
            curTransforms.z -= moveOffset;
            playerAnim.SetBool(Move, true);
            playerTransforms.DOLocalRotate(new Vector3(0, 180, 0), .15f);
            playerTransforms.DOLocalMove(curTransforms, moveDelay).SetEase(Ease.Linear).OnComplete(() =>
            {
                playerAnim.SetBool(Move, false);
                _isMoving = false;
            });
        }

        public void AddActionInToList(MoveAction action)
        {
            if(action.totalActions<=0) return;
            actions.Add(action);
            action.totalActions--;
            action.SetText();
            var preview = Instantiate(previewPrefab, frameParent, true);
            preview.SetText(action.actionType.ToString());
        }

        public void TakeActions()
        {
            if (_actionsWorking) return;
            ExecuteAllActions();
        }

        public void ResetActions()
        {
            foreach (var allAction in allActions)
            {
                allAction.gameObject.SetActive(true);
            }

            playerAnim.SetBool(Move, false);
            _actionsWorking = false;
            DOTween.Kill(playerTransforms);
            StopAllCoroutines();
            actions.Clear();
            playerTransforms.DOLocalRotate(Vector3.zero, 0).SetEase(Ease.Linear);
            playerTransforms.DOLocalMove(new Vector3(-4, 0, -4), .15f).SetEase(Ease.Linear);
        }
    }
}