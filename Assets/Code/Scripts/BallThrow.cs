using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrow : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnPoint;

    [SerializeField]
    private GameObject _ball;

    [SerializeField, Range(0.5f, 50f)]
    private float _throwForce = 10f;

    private InputManager _inputManager;

    // Start is called before the first frame update
    void Start()
    {
        _inputManager = InputManager.Instance;
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
            Instantiate(_ball, _spawnPoint.transform.position, this.transform.rotation);
        }
        
    }
}
