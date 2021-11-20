using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    [SerializeField] private GameObject arCamera;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<GameObject> targetList;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private int limitTime;
    [SerializeField] private int currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = limitTime;
        StartCoroutine("CountDownTime");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject bullet = Instantiate(bulletPrefab, arCamera.transform.position, arCamera.transform.rotation);

            // arCameraの子オブジェクトにするとカメラの中心位置に固定されますが、直進しているわけではないです。
            //GameObject bullet = Instantiate(bulletPrefab, arCamera.transform);
        }

        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }

    IEnumerator CountDownTime()
    {
        while (currentTime>=0)
        {
            currentTime--;
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1.0f);
        }
        SceneManager.LoadScene("Result");
    }
}