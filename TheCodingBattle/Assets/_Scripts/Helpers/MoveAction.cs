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

        public int curCounter;

        private void Start()
        {
            curCounter = totalActions;
            SetText();
        }

        public void SetText()
        {
            counterText.text = curCounter.ToString();
        }

        public void ResetCounter()
        {
            curCounter = totalActions;
            SetText();
        }
    }
}