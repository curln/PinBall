using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController: MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;
    int point;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    private GameObject pointText;
    RectTransform m_RectTransform;
    // Use this for initialization
    void Start()
    {
       
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        pointText = GameObject.Find("PointText");
        m_RectTransform = pointText.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {  
        pointText.GetComponent<Text>().text = "得点：" + point;
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
            this.m_RectTransform.anchoredPosition3D = new Vector3(-410, -1124, 0);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag")
        {
            point += 10;
        }
        if (collision.gameObject.tag == "LargeStarTag")
        {
            point += 20;
        }
    }
}
