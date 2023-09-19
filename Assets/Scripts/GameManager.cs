using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance{ get; private set; }


    //Weight
    [SerializeField] int maxWeight;
    int currentWeight;

    //Days
    [SerializeField] int maxDays;
    int currentDays;

    //Money
    [SerializeField] int maxMoney;
    int currentMoney;

    //Action Points
    [SerializeField] int dayMaxActionPoints;
    [SerializeField] int nightMaxActionPoints;
    int currentActionPoints;

    //Noise
    [SerializeField] int maxNoise;
    int currentNoise;


    private void Awake()
    {

        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        currentWeight = 0;

        currentMoney = 0;

        currentDays = 1;

        currentActionPoints = dayMaxActionPoints;

        currentNoise = 0;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
