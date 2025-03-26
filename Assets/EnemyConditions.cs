using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConditions : MonoBehaviour
{
    public TMPro.TextMeshProUGUI condition;
    public Playerorenemy maxHealth;
    public health currentHealth;

    // Update is called once per frame
    void Update()
    {
        if (currentHealth.theHealth <= maxHealth.maxHealth /2 && currentHealth.theHealth >= 1)
        {
            condition.text = "Condition: Hurt";
        }
        if (currentHealth.theHealth >= maxHealth.maxHealth/2)
        {
            condition.text = "Condition: Healthy";
        }
        if (currentHealth.theHealth <= 0) 
        {
            condition.text = "Condition: Dead";
        }
    }
}
