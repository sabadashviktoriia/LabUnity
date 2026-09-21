using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private CinemachineCamera _cinCam;
    [SerializeField] private Rigidbody _rb;

    private Vector2 _move;

    public void OnMove(InputValue val)
    {
        _move = val.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = (GetForward() * _move.y) + (GetRight() * _move.x);
        _rb.linearVelocity = new Vector3(moveDirection.x * speed, _rb.linearVelocity.y, moveDirection.z * speed);
    }

    private Vector3 GetForward()
    {
        Vector3 forward = _cinCam.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetRight()
    {
        Vector3 right = _cinCam.transform.right;
        right.y = 0;
        return right.normalized;
    }
}