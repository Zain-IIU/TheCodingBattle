using System;
using _Scripts.CustomClass;
using _Scripts.Helpers;
using UnityEngine;

namespace _Scripts.InGame.Lessons
{
    public class ConditionalLesson : MonoBehaviour
    {
        private enum ConditionalType
        {
            If,
            IfElse,
            IfElseCombo,
            IfElseMulti
        }

        [SerializeField] private ConditionalType conditionalType;
        [SerializeField] private PlayerSystemBase playerSystem;

        private void Update()
        {
            CheckForLesson();
        }

        private void CheckForLesson()
        {
            switch (conditionalType)
            {
                case ConditionalType.If:
                    IfLesson();
                    break;
                case ConditionalType.IfElse:
                    IfElseLesson();
                    break;
                case ConditionalType.IfElseCombo:
                    IfElseComboLesson();
                    break;
                case ConditionalType.IfElseMulti:
                    IfElseMultiLesson();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void IfLesson()
        {
            playerSystem.SetMovement();
        }

        private void IfElseLesson()
        {
           playerSystem.SetMovement();
        }

        private void IfElseComboLesson()
        {
            playerSystem.SetMovement();
        }

        private void IfElseMultiLesson()
        {
            playerSystem.SetMovement();
        }
    }
}