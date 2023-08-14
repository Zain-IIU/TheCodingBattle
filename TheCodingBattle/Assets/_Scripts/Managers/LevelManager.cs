using _Scripts.Helpers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private int mainLevelIndex = 2;
        

        public void LoadNextLevel()
        {
            var currScene = SceneManager.GetActiveScene().buildIndex;
            currScene++;
            PlayerPrefs.SetInt("CurrentLevel", currScene);
            if (currScene >= SceneManager.sceneCountInBuildSettings)
            {
                currScene = mainLevelIndex;
            }

            if (currScene >= 5 && currScene < 7)
            {
                PlayerPrefs.SetInt("Unlocked" + LessonCard.LessonType.Conditional, 1);
            } 
            if (currScene ==7)
            {
                PlayerPrefs.SetInt("Unlocked" + LessonCard.LessonType.Function, 1);
            } 
            if (currScene ==8)
            {
                PlayerPrefs.SetInt("Unlocked" + LessonCard.LessonType.Loop, 1);
            }
            SceneManager.LoadScene(currScene);
        }
        

        private void OnDestroy()
        {
            DOTween.KillAll();
        }
    }
}