using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Tooltip("How frequently should the balls spawn?"),Range(0.1f, 20f)]
    public float spawnTimer;
    private float _internalSpawnTimer;

    [SerializeField, Range(0.5f, 15f)]
    private float _destroyBallsTimer;

    public int ballsToSpawn;

    [SerializeField]
    private GameObject _redBall;

    [SerializeField]
    private GameObject _blueBall;

    [Header("Box Area Spawn"), SerializeField, Tooltip("Where in the world is the psawn box positioned?")]
    private Vector3 _center;
    [SerializeField, Tooltip("How big is the size of the spawn area?")]
    private Vector3 _size;


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

    // TODO Look into making 2 different methods for spawn spawning Red balls & Blue balls

    /// <summary>
    /// Spawns the same amount of RED & BLUE balls
    /// </summary>
    private void SpawnBalls()
    {

        _internalSpawnTimer -= Time.deltaTime;

        Vector3 spawnAreaPosition = _center + new Vector3(
            Random.Range(-_size.x / 2, _size.x / 2), 
            Random.Range(-_size.y / 2, _size.y / 2), 
            Random.Range(-_size.z / 2, _size.z / 2));

        if (_internalSpawnTimer <= 0)
        {
            Debug.Log("Timer reached ZERO, resetting Timer");
            _internalSpawnTimer = spawnTimer;
            var randomBallAmount = Random.Range(0, ballsToSpawn);

            for (int i = 0; i < randomBallAmount; i++)
            {
                Debug.Log("Random Ball per color is: " + randomBallAmount);
                GameObject redBallClone = Instantiate(_redBall, spawnAreaPosition, Quaternion.identity);
                GameObject blueBallClone = Instantiate(_blueBall, spawnAreaPosition, Quaternion.identity);
                
                Destroy(redBallClone, _destroyBallsTimer);
                Destroy(blueBallClone, _destroyBallsTimer);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.25f);
        Gizmos.DrawCube(_center, _size);
    }
}
