using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _life = 3;
    internal int _score = 0;

    void Start()
    {

    }


    void Update()
    {

    }

    public void Scorer(int value)
    {
        _score += value;
        Debug.Log($"Score: {_score}.");
    }

    public void PlayerLife(int value)
    {
        _life -= value;
        if (_life < 1)
        {
            Debug.Log("GameOver!");
            _life = 0;
            Time.timeScale = 0.0f;
        }
        Debug.Log($"Lifes: {_life}.");
    }
}
