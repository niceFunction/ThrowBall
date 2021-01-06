using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScore : MonoBehaviour
{

    public int scorePoints = 100;
    public GameObject parentObject;
    public float respawnInterval;
    public bool isRed = true;
    public bool isPurple;
    //public GameObject destroyEffect;
    private bool _scoredGoal;
    private bool _willRespawn;

    void Start()
    {
        _willRespawn = parentObject.GetComponent<Goal>().willRespawn;
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
        if (isPurple)
        {
        } else
        {
            if (isRed)
            {
                if (other.CompareTag("RedBall") && !_scoredGoal)
                {
                    _scoredGoal = true; // Scored a goal
                    if (_willRespawn == true) { 
                        ScoreManager.Instance.AddToList(parentObject, respawnInterval);
                    }
                    UIController.Instance.UpdateScore(scorePoints);
                    //Instantiate(destroyEffect, transform.position, Quaternion.identity);
                    Destroy(other.gameObject);
                    Debug.Log("Shot red ball at red target");
                    parentObject.SetActive(false);
                } 
                else if (other.CompareTag("BlueBall")) 
                {
                    Debug.Log("Shot blue ball at red target");
                }
            }
            else
            {
                if (other.CompareTag("BlueBall") && !_scoredGoal)
                {
                    _scoredGoal = true; // Scored a goal
                    if (_willRespawn == true)
                    {
                        ScoreManager.Instance.AddToList(parentObject, respawnInterval);
                    }
                    //Instantiate(destroyEffect, transform.position, Quaternion.identity);
                    UIController.Instance.UpdateScore(scorePoints);
                    Destroy(other.gameObject);
                    Debug.Log("Shot blue ball at blue target");
                    parentObject.SetActive(false);
                } 
                else if (other.CompareTag("RedBall")) 
                {
                    Debug.Log("Shot red ball at blue target");
                }
            }
        }
    }
}