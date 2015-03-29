using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;
using System.Text;

public class ScoreManager : MonoBehaviour {
	public static int score;
	
	Text text;

	int[] BestScore;

	string[] date;

	void Awake(){
		BestScore = new int[5];
		for (int i = 0; i < 5; i++) {
			BestScore[i] = 0;
		}
		date = new string[5];
		score = 0;
		text = GameObject.Find("Scoring/Text").GetComponent<Text>();
		if (Load ("D:/Classified/@IF/Kodingan/Unity/Maze/Assets/Scripts/_score.txt")) {}
	}
	void Update(){
		text.text = "Score : " + score;
	}

	void OnDestroy(){
		DateTime now = new DateTime ();
		bool stop = false;
		int count = 0;
		while(!stop && count < BestScore.Length){
			if(score > BestScore[count])
				stop = true;
			count++;
		}
		if (stop) {
			count--;
			int temp = 4;
			while(temp > count){
				BestScore[temp] = BestScore[temp - 1];
				date[temp] = date[temp - 1];
				temp--;
			}
			BestScore[count] = score;
			date[count] = now.ToString("yyyy/dd/MM HH:mm");
			date[count] += " " + score + "\n";
			//date[count] = now.Year + " " + now.Month + " " + now.Day + " " + now.Hour + " " + now.Minute + " " + now.Second  + " " + score + "\n";
		}
		if (Write ("D:/Classified/@IF/Kodingan/Unity/Maze/Assets/Scripts/_score.txt")) {}
	}

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
						BestScore[count] = Convert.ToInt32(entries[entries.Length - 1]);
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

	private bool Write(string fileName)
	{
		// Handle any problems that might arise when reading the text
		try {
				StreamWriter theWriter = new StreamWriter(fileName);

				using (theWriter) {
					// While there's lines left in the text file, do this:
					int count = 0;
					do {
						theWriter.WriteLine(date[count] + " " + BestScore[count]);
						count++;
					} while (count < BestScore.Length);
	
					// Done reading, close the reader and return true to broadcast success    
					theWriter.Close ();
					return true;
				}
			} catch (Exception e) {
					Console.WriteLine ("{0}\n", e.Message);
					return false;
			}
	}
}
