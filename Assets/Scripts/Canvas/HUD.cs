using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentActionPoints;
    [SerializeField] TextMeshProUGUI currentMoney;
    [SerializeField] TextMeshProUGUI maxDebt;

    private void Awake()
    {
        currentActionPoints.text = GameManager.Instance.currentActionPoints.ToString();
        currentMoney.text = GameManager.Instance.currentMoney.ToString();
        maxDebt.text = GameManager.Instance.maxMoney.ToString();
    }


    private void FixedUpdate()
    {
        currentMoney.text = GameManager.Instance.currentMoney.ToString();
        currentActionPoints.text = GameManager.Instance.currentActionPoints.ToString();
    }
}
