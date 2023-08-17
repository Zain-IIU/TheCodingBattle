using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    private void Awake()
    {
        instance = this;
    }

    public void LoadLevelWithName(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
