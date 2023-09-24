using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitEdificios : MonoBehaviour
{
    public void SalirEdificio()
    {
        Edificio.UnloadScene(CoroutineHolder.Instance, () => { });
    }
}
