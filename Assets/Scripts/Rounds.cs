using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour
{
    public Text nextrounds;

    public void Update()
    {
        nextrounds.text = "Waves " + PlayerStates.rounds.ToString();
    }
}
