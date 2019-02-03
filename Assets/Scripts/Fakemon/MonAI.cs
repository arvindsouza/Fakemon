using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonAI : monStats {


    int counter = 1;
	// Use this for initialization
	void Start () {
        Debug.Log(BattleScript.enemyTurn);
	}
	
	// Update is called once per frame
	void Update () {

      if (BattleScript.enemyTurn && counter == 1)
        {
            counter++;
            attack(enemMoves[0].Damage);
        }
        else if(!BattleScript.enemyTurn)
        {
            counter = 1;
        }
        
	}



}
