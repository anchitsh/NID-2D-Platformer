using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool coinCollected = false;
    public AudioSource coinAudioSource;
    public GameObject sprite;

    //This function is called when the collison with coin happens
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && coinCollected == false)
        {
            coinCollected = true;
            sprite.SetActive(false);
            coinAudioSource.Play();
            collision.gameObject.GetComponent<CharacterController>().coinUI.CoinCollected();
        }
    }
}
