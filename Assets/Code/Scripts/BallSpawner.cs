using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Tooltip("How frequently should the balls spawn?"),Range(0.1f, 20f)]
    public float spawnTimer;
    private float _internalSpawnTimer;

    // RED & BLUE balls should use same possible amount
    private int _redBallAmount;
    private int _blueBallAmount;

    public int ballsToSpawn;

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

            for (int i = 0; i < ballsToSpawn; i++)
            {
                Debug.Log("Balls spawned");
                Instantiate(_redBall, transform.position, Quaternion.identity);
            }

        }
    }
}
