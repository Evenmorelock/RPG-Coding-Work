using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;

public class Playerorenemy : MonoBehaviour
{
    public bool isEnemy;
    public bool bigEnemy;
    public GameObject players;
    public bool canAttack;
    public List<health> playerss;
    public GameObject myGameObject;
    public GameObject target;
    public health myHealth;
    public int damageToDeal;
    public Button yourButton;
    public bool attacking;
    public Button attackButton;
    public int maxHealth;
    public bool buttonClicked;
    public Camera _mainCamera;
    public GameObject thingHit;
    public TextMeshProUGUI deathCondition;
    public TurnManager turnManager;
    public Button healthHeal;
    public int healthToHeal;
    public GameObject pointer;

    public void SetHealth()
    {
        if (isEnemy == true && bigEnemy == false)
        {
            myHealth.theHealth = Random.Range(9, 15);
            maxHealth = myHealth.theHealth;
        }
        if (isEnemy == true && bigEnemy == true)
        {
            myHealth.theHealth = Random.Range(20, 27);
            maxHealth = myHealth.theHealth;
        }
        if (isEnemy == false)
        {
            myHealth.theHealth = Random.Range(15, 20);
            maxHealth = myHealth.theHealth;
        }
        if (isEnemy == false && bigEnemy == true)
        {
            deathCondition.text = "Condition; Dead";
            Destroy(myGameObject);
        }

    }
    void Update()
    {
        if (myHealth.theHealth <= 0)
        {
            Destroy(this.gameObject);
        }
        Button btn = yourButton.GetComponent<Button>();
        pointer.SetActive(true);

        if (isEnemy == false)
        {
            damageToDeal = Random.Range(8, 12);
            healthToHeal = Random.Range(7, 12);
        }
        else
        {
            for (int playerCount = players.transform.childCount; playerCount > 0; playerCount--)
            {
                playerss.Add(players.transform.GetChild(playerCount - 1).transform.GetComponent<health>());
            }
            List<health> newList2 = playerss.OrderByDescending(x => x.theHealth).ToList();
            GameObject target;
            if (newList2.Last().GetComponent<health>().theHealth <= damageToDeal)
            {
                target = newList2.Last().gameObject;
            }
            else 
            { 
                target = players.transform.GetChild(Random.Range(0, players.transform.childCount - 1)).gameObject; 
            }
            target.GetComponent<health>().theHealth -= damageToDeal + Random.Range(-1, 1);
            turnManager.turnEnded = true;
        }

        

    }

    public void OnEnable()
    {
        attackButton.onClick.AddListener(EnableAttack);
        healthHeal.onClick.AddListener(heal);
    }

    public void OnDisable()
    {
        pointer.SetActive(false);
        attackButton.onClick.RemoveListener(EnableAttack);
        healthHeal.onClick.RemoveListener(heal);

    }

    void EnableAttack()
    {
        if (isEnemy == false)
        {
            canAttack = true;
            Debug.Log("Attack Enabled: " + canAttack);
        }
    }

    void heal()
    {
        
         gameObject.GetComponent<health>().theHealth += healthToHeal;
        turnManager.turnEnded = true;

    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("Click1");
        if (isEnemy == false && canAttack == true)
        {
            Debug.Log("Click2");
            if (!context.started) return;
            var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

            if (!rayHit.collider) return;
            if (rayHit.collider != null)
            {
                if (rayHit.collider.gameObject.tag != "Player")
                    rayHit.collider.gameObject.GetComponent<health>().theHealth -= damageToDeal;
                canAttack = false;
                pointer.SetActive(false);
                turnManager.turnEnded = true;
            }
            else
            {
                Debug.Log("No object hit.");
            }
        }
    }

}
