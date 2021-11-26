using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveData: MonoBehaviour
{
	public TextMeshProUGUI ScoreText;       //スコア
	public TextMeshProUGUI HighScoreText;  //ハイスコア
	public int Score = 0;
	public int HighScore = 0;

	void Start()
    {
		PlayerPrefs.SetInt("Score", Score);
		PlayerPrefs.SetInt("HighScore", HighScore);
		Load();
	}

	public void Save()
	{
		//Scoreキーにハイスコアをセーブ
		PlayerPrefs.SetInt("Score", Score);
		PlayerPrefs.Save();

		//HighScoreキーにハイスコアをセーブ
		if (Score > HighScore)
		{
			PlayerPrefs.SetInt("HighScore", HighScore);
			PlayerPrefs.Save();
		}
	}

	public void Load()
	{
		ScoreText.text = "あなたのスコア：" + PlayerPrefs.GetInt("Score", 0).ToString("#");	
		HighScoreText.text = "ハイスコア：" + PlayerPrefs.GetInt("HighScore", 0).ToString("#");
	}

}
