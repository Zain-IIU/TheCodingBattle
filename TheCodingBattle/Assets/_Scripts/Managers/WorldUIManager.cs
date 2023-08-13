using TMPro;
using UnityEngine;

namespace _Scripts.Managers
{
    public class WorldUIManager : MonoBehaviour
    {
        public static WorldUIManager Instance;

        private void Awake()
        {
            Instance = this;
        }


        [SerializeField] private TextMeshProUGUI detailsText;

        public void SetDetailsText(string textToAdd)
        {
            detailsText.text = textToAdd;
        }
    }
}