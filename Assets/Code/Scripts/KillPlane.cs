using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(6);
            CheckPointGame.Instance.KillPlayerAndRespawn();
        }
    }
}
