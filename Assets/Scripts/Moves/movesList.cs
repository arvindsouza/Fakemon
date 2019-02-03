using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class movesList : MonoBehaviour {
    public static movesList Instance {get;set;}

    List<theMove> Moves = new List<theMove>();

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        populateList();

    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void populateList()
    {
        Moves = JsonConvert.DeserializeObject<List<theMove>>(Resources.Load<TextAsset>("moves").ToString());
    }

    public theMove getMove(string moveId)
    {
        foreach (theMove move in Moves)
        {
            if (move.Id == moveId)
                return move; 
        }
        return null;

    }
}
