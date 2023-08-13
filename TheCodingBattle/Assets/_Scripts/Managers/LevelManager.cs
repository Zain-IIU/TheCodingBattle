using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private int mainLevelIndex = 2;

        [SerializeField] private int curLevelToLoad;

        public void LoadNextLevel()
        {
            var currScene = SceneManager.GetActiveScene().buildIndex;
            currScene++;
            PlayerPrefs.SetInt("CurrentLevel", currScene);
            if (currScene >= SceneManager.sceneCountInBuildSettings)
            {
                currScene = mainLevelIndex + 2;
            }
            SceneManager.LoadScene(currScene);
        }


        private void OnDestroy()
        {
            DOTween.KillAll();
        }
    }
}