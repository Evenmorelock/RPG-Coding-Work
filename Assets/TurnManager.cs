using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public bool lose = false;
    public bool win = false;
    public bool nextRound = true;
    public GameObject players;
    public int playerNumber;
    public GameObject enemies;
    public int enemyNumber;
    public List<health> turnOrder;
    public List<health> newList;
    public bool turnEnded;
    public bool GO;
    // Update is called once per frame
    

    void Update()
    {
        playerNumber = players.transform.childCount;
        enemyNumber = enemies.transform.childCount;
        if (nextRound == true)
        {
            if (enemyNumber > 0)
            {
                for (int enemye = enemyNumber; enemye > 0; enemye--)
                {
                    int speed = -enemies.transform.GetChild(enemye - 1).GetComponent<health>().speed;
                    enemies.transform.GetChild(enemye - 1).GetComponent<Playerorenemy>().enabled = false;
                    enemies.transform.GetChild(enemye - 1).GetComponent<health>().nextTurn = speed + (int)Random.Range(-1, 1);
                    turnOrder.Add(enemies.transform.GetChild(enemye - 1).GetComponent<health>());
                }
            }
            else { win = true; }
            if (playerNumber > 0)
            {
                for (int enemye = playerNumber; enemye > 0; enemye--)
                {
                    int speed = -players.transform.GetChild(enemye - 1).GetComponent<health>().speed;
                    players.transform.GetChild(enemye - 1).GetComponent<Playerorenemy>().enabled = false;
                    players.transform.GetChild(enemye - 1).GetComponent<health>().nextTurn = speed + (int)Random.Range(-1, 1);
                    turnOrder.Add(players.transform.GetChild(enemye - 1).GetComponent<health>());
                    nextRound = false;
                }
            }
            else { lose = true; }
        }

        newList = turnOrder.OrderByDescending(x => x.nextTurn).ToList();

        Debug.Log(newList.Count);
        health first = newList.Last();


        if (GO == true)
        {
            first.GetComponent<Playerorenemy>().enabled = true;
            GO = false;
        }
        if (turnEnded == true)
        {
            Debug.Log("TURN HAS ENDED");
            first.GetComponent<Playerorenemy>().enabled = false;
            turnOrder.Remove(first);
            GO = true;
            turnEnded = false;
            if (turnOrder.Count == 0)
            {
                nextRound = true;
            }
        }
    }
}
