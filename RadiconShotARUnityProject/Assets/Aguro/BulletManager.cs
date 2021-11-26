using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int moveCountLimit;
    [SerializeField] private bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        StartCoroutine("FireBullet");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator FireBullet()
    {
        for (int moveCount = 0; moveCount < moveCountLimit; moveCount++)
        {
            transform.position += transform.forward * moveSpeed;
            yield return null;
        }

        Destroy(this.gameObject);
        yield return null;
    }

    private void OnCollisionEnter(Collision collideObject)
    {
        if (isHit == false && collideObject.gameObject.CompareTag("Target"))
        {
            // 2回以上処理を実行させないためです。
            isHit = true;
            // どれだけ的の中心に当てたかスコア計算をします。
            this.gameObject.transform.parent = collideObject.transform;
            //this.gameObject.transform.rotation = collideObject.transform.rotation;
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Vector2 gameObjectXZ =
                new Vector2(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.z);

            // 弾を当てた場所がどれだけ的の中心に近いか計算します。(斜めから当てた場合は正確な位置を計算できなくなります。)
            float distance =
                Vector2.Distance(new Vector2(0, 0), gameObjectXZ);
            int addScore = 100 - (int)(distance * 100);
            Debug.Log(addScore);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + addScore);

            collideObject.gameObject.SetActive(false);

            // 次の番号のターゲットをActiveにする
            GameObject mainGameObject = GameObject.Find("MainGameScript");
            MainGame mainGame = mainGameObject.GetComponent<MainGame>();
            mainGame.SetNextTarget();

            Destroy(this.gameObject);
        }
    }
}