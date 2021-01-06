using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrow : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnPoint;

    [SerializeField]
    private Camera _playerCamera;

    [SerializeField]
    private GameObject _ball;

    [SerializeField]
    private Rigidbody _ballBody;

    [SerializeField, Range(0.5f, 50000f)]
    private float _throwForce = 10f;

    private InputManager _inputManager;

    // Start is called before the first frame update
    void Start()
    {
        _inputManager = InputManager.Instance;
        //_ballBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        ShootBall();

    }

    void ShootBall()
    {
        if (_inputManager.PlayerShooting())
        {
            Debug.Log("Ball is created");
            GameObject ballClone;
            ballClone = Instantiate(_ball, _spawnPoint.transform.position, this.transform.rotation);

            ballClone.GetComponent<Rigidbody>().AddForce(_playerCamera.transform.forward * _throwForce);
        }
    }
}
