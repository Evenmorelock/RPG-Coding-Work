using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public bool IsTurn;
    public GameObject pointer;
    public TMPro.TextMeshProUGUI healthDisplay;
    public health currentHealth;
    public Playerorenemy maxHealth;
    public string character;

    // Update is called once per frame
    void Update()
    {

        healthDisplay.text = character + ": " + currentHealth.theHealth + "/" + maxHealth.maxHealth;

    }
}
