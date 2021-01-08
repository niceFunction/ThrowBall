using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public float respawnInterval = 20;
    public bool willRespawn = true;
    public Transform target;
    public float speed;
    public bool moveObj = true;
    private bool _targetReached;
    private bool _startReached;
    private Vector3 _startPosition;

    void Start()
    {
        target.parent = null;
        _startPosition = this.gameObject.transform.position;
    }

    void Update()
    {
        if (moveObj == true && _targetReached == false)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        if (moveObj == true && _targetReached == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, step);
        }

        if (!_targetReached)
        {
            if (Vector3.Distance(transform.position, target.position) > 0.01f)
            {
                // Moving
            }
            else
            {
                _startReached = false;
                _targetReached = true;
            }
        }
        if (_targetReached && !_startReached)
        {
            if (Vector3.Distance(transform.position, _startPosition) > 0.01f)
            {
                // Moving
            }
            else
            {
                _startReached = true;
                _targetReached = false;
            }
        }
    }

}