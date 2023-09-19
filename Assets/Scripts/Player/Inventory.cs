using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [SerializeField] int dinero;
    [SerializeField] List<Objeto> objetos;

    [SerializeField] List<Requerimiento> habilidadesActuales;

    public void AddItemsToBag(Objeto obj)
    {
        objetos.Add(obj);
        if (obj.capacidades) 
        { 
            foreach(Requerimiento req in obj.capacidades.Value)
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
        dinero += total;
        return total;
    }
}
