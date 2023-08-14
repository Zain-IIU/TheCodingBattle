using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Helpers
{
    public class LessonCard : MonoBehaviour
    {
        public enum LessonType
        {
            Variable,
            Conditional,
            Function,
            Loop
        }

        [SerializeField] private LessonType lessonType;
        [SerializeField] private bool isUnlockedByDefault;
        [SerializeField] private Button buttonHolder;
        private void Awake()
        {
            buttonHolder.interactable = false ;
            if (isUnlockedByDefault)
            {
                buttonHolder.interactable = true;
                return;
            }

            var unlocked = PlayerPrefs.GetInt("Unlocked" + lessonType, 0);
            buttonHolder.interactable = unlocked != 0;
        }
    }
}