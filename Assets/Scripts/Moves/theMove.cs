using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theMove {

    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public int Damage { get; set; }


    public theMove(string Id, string Name, string Description, string Type, int Damage)
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.Type = Type;
        this.Damage = Damage;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
