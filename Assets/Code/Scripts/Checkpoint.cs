using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public int checkpointId;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("CP");
            CheckPointGame.Instance.UpdateLastCheckpoint(this);
        }
    }
}
