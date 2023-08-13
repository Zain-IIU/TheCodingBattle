using System;
using _Scripts.CustomClass;
using _Scripts.Helpers;
using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.InGame.Lessons
{
    public class VariableLesson : MonoBehaviour
    {
        private enum VariableType
        {
            Integer,
            FloatingPoint,
            Boolean
        }

        [SerializeField] private VariableType variableType;
        [SerializeField] private PlayerSystemBase playerSystem;

        private int _keysPicked;

        private void Start()
        {
            switch (variableType)
            {
                case VariableType.Integer:
                    WorldUIManager.Instance.SetDetailsText("Integer a= "+_keysPicked);
                    break;
                case VariableType.FloatingPoint:
                    break;
                case VariableType.Boolean:
                    WorldUIManager.Instance.SetDetailsText("Boolean Trigger = false");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
           
        }

        private void Update()
        {
            CheckForLesson();
        }

        private void CheckForLesson()
        {
            switch (variableType)
            {
                case VariableType.Integer:
                    IntegerLesson();
                    break;
                case VariableType.FloatingPoint:
                    FloatLesson();
                    break;
                case VariableType.Boolean:
                    BooleanLesson();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void IntegerLesson()
        {
           playerSystem.SetMovement();
        }

        private void FloatLesson()
        {
            if (SwipeDetect.swipeUp)
                playerSystem.AddPower(true);
            else if (SwipeDetect.swipeDown)
                playerSystem.AddPower(false);
        }

        private void BooleanLesson()
        {
            playerSystem.SetMovement();
        }

        private void OnEnable()
        {
            EventsManager.OnKeyPicked += SetTextInDetailsUI;
        }

        private void OnDisable()
        {
            EventsManager.OnKeyPicked -= SetTextInDetailsUI;
        }

        private void SetTextInDetailsUI()
        {
            _keysPicked++;
            WorldUIManager.Instance.SetDetailsText("Integer a= "+_keysPicked);
        }
    }
}