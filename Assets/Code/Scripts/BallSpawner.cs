using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Tooltip("How frequently should the balls spawn?"),Range(0.1f, 20f)]
    public float spawnTimer;
    private float _internalSpawnTimer;

    // How many RED balls do you want to spawn?
    private int _redBallAmount;

    // How many BLUE balls do you want to spawn?
    private int _blueBallAmount;

    [SerializeField]
    private GameObject _redBall;

    [SerializeField]
    private GameObject _blueBall;

    // Start is called before the first frame update
    void Start()
    {
        _internalSpawnTimer = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBalls();
    }

    private void SpawnBalls()
    {
        _internalSpawnTimer -= Time.deltaTime;

        if (_internalSpawnTimer <= 0)
        {
            Debug.Log("Timer reached ZERO, resetting Timer");
            _internalSpawnTimer = spawnTimer;
        }
    }
}
