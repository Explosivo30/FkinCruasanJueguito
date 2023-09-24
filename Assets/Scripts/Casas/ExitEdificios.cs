using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitEdificios : MonoBehaviour
{
    public void SalirEdificio()
    {
        GameManager.Instance.isOnHouse = false;
        Edificio.UnloadScene(CoroutineHolder.Instance, () => { GameManager.Instance.ResetNoise(); GameManager.Instance.MaxNoise(999f); });
    }
}
