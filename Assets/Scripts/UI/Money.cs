using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField]
    private Text moneyText;

    [SerializeField]
    private DataManager dataManager;

    public void setMoney(int amount)
    {
        moneyText.text = amount.ToString();
    }
}
