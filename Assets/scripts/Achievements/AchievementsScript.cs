using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsScript : MonoBehaviour {

	// Use this for initialization
	public GameObject AchievementName;
	public GameObject Cost;
	public GameObject Info;
	public GameObject Achieved;
	public void SetAchievement(string achievementname, string cost, string info , string achieved)
	{
		this.AchievementName.GetComponent<Text>().text = achievementname;
		this.Cost.GetComponent<Text>().text = cost;
		this.Info.GetComponent<Text>().text = info;
		this.Achieved.GetComponent<Text>().text = achieved;

	}
}
