using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float _movementSpeed = 5;
    [SerializeField] private float _jumpForce = 4f;
    [Header("Ground check")]
    [SerializeField] private float _groundDistance = 0.51f;
    [SerializeField] private LayerMask _groundLayers;
    private bool _isGrounded;
    private Rigidbody _rigidbody;
    private static Quaternion _faceLeftRotation = Quaternion.Euler(0, 180, 0);
    private static Quaternion _faceRightRotation = Quaternion.Euler(0, 0, 0);
    private const float MIN_X_POSITION = -8.5f;
    private const float MAX_X_POSITION = 8.5f;
    private const string HORIZONTAL_AXIS = "Horizontal";

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    private void Update() {
        //Jump
        if (Input.GetKey(KeyCode.Space)) {
            _isGrounded = Physics.Raycast(transform.position, Vector3.down, _groundDistance, _groundLayers);
            if (_isGrounded)
                Jump();
        }
        //Movement
        float horizontalInput = Input.GetAxis(HORIZONTAL_AXIS);
        if (horizontalInput < -0.1f || horizontalInput > 0.1f) {
            if (horizontalInput < 0.1f)
                transform.rotation = _faceLeftRotation;
            else
                transform.rotation = _faceRightRotation;
            Vector3 pos = transform.position;
            pos.x += horizontalInput * _movementSpeed * Time.deltaTime;
            pos.x = Mathf.Clamp(pos.x, MIN_X_POSITION, MAX_X_POSITION);
            transform.position = pos;
        }
    }

    private void Jump() {
        _rigidbody.velocity = new(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z);
    }

}
