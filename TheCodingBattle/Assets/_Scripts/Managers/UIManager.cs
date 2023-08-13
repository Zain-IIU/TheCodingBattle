using UnityEngine;

namespace _Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private CanvasGroup inGameUI, levelCompletePanel;

        private void OnEnable()
        {
            EventsManager.OnLevelCompleted += ShowLevelCompleteUI;
        }

        private void OnDisable()
        {
            EventsManager.OnLevelCompleted -= ShowLevelCompleteUI;
        }

        private void ShowLevelCompleteUI()
        {
            inGameUI.alpha = 0;
            inGameUI.interactable = inGameUI.blocksRaycasts = false;
            levelCompletePanel.alpha = 1;
            levelCompletePanel.interactable = levelCompletePanel.blocksRaycasts = true;
        }
    }
}