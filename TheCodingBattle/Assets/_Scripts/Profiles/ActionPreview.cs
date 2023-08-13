using TMPro;
using UnityEngine;

namespace _Scripts.Profiles
{
    public class ActionPreview : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI actionText;

        public void SetText(string text)
        {
            actionText.text = text;
        }
    }
}