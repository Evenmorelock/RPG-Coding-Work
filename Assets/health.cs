using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class health : MonoBehaviour
{
    public int theHealth;
    public int nextTurn;
    public int speed;

    public Playerorenemy character;

    public void Start()// Update is called once per frame
    {
        character.SetHealth();
    }
    void Update()
    {

        if (theHealth <= 0)
        {
            theHealth = 0;
            Destroy(gameObject);
        }
    }
}
