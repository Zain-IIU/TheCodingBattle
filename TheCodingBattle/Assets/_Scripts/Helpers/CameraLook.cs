using UnityEngine;

namespace _Scripts.Helpers
{
    public class CameraLook : MonoBehaviour
    {
        [SerializeField] private Transform mainCam;

        private void Start()
        {
            if (Camera.main is not null) mainCam = Camera.main.transform;
        }

        private void LateUpdate()
        {
            transform.forward = mainCam.forward;
        }
    }
}