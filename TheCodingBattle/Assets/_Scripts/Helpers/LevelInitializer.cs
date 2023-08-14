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

        private  int GetLevelIndex()
        {
            return CurrentLevel % SceneManager.sceneCountInBuildSettings;
        }
    }
}