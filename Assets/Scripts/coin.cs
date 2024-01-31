using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coin : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsPickup = 100;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coin")
        {
            FindObjectOfType<Game_Session>().AddToScore(pointsPickup);
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            Destroy(other.gameObject);
        }
    }
}
