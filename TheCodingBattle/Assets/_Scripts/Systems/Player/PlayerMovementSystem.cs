using _Scripts.CustomClass;
using _Scripts.Helpers;
using _Scripts.Managers;
using _Scripts.Profiles;
using UnityEngine;

namespace _Scripts.Systems.Player
{
    public class PlayerMovementSystem : PlayerSystemBase
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed = 5;
        [SerializeField] private float turnSpeed = 360;
        [SerializeField] private Animator animator;
        private Vector3 _input;

        [SerializeField] private bool isJoystick;
        [SerializeField] private bool useSkewedInput;
        [SerializeField] private FloatingJoystick joystick;

        private void Start()
        {
            joystick = FindObjectOfType<FloatingJoystick>();
        }


        public override void SetMovement()
        {
            GatherInput(isJoystick);
            Look();
            Animate();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void GatherInput(bool useJoystick)
        {
            _input = useJoystick
                ? new Vector3(joystick.Horizontal, 0, joystick.Vertical)
                : new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }

        private void Look()
        {
            if (_input == Vector3.zero) return;
            var rot = useSkewedInput
                ? Quaternion.LookRotation(_input.ToIso(), Vector3.up)
                : Quaternion.LookRotation(_input, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }

        private void Move()
        {
            var transform1 = transform;
            rb.MovePosition(transform1.position +
                            transform1.forward * (_input.normalized.magnitude * speed * Time.deltaTime));
        }

        private bool _isMove;
        private static readonly int MoveTrigger = Animator.StringToHash("Move");

        private void Animate()
        {
            if (isJoystick)
            {
                if ((joystick.Horizontal == 0 && joystick.Vertical == 0))
                    _isMove = false;
                else
                    _isMove = true;
            }

            animator.SetBool(MoveTrigger, _isMove);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out DoorSystem doorSystem))
            {
                if (doorSystem.GetDoorType() == DoorSystem.DoorType.TriggerBased)
                    doorSystem.OpenTheGate();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Key"))
            {
                other.gameObject.SetActive(false);
                EventsManager.KeyPickedEvent();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out DoorSystem doorSystem))
            {
                if (doorSystem.GetDoorType() == DoorSystem.DoorType.TriggerBased)
                    doorSystem.CloseTheGate();
            }
        }
    }
}