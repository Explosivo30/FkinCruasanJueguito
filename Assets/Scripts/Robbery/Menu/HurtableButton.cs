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

    float probabilidadDeRobar;

    public void SetButton(Objeto objeto)
    {
        image.overrideSprite = objeto.image;
        itemName.text = objeto.name;
        itemPercentage.text = objeto.probabilidadDeRobar + "%";
        probabilidadDeRobar = objeto.probabilidadDeRobar;
    }

    public void Robar()
    {
        float roll = Random.Range(0f, 100f);
        if(roll > probabilidadDeRobar)
        {
            Debug.LogWarning("Not Implemented: robar fallo", this);
        }
        else
        {
            Debug.LogWarning("Not Implemented: robar acierto", this);
        }
    }
}
