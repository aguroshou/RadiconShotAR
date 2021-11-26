using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickScript : MonoBehaviour
{
    //画像切り替え用
    public SpriteRenderer SpriteRenderer;
    public Sprite[] Sprites;
    public int SpriteNum = 0;

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnClickHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void OnClickTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnClickNext()
    {
        SpriteNum = (SpriteNum + 1) % 3;
        SpriteRenderer.sprite = Sprites[SpriteNum];
    }

    public void OnClickBack()
    {
        SpriteNum = (SpriteNum + 2) % 3;
        SpriteRenderer.sprite = Sprites[SpriteNum];
    }
}