using System;
using UnityEngine;

namespace _Scripts.Managers
{
    public class EventsManager : MonoBehaviour
    {
        public static event Action OnKeyPicked;
        public static event Action OnLevelCompleted;

        public static void KeyPickedEvent()
        {
            OnKeyPicked?.Invoke();
        }

        public static void LevelCompleteEvent()
        {
            OnLevelCompleted?.Invoke();
        }
    }
}