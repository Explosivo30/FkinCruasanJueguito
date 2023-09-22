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

    //Days
    [SerializeField] int maxDays;

    //Money
    [SerializeField] public int maxMoney;
    [NonSerialized] public int currentMoney;

    //Action Points
    public int maxActionPoints;
    [NonSerialized] public int currentActionPoints;

    //Noise
    [SerializeField] int maxNoise;
    int currentNoise;

    [SerializeField] List<Objeto> objetos;


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

        currentMoney = 0;

        currentActionPoints = maxActionPoints;

        currentNoise = 0;
    }

    public void RemoveItemInventory(Objeto obj)
    {
        for(int i = 0; i < objetos.Count; i++)
        {
            if (objetos[i] == obj)
            {
                objetos.Remove(obj);
            }
        }
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

    public void AddToBag(Objeto obj)
    {
        if(maxWeight<GetPeso() + obj.peso)
        {
            objetos.Add(obj);
        }
        else
        {
            Debug.Log("Your inventory Is Full");
        }
        
    }

    public void SellItemFromBag(Objeto obj)
    {
        currentMoney += obj.sellPrice;
        
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

    public List<Objeto> DevolverObjeto()
    {
        List<Objeto> objetosUtiles = new List<Objeto>();
        for(int i = 0; i < objetos.Count; i++)
        {
            if (objetos[i].capacidades)
            {
                 objetosUtiles.Add(objetos[i]);
            }
        }
        return objetosUtiles;
    }


    public void QuitarDinero(int precio)
    {
        currentMoney -= precio;
    }

    public int GetPeso()
    {
        int pesototal = 0;

        for(int i = 0;i < objetos.Count; i++)
        {
            pesototal += (int)objetos[i].peso;
        }

        return pesototal;
    }


    public void CargarFinalDelJuego()
    {
        //Load Scene
    }

}
