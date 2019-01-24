using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject ScoreText;

    //スコア計算用変数
    public int score = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTextオブジェクトを取得
        this.ScoreText = GameObject.Find("ScoreText");
        

    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {

        //タグによって得点を変える
        if (other.gameObject.tag == "SmallStarTag" || other.gameObject.tag == "SmallCloudTag")
        {
            score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag" || other.gameObject.tag == "LargeCloudTag")
        {
            score += 20;
        }

        //ScoreTextにスコアを表示
        this.ScoreText.GetComponent<Text>().text = score.ToString();

    }

}