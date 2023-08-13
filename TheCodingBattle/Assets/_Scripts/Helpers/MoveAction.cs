using System;
using TMPro;
using UnityEngine;

namespace _Scripts.Helpers
{
    public enum ActionType
    {
        Front, 
        Back,
        Left,
        Right,
        Loop
    }
    public class MoveAction : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI counterText;
        public ActionType actionType;
        public int totalActions;

        private void Start()
        {
            SetText();
        }

        public void SetText()
        {
            counterText.text = totalActions.ToString();
        }
    }
}