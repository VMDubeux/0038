using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollision : MonoBehaviour
{
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) //Destr�i objeto ap�s colidir com outro objeto colisor.
    {
        if (gameObject.CompareTag("Animal") && other.CompareTag("Player")) //Se animal com tag "Animal" colidir com Player, reduz vida do Player, mas n�o o destr�i.
        {
            _gameManager.PlayerLife(1);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("AgressiveAnimal") && other.CompareTag("Player")) //Se animal com tag "AgressiveAnimal" colidir com Player, destr�i o Player.
        {
            _gameManager.PlayerLife(3);
            Destroy(gameObject); //Destr�i o animal colisor.
            Destroy(other.gameObject); //Destr�i o player.
        }
        else if (gameObject.CompareTag("Pizza") && other.CompareTag("Animal")) //Pizza destr�i o animal e vice-versa.
        {
            Destroy(gameObject);
            other.GetComponent<HungerBar>().FeedAnimal(1);
            if (other.GetComponent<HungerBar>().slider.value == other.GetComponent<HungerBar>()._amountToFeed)
            {
                Destroy(other.gameObject);
            }
        }
        else if (gameObject.CompareTag("Pizza") && other.CompareTag("AgressiveAnimal"))
        {
            Destroy(gameObject);
            other.GetComponent<HungerBar>().FeedAnimal(1);
            if (other.GetComponent<HungerBar>().slider.value == other.GetComponent<HungerBar>()._amountToFeed)
            {
                Destroy(other.gameObject);
            }
        }
    }
}