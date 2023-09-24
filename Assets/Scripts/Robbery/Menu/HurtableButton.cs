using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HurtableButton : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemPercentage;
    [SerializeField] Image image;

    Robable target;
    Objeto objeto;

    float probabilidadDeRobar;

    public void SetButton(Objeto objeto, Robable robable)
    {
        this.objeto = objeto;
        this.target = robable;
        image.overrideSprite = objeto.image;
        itemName.text = objeto.name;
        itemPercentage.text = objeto.probabilidadDeRobar + "%";
        probabilidadDeRobar = objeto.probabilidadDeRobar;
    }

    public void Robar()
    {
        if (GameManager.Instance.MaxWeight < (GameManager.Instance.GetPeso() + objeto.peso))
        {
            Debug.Log("Your inventory Is Full");
            return;
        }

        GameManager.Instance.ReduceActionPoints(1);

        if (GameManager.Instance.isOnHouse)
        {
            GameManager.Instance.AddRuido(objeto.ruido);
            GameManager.Instance.AddToBag(objeto);
            target.objetos.Remove(objeto);
            Destroy(gameObject);
        }
        else
        {
            float roll = Random.Range(0f, 100f);
            if (roll > probabilidadDeRobar)//fallo
            {
                Debug.LogWarning("Not Implemented: robar fallo", this); 
                GameManager.Instance.FalloHurto(1.2f);
                //TODO robar fallo logic
            }
            else//acierto
            {
                GameManager.Instance.AddToBag(objeto);
                //TODO DONEadd to inventory
                target.objetos.Remove(objeto);
                Destroy(gameObject);
            }
        }
    }
}
