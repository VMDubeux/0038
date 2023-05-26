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

    private void OnTriggerEnter(Collider other) //Destrói objeto após colidir com outro objeto colisor.
    {
        if (gameObject.CompareTag("Animal") && other.CompareTag("Player")) //Se animal com tag "Animal" colidir com Player, reduz vida do Player, mas não o destrói.
        {
            _gameManager.PlayerLife(1);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("AgressiveAnimal") && other.CompareTag("Player")) //Se animal com tag "AgressiveAnimal" colidir com Player, destrói o Player.
        {
            _gameManager.PlayerLife(3);
            Destroy(gameObject); //Destrói o animal colisor.
            Destroy(other.gameObject); //Destrói o player.
        }
        else if (gameObject.CompareTag("Pizza") && other.CompareTag("Animal")) //Pizza destrói o animal e vice-versa.
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