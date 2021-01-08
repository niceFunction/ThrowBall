using System;
using UnityEngine;

public class CheckPointGame : MonoBehaviour
{
    private static CheckPointGame _instance;
    public static CheckPointGame Instance
    {
        get { return _instance; }
    }

    public GameObject player;

    private Checkpoint _lastCheckpoint;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    public void KillPlayerAndRespawn()
    {
        //UIController.Instance.redBalls = 0;
        //UIController.Instance.blueBalls = 0;
        player.transform.position = _lastCheckpoint.transform.position;
    }

    public void UpdateLastCheckpoint(Checkpoint checkpoint)
    {
        _lastCheckpoint = checkpoint;
    }
}
