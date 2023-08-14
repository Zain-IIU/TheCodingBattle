using _Scripts.Scriptable;
using TMPro;
using UnityEngine;

namespace _Scripts.Managers
{
    public class StartInfoManager : MonoBehaviour
    {
        [SerializeField] private CanvasGroup panel;
        [SerializeField] private TextMeshProUGUI lessonHeaderText, subHeaderText, detailsText;
        public LessonInformation informationData;

        private void Start()
        {
            lessonHeaderText.text = informationData.lessonHeader;
            subHeaderText.text = informationData.lessonSubHeader;
            detailsText.text = informationData.lessonDetails;
        }

        public void HideThisPanel()
        {
            panel.alpha = 0;
            panel.interactable = panel.blocksRaycasts = false;
        }
    }
}