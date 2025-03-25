using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int theHealth;
    public int nextTurn;
    public int speed;

    // Update is called once per frame
    void Update()
    {

        if (theHealth <= 0)
        {
            theHealth = 0;
            Destroy(gameObject);
        }
    }
}
