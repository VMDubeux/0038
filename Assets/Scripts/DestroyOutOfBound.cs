using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private GameManager _gameManager;
    private float _topBound = 25.0f;
    private float _bottomBound = -5.0f;
    private float _leftBound = -17.0f;
    private float _rightBound = 17.0f;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    void Update()
    {
        if (transform.position.z > _topBound) Destroy(gameObject);//Destrói objeto após passar da borda superior.
        else if (transform.position.z < _bottomBound) //Destrói objeto após passar da borda inferior e, quando acontece, faz aparecer a mensagem "Game Over".
        {
            Destroy(gameObject);
            if (_gameManager._score >= 1) _gameManager.Scorer(-1);
        }
        else if (transform.position.x > _rightBound) Destroy(gameObject); //Destrói objeto após passar da borda direita.
        else if (transform.position.x < _leftBound) Destroy(gameObject); //Destrói objeto após passar da borda esquerda.
    }
}
