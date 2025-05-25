using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BikeSelection : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    [SerializeField] private Button buy;
    [SerializeField] private Button play;
    [SerializeField] private TextMeshProUGUI priceText;

    [SerializeField] private int[] bikePrices;
    private int currentBike;

    private void Awake()
    {
        SelectBike(0);
    }
    private void Start()
    {
        currentBike = SaveManager.instance.currentBike;
        SelectBike(currentBike);
    }

    private void SelectBike(int index)
    {
        previousButton.interactable = (index != 0);
        nextButton.interactable = (index != transform.childCount - 1);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
        UpdateUI();

    }

    private void UpdateUI()
    {
        if (SaveManager.instance.bikesUnlocked[currentBike])
        {
            play.gameObject.SetActive(true);
            buy.gameObject.SetActive(false);
        }
        else
        {
            play.gameObject.SetActive(false);
            buy.gameObject.SetActive(true);
            priceText.text = bikePrices[currentBike] + "$";

        }
    }

    private void Update()
    {
        if(buy.gameObject.activeInHierarchy)
        {
            buy.interactable = (SaveManager.instance.money >= bikePrices[currentBike]);
        }
        
    }

    public void ChangeBike(int change)
    {
        currentBike += change;

        if (currentBike > transform.childCount - 1)
            currentBike = 0;
        else if (currentBike < 0)
            currentBike = transform.childCount - 1;

        SaveManager.instance.currentBike = currentBike;
        SaveManager.instance.Save();

        SelectBike(currentBike);
    }

    public void BuyBike()
    {
        SaveManager.instance.money -= bikePrices[currentBike];
        SaveManager.instance.bikesUnlocked[currentBike] = true;
        SaveManager.instance.Save();
        UpdateUI();
    }
}
