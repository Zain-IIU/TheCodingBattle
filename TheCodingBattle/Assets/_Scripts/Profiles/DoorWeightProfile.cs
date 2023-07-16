using UnityEngine;

namespace _Scripts.Profiles
{
    public class DoorWeightProfile : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out DoorSystem doorSystem))
            {
                if(doorSystem.GetDoorType()==DoorSystem.DoorType.TriggerBased)
                    doorSystem.OpenTheGate();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out DoorSystem doorSystem))
            {
                if(doorSystem.GetDoorType()==DoorSystem.DoorType.TriggerBased)
                    doorSystem.CloseTheGate();
            }
        }
    }
}