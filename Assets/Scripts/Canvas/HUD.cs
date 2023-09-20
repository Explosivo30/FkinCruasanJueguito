using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentActionPoints;
    [SerializeField] TextMeshProUGUI maxActionPoints;

    private void Awake()
    {
        currentActionPoints.text = GameManager.Instance.currentActionPoints.ToString();
        maxActionPoints.text = GameManager.Instance.maxActionPoints.ToString();
    }
}
