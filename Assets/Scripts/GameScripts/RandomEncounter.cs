using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEncounter : MonoBehaviour {

   public float encounterChance;
    public bool isBattling = false;
    float chance;
    BattleScript theBattle;
    playerScript player;
   
   //public Camera battleCam, regularCam;

	// Use this for initialization
	void Start () {
        theBattle = FindObjectOfType<BattleScript>();
        player = FindObjectOfType<playerScript>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player") //check if Object on tile is player
        {
            chance = Random.Range(1f, 100f);
            if(chance <= encounterChance) // encountered a fakemon
            {
                theBattle.startBattle();
                player.inBattle = true;
            }
        }
    }
}
