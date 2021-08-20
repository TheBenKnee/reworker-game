using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridChanges : MonoBehaviour
{
    [SerializeField] int timeBetweenFlowerChanges;
    private int flowerAge;
    private bool changeFlowers = false;

    [SerializeField] private GameObject flower1Tilemap1;
    [SerializeField] private GameObject flower1Tilemap2;
    [SerializeField] private GameObject flower2Tilemap1;
    [SerializeField] private GameObject flower2Tilemap2;

    void OnEnable()
    {
        flowerAge = timeBetweenFlowerChanges;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        flowerAge -= 1;
        if(flowerAge <= 0)
        {
            changeFlowers = true;
            flowerAge = timeBetweenFlowerChanges;
        }
        if(changeFlowers)
        {
            flower1Tilemap1.SetActive(!flower1Tilemap1.activeSelf);
            flower2Tilemap1.SetActive(!flower2Tilemap1.activeSelf);
            flower1Tilemap2.SetActive(!flower1Tilemap2.activeSelf);
            flower2Tilemap2.SetActive(!flower2Tilemap2.activeSelf);
            changeFlowers = false;
        }    
    }
}
