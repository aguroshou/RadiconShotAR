using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class MainGame : MonoBehaviour
{
    [SerializeField] private GameObject arCamera;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<GameObject> targetList;
    [SerializeField] private Image nextTargetImage;
    [SerializeField] private List<Image> nextTargetImageList;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private int limitTime;
    [SerializeField] private int currentTime;
    [SerializeField] private int currentTargetNumber;

    // Start is called before the first frame update
    void Start()
    {
        for (int targetNumber = 0; targetNumber < 10; targetNumber++)
        {
            targetList[targetNumber].SetActive(false);
        }

        currentTargetNumber = Random.Range(0, 10);
        targetList[currentTargetNumber].SetActive(true);
        //nextTargetImage = nextTargetImageList[targetRandomNumber];
        Debug.Log("Target = " + currentTargetNumber);
        currentTime = limitTime;
        StartCoroutine("CountDownTime");
        PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject bullet = Instantiate(bulletPrefab, arCamera.transform.position, arCamera.transform.rotation);

            // arCameraの子オブジェクトにするとカメラの中心位置に固定されますが、銃の弾が直進しなくなります。
            //GameObject bullet = Instantiate(bulletPrefab, arCamera.transform);
        }

        scoreText.text = "スコア：" + PlayerPrefs.GetInt("Score").ToString();
    }

    public void SetNextTarget()
    {
        int nextTargetNumber;
        do
        {
            nextTargetNumber = Random.Range(0, 10);
        } while (nextTargetNumber != currentTargetNumber);

        currentTargetNumber = nextTargetNumber;
        targetList[currentTargetNumber].SetActive(true);
        //nextTargetImage = nextTargetImageList[targetRandomNumber];
        Debug.Log("Target = " + currentTargetNumber);
    }

    IEnumerator CountDownTime()
    {
        while (currentTime >= 0)
        {
            currentTime--;
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1.0f);
        }

        SceneManager.LoadScene("Result");
    }

}