using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour {

	// Use this for initialization
	
	public string AchieveName{get; set;}
	public string Info{get; set;}
	public int Cost{get; set;}
	public int Achieved{get; set;}
	 
	public Achievements(string achname,  int cost, string info, int achieved)
	{
		this.AchieveName = achname;
		this.Info = info;
		this.Cost = cost;
		this.Achieved = achieved;
	}
}
