using TMPro;
using UnityEngine;

namespace _Scripts.InGame
{
    public class MainScreenHandler : MonoBehaviour
    {
        [SerializeField] private GameObject[] screens;
        [SerializeField] private TextMeshProUGUI headerText;

        private void Start()
        {
            EnableScreenAt(0);
        }

        public void EnableScreenAt(int index)
        {
            foreach (var screen in screens)
            {
                screen.SetActive(false);
            }
            screens[index].SetActive(true);
            switch (index)
            {
                case 0:
                    headerText.text = "Select Chapters";
                    break;
                case 1:
                    headerText.text = "Take Quiz";
                    break;
                case 2:
                    headerText.text = "About";
                    break;
            }
        }
    }
}