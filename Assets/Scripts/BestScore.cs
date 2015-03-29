using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;
using System.Text;

public class BestScore : MonoBehaviour {

	Text text;
	string[] date;
	int[] bestScore;
	// Use this for initialization
	void Start () {
		text = GameObject.Find("Best Score/Text").GetComponent<Text>();
		date = new string[5];
		bestScore = new int[5];
		for (int i = 0; i < 5; i++) {
			bestScore[i] = 0;
		}
		if(Load("D:/Classified/@IF/Kodingan/Unity/Maze/Assets/Scripts/_score.txt")) {}
		bestScoring ();
	}
	
	void bestScoring(){
		string x = "Best Score :\n";
		int i = 1;
		foreach (string temp in date) {
			x += i + ". " + "Date : "  + temp + "\n";
			x += "Score : " + bestScore[i-1] + "\n";
			i++;
		}
		text.text = x;
	}

	// Update is called once per frame
	void Update () {
	
	}

	void onDestroy(){}

	private bool Load(string fileName)
	{
		try
		{
			string line;
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);
			using (theReader)
			{
				int count = 0;
				do
				{
					line = theReader.ReadLine();
					if (line != null)
					{
						string[] entries = line.Split(' ');
						for(int i = 0; i < entries.Length - 1; i++){
							date[count] += entries[i] + " ";
						}
						bestScore[count] = Convert.ToInt32(entries[entries.Length - 1]);
					}
					count++;
				}
				while (line != null);
				
				theReader.Close();
				return true;
			}
		}
		
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (Exception e)
		{
			Console.WriteLine("{0}\n", e.Message);
			return false;
		}
	}
}
