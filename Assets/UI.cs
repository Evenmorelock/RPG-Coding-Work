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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTurn)
        { 
            pointer.SetActive(true);
        }
        else
        {
            pointer.SetActive(false);
        }

        healthDisplay.text = character + ": " + currentHealth.theHealth + "/" + maxHealth.maxHealth;

    }
}
