using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    private GameManager _gameManager;
    public Slider slider;
    public int _amountToFeed;
    private int _currentFeedAmount = 0;

    void Start()
    {
        slider.maxValue = _amountToFeed;
        slider.value = 0;
        slider.fillRect.gameObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
     
    }

    public void FeedAnimal(int amount) 
    {
        _currentFeedAmount += amount;
        slider.fillRect.gameObject.SetActive(true);
        slider.value = _currentFeedAmount;

        if (_currentFeedAmount >= _amountToFeed) 
        {
            _currentFeedAmount = _amountToFeed;
            _gameManager.Scorer(1);
            Destroy(gameObject);
        }
    }
}
