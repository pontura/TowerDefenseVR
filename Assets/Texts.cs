using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;

public class Texts : MonoBehaviour
{
	public string result = "";
	private string pathPreFix = @"file://";
	public Waves waves;

	void Start()
	{
		StartCoroutine(Example());
	}
	IEnumerator Example()
	{
		string filePath = pathPreFix + "waves.json";
		WWW www = new WWW(filePath);
		yield return www;
		result = www.text;
		LoadDataromServer(result);
	}
	public void LoadDataromServer(string json_data)
	{
		var Json = SimpleJSON.JSON.Parse(json_data);
		fillArray(Json);
	}
	private void fillArray(JSONNode content)
	{
		for (int a = 0; a < content.Count; a++)
		{
			AddWave(content[a]);
		}
	}
	void AddWave(JSONNode content)
	{
		print (content);
		for (int a = 0; a < content.Count; a++)
		{
			List<Enemy.types> enemies = new List<Enemy.types> ();
			for (int b = 0; b < content [a] ["enemies"].Count; b++) {
				
				Enemy.types type = Enemy.types.MEDIUM;
				switch (content [a] ["enemies"][b]) {
				case "0":
					type = Enemy.types.MEDIUM;
					break;
				case "1":
					type = Enemy.types.SMALL;
					break;
				case "2":
					type = Enemy.types.BIG;
					break;
				}
				enemies.Add (type);
				print ("________" + content [a] ["enemies"] [b] +  " type: " + type);
			}
			int delay = int.Parse(content [a] ["delay"]);
			waves.AddWave(enemies, delay);
		}
	}
}