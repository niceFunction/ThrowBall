using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public List<GameObject> goalObjects { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        goalObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToList(GameObject goalObject, float interval)
    {
        goalObjects.Add(goalObject);
    }

}
