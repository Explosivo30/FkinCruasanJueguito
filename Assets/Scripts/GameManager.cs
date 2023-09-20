using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance { get; private set; }

    bool isOnHouse = false;

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
    public int maxActionPoints;
    [NonSerialized] public int currentActionPoints;

    //Noise
    [SerializeField] int maxNoise;
    int currentNoise;


    [SerializeField] List<Objeto> objetos;

    [SerializeField] List<Requerimiento> habilidadesActuales;

    private void Awake()
    {

        if (Instance != null)
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

        currentActionPoints = maxActionPoints;

        currentNoise = 0;
    }


    public void ReduceActionPoints(int reductionPoints)
    {
        currentActionPoints -= reductionPoints;
        if (currentActionPoints <= 0)
        {
            if (isOnHouse == true)
            {
                ExitHouse();
            }
        }
    }


    public void EnterHouse(int maxNoise, int currentNoiseEnter = 0)
    {
        isOnHouse = true;
        MaxNoise(maxNoise);
        currentNoise = currentNoiseEnter;
    }

    public void ExitHouse()
    {
        isOnHouse = false;
        //Load Street Map
    }


    public void ResetNoise()
    {
        currentNoise = 0;
    }


    public void MaxNoise(int maxNoise)
    {
        this.maxNoise = maxNoise;
    }


    

    public void AddItemsToBag(Objeto obj)
    {
        objetos.Add(obj);
        if (obj.capacidades)
        {
            foreach (Requerimiento req in obj.capacidades.Value)
            {
                habilidadesActuales.Add(req);
            }
        }
    }

    public void SellItemFromBag(Objeto obj)
    {

        if (obj.capacidades)
        {
            foreach (Requerimiento req in obj.capacidades.Value)
            {
                habilidadesActuales.Add(req);
            }
        }
        objetos.Remove(obj);
    }

    public int SellAllItems()
    {
        int total = 0;
        for (int i = objetos.Count; i >= 0; i--)
        {
            if (!objetos[i].capacidades)
            {
                total += objetos[i].sellPrice;
                objetos.RemoveAt(i);
            }
        }
        currentMoney += total;
        return total;
    }

}
