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
    [SerializeField]private GameObject point2Text;
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
            pointText.SetActive(false);
            this.point2Text.GetComponent<Text>().text = "得点：" + point;
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
        if (collision.gameObject.tag == "LargeCloudTag")
        {
            point += 5;
        }
        if (collision.gameObject.tag == "SmallCloudTag")
        {
            point += 1;
        }
    }
}
