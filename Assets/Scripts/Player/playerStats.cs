using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {

    public static playerStats Instance { get; set; }

    int curLvl, curExp, reqExp, baseHp, baseAttack, baseDef, baseSpd, moveCount, curHp, totalHp;
    public int moveProp{ get { return this.moveCount; } set { } }
    public List<theMove> playerMoves = new List<theMove>();

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        addMove("sl");
        addMove("foetal");
    }

	// Use this for initialization
	void Start () {
        moveCount = 2;
        curLvl = 1;
        baseHp = 10;
        totalHp = baseHp;
        curHp = totalHp;
        curExp = 0;
        reqExp = 10; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void winBattle(int xpGain) 
    {
        curExp += xpGain;
        if(curExp > reqExp) //level up
        {
            curLvl++;
            var excessExp = reqExp - xpGain;
            curExp = excessExp;
            baseHp += 5;
            baseAttack += 5;
            baseDef += 5;
            baseSpd += 5;
            reqExp += 5;
            Debug.Log(curLvl);
        }
    }

    public void addMove(string moveId)
    {
        playerMoves.Add(movesList.Instance.getMove(moveId));
    }

    public void updateHp(int bonusHp)
    {
        totalHp = baseHp + bonusHp;
        curHp = totalHp;
    }

    public void takeDamage(int theDmg)
    {
        curHp -= theDmg;
        Debug.Log("curHp" + curHp);

        if (curHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}


