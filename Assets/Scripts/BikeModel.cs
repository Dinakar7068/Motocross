using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeModel : MonoBehaviour
{
    [SerializeField] private GameObject[] bikeModels;

    private void Awake()
    {
        ChooseBikeModel(SaveManager.instance.currentBike);
    }

    private void ChooseBikeModel(int index)
    {
        Instantiate(bikeModels[index], transform.position, Quaternion.identity, transform);
    }
}
