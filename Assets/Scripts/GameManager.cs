using Hedenrag.SceneLoader;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance { get; private set; }
    bool isOnHouse = false;
    //Weight
    [SerializeField] int maxWeight;
    public int MaxWeight => maxWeight;
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

    [SerializeField] List<Transform> transformes;

    [SerializeField]GameObject starsParent;

    [SerializeField] List<Image> stars;

    [SerializeField] UnityEvent endEvent;
    [SerializeField] UnityEvent winEvent;
    [SerializeField] UnityEvent nightEvent;

    bool isNight = false;

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

        for (int i = 0; i < starsParent.transform.childCount; i++)
        {
            stars.Add(starsParent.transform.GetChild(i).GetComponent<Image>());
        }
        DontDestroyOnLoad(this.gameObject);        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickManager.SetAllInventoriesInactive();
        }
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

        //TODO Enter NightMode
        if(!isNight && currentActionPoints < maxActionPoints / 2)
        {
            nightEvent.Invoke();
        }

        if (currentActionPoints <= 0)
        {
            if (isOnHouse == true)
            {
                GameOver();
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
        objetos.Add(obj);
        
        Debug.Log("Inventory wheight = " + GetPeso() + "/" + maxWeight);    
    }

    public void SellItemFromBag(Objeto obj)
    {
        currentMoney += obj.sellPrice;
        
        objetos.Remove(obj);

        if (currentMoney >= maxMoney)
        {
            WinGame();
        }
    }

    public int SellAllItems()
    {
        int total = 0;
        for (int i = objetos.Count - 1; i >= 0; i--)
        {
            if (!objetos[i].capacidades)
            {
                total += objetos[i].sellPrice;
                objetos.RemoveAt(i);
            }
        }
        currentMoney += total;
        if(currentMoney >= maxMoney)
        {
            WinGame();
            return total;
        }
        return total;
    }

    public int ShowPriceSellAllInventory()
    {
        int total = 0;
        for (int i = objetos.Count-1; i >= 0; i--)
        {
            if (!objetos[i].capacidades)
            {
                total += objetos[i].sellPrice;
            }
        }

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

    public List<Objeto> AllInventoryReturned()
    {
        return objetos;
    }

    public void QuitarDinero(int precio)
    {
        currentMoney -= precio;
    }

    public float GetPeso()
    {
        float pesototal = 0;

        for(int i = 0;i < objetos.Count; i++)
        {
            pesototal += objetos[i].peso;
        }

        return pesototal;
    }

    public void FalloHurto(float starChase)
    {
        bool hasFinished = false;
        float leftChase;
        float totalChase = starChase;

        for(int i = 0; i< stars.Count; i++)
        {
            if (stars[i].fillAmount < 1f)
            {
                leftChase = 1f - stars[i].fillAmount;
                if(leftChase >= totalChase)
                {
                    stars[i].fillAmount += totalChase;
                    hasFinished = true;
                    return;
                }
                else if(leftChase < totalChase)
                {
                    stars[i].fillAmount = 1f;
                    totalChase -= leftChase;
                       
                    if(totalChase<= 0f)
                    {
                        hasFinished = true;
                        return;
                    }
                }
            }
            if(hasFinished)
            {
                if (stars[stars.Count].fillAmount >= 1f)
                {
                    GameOver();
                }
                return;
            }
        }
    }



    public void GameOver()
    {
        endEvent.Invoke();
    }

    public void WinGame()
    {
        winEvent.Invoke();
    }

}
