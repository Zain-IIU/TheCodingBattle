using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Helpers
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private bool isSplashScreen;
        [SerializeField] public  int mainLevelIndex=2;
        private  int CurrentLevel => PlayerPrefs.GetInt("CurrentLevel", mainLevelIndex);

        private void Start()
        {
            if(isSplashScreen)
                Invoke(nameof(LoadLevel),2f);
        }

        public void LoadLevel()
        {
            if (isSplashScreen)
            {
                SceneManager.LoadScene(1);
                return;
            }
            var sceneToLoad = GetLevelIndex();
            if (sceneToLoad <= mainLevelIndex)
                sceneToLoad = mainLevelIndex+1;
            if (sceneToLoad == 1)
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene(sceneToLoad);
        }

        public void LoadNextLevelOf(int type)
        {
            var sceneToLoad = GetLevelIndex();
            if (sceneToLoad <= mainLevelIndex)
                sceneToLoad = mainLevelIndex+1;
            switch (type)
            {
                case 0:
                    if (sceneToLoad > 4)
                        sceneToLoad = 2;
                    break;
                case 1:
                    if (sceneToLoad > 6)
                        sceneToLoad = 5;
                    break;
                case 2:
                    if (sceneToLoad > 7)
                        sceneToLoad = 7;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            
            
            SceneManager.LoadScene(sceneToLoad);
        }
        private  int GetLevelIndex()
        {
            return CurrentLevel % SceneManager.sceneCountInBuildSettings;
        }
    }
}