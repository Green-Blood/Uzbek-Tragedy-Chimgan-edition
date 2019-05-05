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

public class AchievementsManager : MonoBehaviour {

	private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
	public GameObject scorePrefab;
	public Transform scoreParent;
	public GameObject container;

	// Use this for initialization
	//Connect
	private List<Achievements> achievements = new List<Achievements>();
	void Start () {
		conn = "URI=file:" + Application.dataPath + "/gamedb.db"; 
		//GetAchievements();
		ShowAchievements();  
	}
	
	// Update is called once per frame
	void Update () {
		// float width = container.GetComponent<RectTransform>().rect.width;
		// Vector2 newSize = new Vector2(width / 2, width / 2);
		// container.GetComponent<GridLayoutGroup>().cellSize = newSize;
	}
	private void GetAchievements()
	{
		achievements.Clear();
		using(IDbConnection dbConnection = new SqliteConnection(conn))
		{
			dbConnection.Open();
			using(IDbCommand dbCmd = dbConnection.CreateCommand())
			{
				string sqlQuery = "SELECT * FROM achievements where achieved = 1";
				dbCmd.CommandText = sqlQuery;
				using(IDataReader reader = dbCmd.ExecuteReader())
				{
					while(reader.Read())
					{
						achievements.Add(new Achievements(reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4) ));	
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
	private void ShowAchievements()
	{
		GetAchievements();
		for(int i = 0; i < achievements.Count; i++)
		{
			GameObject tmpObject = Instantiate(scorePrefab);
			Achievements tmpScore = achievements[i];
			tmpObject.GetComponent<AchievementsScript>().SetAchievement(tmpScore.AchieveName, tmpScore.Cost.ToString(), tmpScore.Info, tmpScore.Achieved.ToString() );
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
