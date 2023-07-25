using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText;

    private void Update()
    {
        moneyText.text = "$" + PlayerStates.Money.ToString();
    }
}
