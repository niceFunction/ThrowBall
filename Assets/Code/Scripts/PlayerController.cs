using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("How fast will the player move?")]
    private float _playerSpeed = 2.0f;
    [SerializeField, Tooltip("How high can the player jump?")]
    private float _jumpHeight = 1.0f;
    [SerializeField, Tooltip("How much gravoty will the player have?")]
    private float _gravityValue = -9.81f;

    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private InputManager _inputManager;
    private Transform _cameraTransform;


    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _inputManager = InputManager.Instance;
        _cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        Vector2 movement = _inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = _cameraTransform.forward * move.z + _cameraTransform.right * move.x;
        move.y = 0f;
        _controller.Move(move * Time.deltaTime * _playerSpeed);
        
        if (movement.y == 0 && movement.x == 0)
        {
            AudioManager.Instance.StopSFX(4);
        } 
        else
        {
            if (_groundedPlayer) { 
                AudioManager.Instance.ActivateSFX(4);
            }
        }

        // Changes the height position of the player..
        if (_inputManager.PlayerJumpedThisFrame() && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("MovingPlatform"))
        {
            transform.parent = other.transform;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MovingPlatform"))
        {
            transform.parent = null;

        }
    }
}
