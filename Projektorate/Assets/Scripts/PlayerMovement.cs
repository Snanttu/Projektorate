using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float _speed = 6.0F;
    public float _jumpSpeed = 8.0F;
    public float _gravity = 20.0F;

    private Transform _transform;
    private Vector3 moveDirection = Vector3.zero;

    void Start() { 

    }

    void Update() {

        CharacterController controller = GetComponent<CharacterController>();
        _transform = gameObject.GetComponent<Transform>();

        if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= _speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = _jumpSpeed;
        }

        moveDirection.y -= _gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (_transform.position.y < -5 || _transform.position.z < 0)
        {
            _transform.position = new Vector3(0, -1, 3);
        }
    }
}
