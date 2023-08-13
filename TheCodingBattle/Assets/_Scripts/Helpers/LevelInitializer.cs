using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Helpers
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] public  int mainLevelIndex=2;
        private  int CurrentLevel => PlayerPrefs.GetInt("CurrentLevel", mainLevelIndex);

        private void Start()
        {
            Invoke(nameof(LoadLevel),2f);
        }

        private void LoadLevel()
        {
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