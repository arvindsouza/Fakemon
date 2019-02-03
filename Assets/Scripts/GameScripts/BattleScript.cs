using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BattleScript : BattleMenuOptions {

    public Camera battleCam, regularCam;
    public float commonRate, uncommonRate, rareRate;
    public GameObject[] fakemonCommon = new GameObject[] {};
    float counter;
    public GameObject spawnPoint, battleUI, theObject;
    public static bool playerTurn, enemyTurn;
    bool isDead;
    playerStats playerExp;

	// Use this for initialization
	void Start () {
        playerTurn = true;
        enemyTurn = false;
        player = FindObjectOfType<playerScript>();
        playerExp = FindObjectOfType<playerStats>();
	}
	
	// Update is called once per frame
	void Update () {

        if (moveSelected && playerTurn && player.inBattle)
        {
            //   playerTurn = false;
            Debug.Log("fighting");
            StartCoroutine(attack(selectedMove.Damage, theObject));
        }

	}

    public void startBattle()
    {
        counter = Random.Range(1f, 100f);
        battleUI.SetActive(true); //display menu

      //  if(counter <= commonRate && counter >= uncommonRate)
        {
            var arrValue = Random.Range(0, 2);
            theObject = Instantiate(fakemonCommon[arrValue], spawnPoint.transform);
        }
        battleCam.gameObject.SetActive(true); //change to battle camera
        regularCam.gameObject.SetActive(false);
    }

    IEnumerator attack(int damage, GameObject enemy)
    {
        if(enemy)
        isDead = enemy.GetComponent<monStats>().damage(damage);

        if (isDead && enemy)
        {
              playerExp.winBattle(enemy.GetComponent<monStats>().expVal);
            Debug.Log("killed");
            Destroy(enemy);
            yield return new WaitForSeconds(2);
            battleCam.gameObject.SetActive(false);
            regularCam.gameObject.SetActive(true);
            player.inBattle = false;
            battleUI.SetActive(false);
            yield break;
        }

        playerTurn = false;
        yield return new WaitForSeconds(2);
        enemyTurn = true;
        yield return new WaitForSeconds(2);
        enemyTurn = false;
        moveSelected = false;
        playerTurn = true;
    }

}
