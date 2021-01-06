using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrow : MonoBehaviour
{
    [SerializeField]
    private GameObject _blueSpawnPoint;

    [SerializeField]
    private GameObject _redSpawnPoint;

    [SerializeField]
    private Camera _playerCamera;

    [SerializeField]
    private GameObject _redBall;
    [SerializeField]
    private GameObject _blueBall;

    [SerializeField]
    private Rigidbody _ballBody;

    [SerializeField, Range(0.5f, 3000f)]
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
        if (_inputManager.PlayerShootingRed())
        {
            if (UIController.Instance.redBalls != 0)
            {
                Debug.Log("Red Ball is thrown");
                GameObject redBallClone;
                redBallClone = Instantiate(_redBall, _redSpawnPoint.transform.position, this.transform.rotation);

                redBallClone.GetComponent<Rigidbody>().AddForce(_playerCamera.transform.forward * _throwForce);

                Destroy(redBallClone, 5.0f);
                UIController.Instance.UpdateRedCounter(-1);
            }
            else if(UIController.Instance.redBalls <= 0)
            {
                Debug.Log("No Red Balls available!");
            }    
        }

        if (_inputManager.PlayerShootingBlue())
        {
            if (UIController.Instance.blueBalls != 0)
            {
                Debug.Log("Blue Ball is thrown");
                GameObject blueBallClone;
                blueBallClone = Instantiate(_blueBall, _blueSpawnPoint.transform.position, this.transform.rotation);

                blueBallClone.GetComponent<Rigidbody>().AddForce(_playerCamera.transform.forward * _throwForce);

                Destroy(blueBallClone, 5.0f);
                UIController.Instance.UpdateBlueCounter(-1);
            }
            else if (UIController.Instance.blueBalls <= 0)
            {
                Debug.Log("No Blue Balls available!");
            }
        }
    }
}