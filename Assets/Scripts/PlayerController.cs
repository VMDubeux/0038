using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Pizza GameObjects:")]
    public GameObject PizzaPrefab;
    public GameObject PizzaSpawnPoint;

    //Private variables:
    //Speed:
    [SerializeField] private float _speed = 10.5f;
    //Inputs:
    private float _inputHorizontal;
    private float _inputVertical;
    //Pizza:
    private float _lastPizzaTime = 0.0f;
    private float _nextPizzaDelay = 0.15f;


    void Start()
    {

    }

    void Update()
    {
        PlayerOffsetInputs();
        HorizontalOffset();
        VerticalOffset();
        PizzaInstantiate();
    }

    private void PlayerOffsetInputs()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");
        _inputVertical = Input.GetAxis("Vertical");
    }

    private void HorizontalOffset()
    {
        transform.Translate(Vector3.right * _inputHorizontal * Time.deltaTime * _speed); //Horizontal offset.

        switch (transform.position.x) //Player horizontal offset limits.
        {
            case < -12:
                transform.position = new Vector3(-12, transform.position.y, transform.position.z);
                break;
            case > 12:
                transform.position = new Vector3(12, transform.position.y, transform.position.z);
                break;
        }
    }

    private void VerticalOffset()
    {
        transform.Translate(Vector3.forward * _inputVertical * Time.deltaTime * _speed); //Vertical offset.

        switch (transform.position.z) //Player vertical offset limits.
        {
            case > 10.5f:
                transform.position = new Vector3(transform.position.x, transform.position.y, 10.5f);
                break;
            case < 1.5f:
                transform.position = new Vector3(transform.position.x, transform.position.y, 1.5f);
                break;
        }
    }

    private void PizzaInstantiate()
    {
        float _time = Time.time;

        if (Input.GetKeyDown(KeyCode.Space) && _time - _lastPizzaTime > _nextPizzaDelay) //Creating pizza colliders.
        {
            Instantiate(PizzaPrefab, PizzaSpawnPoint.transform.position, PizzaPrefab.transform.rotation);
            _lastPizzaTime = _time;
        }
    }
}
