using System;
using UnityEngine;

namespace _Scripts.Helpers
{
    public class MouseClickListener : MonoBehaviour
    {
        [SerializeField] private GameObject[] selectables;

        private void Start()
        {
           EnableSelectableAt(0);
        }

        public void EnableSelectableAt(int index)
        {
            foreach (var selectable in selectables)
            {
             selectable.SetActive(false);   
            }
            selectables[index].SetActive(true);
        }
    }
}