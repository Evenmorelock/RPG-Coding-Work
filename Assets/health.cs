using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class health : MonoBehaviour
{
    public int theHealth;
    public int nextTurn;
    public int speed;
    public bool isDead;

    public Playerorenemy character;
    public TurnManager turnManager;

    public void Start()// Update is called once per frame
    {
        character.SetHealth();
    }
    void Update()
    {

        if (theHealth > character.maxHealth)
        {
            theHealth = character.maxHealth;
        }


        if (theHealth <= 0)
        {
            theHealth = 0;
            isDead = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }
    }
}
