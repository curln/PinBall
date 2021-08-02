using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController: MonoBehaviour
{
    //�{�[����������\���̂���z���̍ő�l
    private float visiblePosZ = -6.5f;
    int point;

    //�Q�[���I�[�o��\������e�L�X�g
    private GameObject gameoverText;
    private GameObject pointText;

    // Use this for initialization
    void Start()
    {
        //�V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find("GameOverText");
        pointText = GameObject.Find("PointText");
    }

    // Update is called once per frame
    void Update()
    {
        //�{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverText�ɃQ�[���I�[�o��\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";
            pointText.GetComponent<Text>().text = "���_�F" + point;
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
