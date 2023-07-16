using System;
using _Scripts.CustomClass;
using _Scripts.Helpers;
using UnityEngine;

namespace _Scripts.InGame.Variables
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
    }
}