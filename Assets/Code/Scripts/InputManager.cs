﻿using UnityEngine;

public class InputManager : MonoBehaviour
{

    private static InputManager _instance;

    public static InputManager Instance { get { return _instance; } }


    private PlayerControl _playerControl;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        _playerControl = new PlayerControl();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable()
    {
        _playerControl.Enable();
    }

    private void OnDisable()
    {
        _playerControl.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return _playerControl.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return _playerControl.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumpedThisFrame()
    {
        return _playerControl.Player.Jump.triggered;
    }

    public bool PlayerShootingRed()
    {
        return _playerControl.Player.Shoot_Red.triggered;
    }

    public bool PlayerShootingBlue()
    {
        return _playerControl.Player.Shoot_Blue.triggered;
    }

    public bool PlayerPausedGame()
    {
        return _playerControl.Player.PauseGame.triggered;
    }
}
