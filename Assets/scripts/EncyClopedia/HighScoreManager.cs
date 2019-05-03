using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Yarn.Unity;
using Mono.Data.Sqlite;
using System;
using System.Data;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour {

	private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
	public GameObject scorePrefab;
	public Transform scoreParent;
	public GameObject container;

	// Use this for initialization
	//Connect
	private List<HighScore> highscores = new List<HighScore>();
	void Start () {
		conn = "URI=file:" + Application.dataPath + "/gamedb.db"; 
		//GetPlants();
		ShowScores();  
	}
	
	// Update is called once per frame
	void Update () {
		// float width = container.GetComponent<RectTransform>().rect.width;
		// Vector2 newSize = new Vector2(width / 2, width / 2);
		// container.GetComponent<GridLayoutGroup>().cellSize = newSize;
	}
	private void GetPlants()
	{
		highscores.Clear();
		using(IDbConnection dbConnection = new SqliteConnection(conn))
		{
			dbConnection.Open();
			using(IDbCommand dbCmd = dbConnection.CreateCommand())
			{
				string sqlQuery = "SELECT * FROM items";
				dbCmd.CommandText = sqlQuery;
				using(IDataReader reader = dbCmd.ExecuteReader())
				{
					while(reader.Read())
					{
						highscores.Add(new HighScore(reader.GetInt32(0), reader.GetString(1), reader.GetString(2) ));	
					}
					dbConnection.Close();
					reader.Close();
				}

			}
		}
	}
	private void insertvalue(int id, string name)
		{
			using (dbconn = new SqliteConnection(conn))
			{
				dbconn.Open(); //Open connection to the database.
				dbcmd = dbconn.CreateCommand();
				sqlQuery = string.Format("INSERT INTO Characters (ID, Name) values (\"{0}\",\"{1}\")",id,name);// table name
				dbcmd.CommandText = sqlQuery;
				dbcmd.ExecuteScalar();
				dbconn.Close();
			}
		}
		private void deletevalue(int id)
		{
			using (dbconn = new SqliteConnection(conn))
			{
				dbconn.Open(); //Open connection to the database.
				dbcmd = dbconn.CreateCommand();
				sqlQuery = string.Format("DELETE FROM Characters WHERE ID=\"{0}\"", id);// table name
				dbcmd.CommandText = sqlQuery;
				dbcmd.ExecuteScalar();
				dbconn.Close();
			}
		}
	private void ShowScores()
	{
		GetPlants();
		for(int i = 0; i < highscores.Count; i++)
		{
			GameObject tmpObject = Instantiate(scorePrefab);
			HighScore tmpScore = highscores[i];
			tmpObject.GetComponent<HighScoreScript>().SetScore("#" + (i+1).ToString(), tmpScore.Name, tmpScore.Score);
			tmpObject.transform.SetParent(scoreParent);
			//tmpObject.GetComponent<RectTransform().localScale = new Vector3(1,1,1);
		}
	}
	public string MainMenu;
    public void playMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
