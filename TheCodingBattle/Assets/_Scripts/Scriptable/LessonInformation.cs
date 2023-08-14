using UnityEngine;

namespace _Scripts.Scriptable
{
    [CreateAssetMenu(fileName = "LessonInformation", menuName = "LessonData", order = 0)]
    public class LessonInformation : ScriptableObject
    {
        public string lessonHeader, lessonSubHeader, lessonDetails;
    }
}