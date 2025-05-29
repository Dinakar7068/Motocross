using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] bikeModels;
    [SerializeField] private int bike_no = 0;
    private void Awake()
    {
        ChooseBikeModel(bike_no);
    }

    private void ChooseBikeModel(int index)
    {
        Instantiate(bikeModels[index], transform.position, Quaternion.identity, transform);
    }
}
