using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private bool _isCollected;
    public int pickupType = 1;
    public SpriteRenderer theSR;
    public Sprite blueSprite;
    public Sprite redSprite;

    void Start()
    {
        if (pickupType == 2)
        {
            theSR.sprite = blueSprite;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isCollected)
        {
            _isCollected = true;
            Destroy(gameObject);
            if ( pickupType == 1 ) { 
                UIController.Instance.PickUpRed();
                UIController.Instance.UpdateRedCounter(1);
            }
            if (pickupType == 2)
            {
                UIController.Instance.PickUpBlue();
                UIController.Instance.UpdateBlueCounter(1);
            }
        }
    }
}