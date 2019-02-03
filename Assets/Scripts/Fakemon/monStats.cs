using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monStats : MonoBehaviour, IMonInterface{

    int curHp, baseHp;
    public int noMoves;
    protected List<theMove> enemMoves = new List<theMove>();
    public int expVal;
    playerStats playerstats;

    void Awake()
    {
        playerstats = FindObjectOfType<playerStats>();
        addMove("sl");
    }

    // Use this for initialization
    void Start () {
        baseHp = 10;
        curHp = baseHp;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void attack(int atkDmg)
    {
        playerstats.takeDamage(atkDmg);
    }

    public bool damage(int damage)
    {
        curHp -= damage;
        Debug.Log("EnemyHp" + curHp);
        if (curHp <= 0)
        {
         //   Destroy(gameObject);
            return true;
        }
        else
            return false;

    }

    public void addMove(string moveId)
    {
        enemMoves.Add(movesList.Instance.getMove(moveId));
    }
}
