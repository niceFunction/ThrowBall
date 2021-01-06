using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScore : MonoBehaviour
{

    public int scorePoints = 100;
    public GameObject parentObject;
    public float respawnInterval;
    public bool isRed = true;
    public GameObject destroyEffect;
    private bool _scoredGoal;

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
        if (isRed) 
        { 
            if (other.CompareTag("RedBall") && !_scoredGoal)
            {
                _scoredGoal = true; // Scored a goal
                ScoreManager.Instance.AddToList(parentObject, respawnInterval);
                UIController.Instance.UpdateScore(scorePoints);
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
                parentObject.SetActive(false);
            }
        } 
        else
        {
            if (other.CompareTag("BlueBall") && !_scoredGoal)
            {
                _scoredGoal = true; // Scored a goal
                ScoreManager.Instance.AddToList(parentObject, respawnInterval);
                UIController.Instance.UpdateScore(scorePoints);
                parentObject.SetActive(false);
            }
        }

    }
}