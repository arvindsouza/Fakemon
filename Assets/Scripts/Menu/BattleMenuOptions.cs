using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleMenuOptions : MonoBehaviour {

    protected playerScript player;
    BattleScript battle;

    public GameObject[] fightOptions;
    public GameObject fightMenu, optionsMenu;
    public List<theMove> moves = new List<theMove>();
     protected static bool moveSelected;
    protected static theMove selectedMove;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<playerScript>();
        battle = FindObjectOfType<BattleScript>();
        var count = playerStats.Instance.playerMoves.Count;
        moves = playerStats.Instance.playerMoves;
        for (var i = 0; i < count ; i++)
        {
            fightOptions[i].GetComponent<UnityEngine.UI.Text>().text = playerStats.Instance.playerMoves[i].Name;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (moveSelected)
        {
            optionsMenu.SetActive(false);
        }
        else
            optionsMenu.SetActive(true);

    }

    public void Run()
    {
        player.inBattle = false;
        battle.battleCam.gameObject.SetActive(false);
        battle.regularCam.gameObject.SetActive(true);
        battle.battleUI.SetActive(false);
        Destroy(battle.theObject);
    }

    public void Fight()
    {
        fightMenu.SetActive(true);
    }

    public void chooseMove()
    {
        moveSelected = true;
        fightMenu.SetActive(false);
        string moveName = EventSystem.current.currentSelectedGameObject.GetComponent<UnityEngine.UI.Text>().text;
         selectedMove = null;
        foreach (theMove move in moves)
        {
            if(move.Name == moveName)
            {
                selectedMove = move;
            }
        }

        if(selectedMove.Type == "offensive")
        {
           // Debug.Log(selectedMove.Damage);
        }
    }

}
