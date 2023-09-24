using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellingItem : MonoBehaviour
{
    [SerializeField] public Image objectImage;
    [SerializeField] public TMPro.TextMeshProUGUI nombre;
    [SerializeField] public TMPro.TextMeshProUGUI precio;
    [SerializeField] public Objeto objetoALaVenta;
}
