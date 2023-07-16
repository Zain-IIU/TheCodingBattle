using System;
using UnityEngine;

namespace _Scripts.Managers
{
    public class EventsManager : MonoBehaviour
    {
        public static event Action OnKeyPicked;

        public static void KeyPickedEvent()
        {
            OnKeyPicked?.Invoke();
        }
    }
}