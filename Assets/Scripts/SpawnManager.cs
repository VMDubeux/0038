using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("GameObject 1:")]
    public GameObject[] AnimalPrefabs;
    
    //Private Variables:
    //Vertical:
    private float _rangeX_1 = 9.0f;
    private float _rangeZ_1 = 17.5f;
    //Horizontal:
    private float _rangeX_2 = 15.0f;
    private float _rangeZ_2_1 = 3.0f;
    private float _rangeZ_2_2 = 14.0f;
    //Spawn Time Vertical:
    private sbyte _spawnDelay = 2;
    private float _spawnRepeatTime = 2.0f;
    //Spawn Time Right:
    private sbyte _spawnDelay_1 = 3;
    private float _spawnRepeatTime_1 = 10.0f;
    //Spawn Time Left:
    private sbyte _spawnDelay_2 = 5;
    private float _spawnRepeatTime_2 = 15.0f;

    void Start()
    {
        InvokeRepeating("VerticalSpawnRandomAnimal", _spawnDelay, _spawnRepeatTime);
        InvokeRepeating("RightHorizontalSpawnRandomAnimal", _spawnDelay_1, _spawnRepeatTime_1);
        InvokeRepeating("LeftHorizontalSpawnRandomAnimal", _spawnDelay_2, _spawnRepeatTime_2);
    }

    void Update()
    {

    }

    void VerticalSpawnRandomAnimal() 
    {
        int _animalIndex = Random.Range(0, AnimalPrefabs.Length);
        Vector3 _animalStartPosition = new Vector3(Random.Range(-_rangeX_1, _rangeX_1), 0, _rangeZ_1);
        GameObject _animal = Instantiate(AnimalPrefabs[_animalIndex], _animalStartPosition, AnimalPrefabs[_animalIndex].transform.rotation);
        _animal.tag = "Animal";
    }

    void RightHorizontalSpawnRandomAnimal() 
    {
        int _animalIndex = Random.Range(0, AnimalPrefabs.Length);
        Vector3 _animalStartPosition = new Vector3(_rangeX_2, 0, Random.Range(_rangeZ_2_1, _rangeZ_2_2));
        Vector3 _animalRotation = new Vector3(0, -90, 0);
        GameObject _animal =  Instantiate(AnimalPrefabs[_animalIndex], _animalStartPosition, Quaternion.Euler(_animalRotation));
        _animal.tag = "AgressiveAnimal";
    }

    void LeftHorizontalSpawnRandomAnimal() 
    {
        int _animalIndex = Random.Range(0, AnimalPrefabs.Length);
        Vector3 _animalStartPosition = new Vector3(-_rangeX_2, 0, Random.Range(_rangeZ_2_1, _rangeZ_2_2));
        Vector3 _animalRotation = new Vector3(0, 90, 0);
        GameObject _animal = Instantiate(AnimalPrefabs[_animalIndex], _animalStartPosition, Quaternion.Euler(_animalRotation));
        _animal.tag = "AgressiveAnimal";
    }
}
