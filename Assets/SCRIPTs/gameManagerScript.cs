using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class gameManagerScript : MonoBehaviour {

	public static bool unlock_africa;
	public static bool unlock_asia;
	public static bool unlock_australia;
	public static bool unlock_europe;
	public static bool unlock_am_sud;
	public static bool unlock_am_nord;
	public static bool unlock_antartic;

	public static bool select_africa;
	public static bool select_asia;
	public static bool select_australia;
	public static bool select_europe;
	public static bool select_am_sud;
	public static bool select_am_nord;
	public static bool select_antartic;

	private int gameLevels = 7;
	public static int unlockedGameLevels = 7;
	public static int selectedGameLevels = 0;

	public static bool mlevelSelected = false;

	public int score;
	//public GameData gameData;
	public Text scoreText;
	public Text timerText;

	public float startTime = 0;
	public float resumeTimer = 0;

	public bool initial = true;
    public bool startTimer = false;
    public bool pauseTimer = false;

	// Use this for initialization
	void Start () {
		unlock_africa = false;
		unlock_asia = false;
		unlock_australia = false;
		unlock_europe = false;
		unlock_am_sud = false;
		unlock_am_nord = false;
		unlock_antartic = false;
		
		score = 0;

		select_africa = false;
		select_asia = false;
		select_australia = false;
		select_europe = false;
		select_am_sud = false;
		select_am_nord = false;
		select_antartic = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*public void saveScore(System.String name){
		XmlSerializer serializer = new XmlSerializer(typeof(GameData));
		FileStream stream = new FileStream(Application.dataPath + "DataBase/XML/Scores.xml", FileMode.Create);
		serializer.Serialize(stream, score);
		stream.Close();
	}

	public void LoadScore(System.String name){
		XmlSerializer serializer = new XmlSerializer(typeof(GameData));
		FileStream stream = new FileStream(Application.dataPath + "DataBase/XML/Scores.xml", FileMode.Open);
		GameData playerScore = serializer.Deserialize(stream) as GameData;
		stream.Close();
	}*/
}
