using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBattleScript : BattleScript {

    bool playerIsAtk, playerAtkComplete;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (moveSelected)
        {
            playerIsAtk = true;
        }
	}
}
