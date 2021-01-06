using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScore : MonoBehaviour
{

    public int scorePoints = 100;
    public GameObject parentObject;
    public float respawnInterval;
    private float _respawnInterval;
    private bool _scoredGoal;

    void Start()
    {
        _respawnInterval = respawnInterval;
    }

    void Update()
    {
        if (_scoredGoal)
        {
            parentObject.SetActive(true);
            _scoredGoal = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedBall") && !_scoredGoal)
        {
            _scoredGoal = true; // Scored a goal
            respawnInterval = _respawnInterval; // Set interval timer to default
            ScoreManager.Instance.AddToList(parentObject, respawnInterval);
            parentObject.SetActive(false); // Inactivate parent
        }

    }
}