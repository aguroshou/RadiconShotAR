using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickScript : MonoBehaviour
{
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
}
