﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScoreScript : MonoBehaviour {

	// Use this for initialization
	public GameObject score;
	public GameObject scoreName;
	public GameObject rank;
	public void SetScore(string rank, string name, string score )
	{
		this.rank.GetComponent<Text>().text = rank;
		this.scoreName.GetComponent<Text>().text = name;
		this.score.GetComponent<Text>().text = score;

	}
}
