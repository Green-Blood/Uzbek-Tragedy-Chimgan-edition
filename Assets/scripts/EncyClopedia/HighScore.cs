using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore {

	public string Score { get; set;}
	public string Name {get; set;}
	public int ID { get; set;}
	public HighScore(int id, string name, string score)
	{
		this.Score = score;
		this.Name = name;
		this.ID = id;

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
