using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveData: MonoBehaviour
{
	public TextMeshProUGUI ScoreText;       //�X�R�A
	public TextMeshProUGUI HighScoreText;  //�n�C�X�R�A
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
		//Score�L�[�Ƀn�C�X�R�A���Z�[�u
		PlayerPrefs.SetInt("Score", Score);
		PlayerPrefs.Save();

		//HighScore�L�[�Ƀn�C�X�R�A���Z�[�u
		if (Score > HighScore)
		{
			PlayerPrefs.SetInt("HighScore", HighScore);
			PlayerPrefs.Save();
		}
	}

	public void Load()
	{
		ScoreText.text = "���Ȃ��̃X�R�A�F" + PlayerPrefs.GetInt("Score", 0).ToString("#");	
		HighScoreText.text = "�n�C�X�R�A�F" + PlayerPrefs.GetInt("HighScore", 0).ToString("#");
	}

}
