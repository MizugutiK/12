using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nasu : MonoBehaviour
{
    public AudioClip snd01;             //鳴らす音データを格納する変数を用意します
    public AudioClip snd02;             //鳴らす音データを格納する変数を用意します
    private AudioSource audioS;    //AudioSourceを格納する変数を用意します

    public Text scoreText; //Text用変数
    private int score = 0; //スコア計算用変数
                           // Start is called before the first frame update

    GameObject gameCtrl;		//　GameObject型の変数　gameCtrlを用意します、このオブジェクトにGoalManagerクラスが入れられています
    GM script;		 //　GoalManagert型の変数　scriptを用意します　各クラス（スクリプト）はその型として変数を作ることができます

    void Start()
    {        //＊　スタート時に、Scene内にある”SoundSOurce”という名前のオブジェクトを探して、そこのAudioSourceコンポネントを持ってきます
        audioS = GameObject.Find("GA").GetComponent<AudioSource>();
    

    gameCtrl = GameObject.Find("GC"); 	//　変数gameCtrlに　GameControllerオブジェクトを見つけてきて入れます
        script = gameCtrl.GetComponent<GM>();	 //　変数scriptに　gameCtrlに入れられたGameControllerにあるGameManagerスクリプトを入れます

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "ナス:" + score;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "nasu") 	//当たった相手がPlayerのTagを持っていたならば・・
        {
            audioS.PlayOneShot(snd01);　//　PlayOneShot命令で、snd01に格納された音を一回鳴らします
            score = score + 1;
        }

        if (other.gameObject.tag == "tori" )　　　//　もし相手(other)のtagが”Player”ならば
        {
            if (score >= -1)
            {
                audioS.PlayOneShot(snd02);　//　PlayOneShot命令で、snd01に格納された音を一回鳴らします
                script.OverFlag();		 //　壊される直前に変数scriptに入ったGameManagerスクリプトにあるGoalFlag()メソッドを呼び、実行します
                this.gameObject.SetActive(false);      //　このオブジェクトをScene から消します（setを「止めます」）　

            }
           else {
                score -= 10;
            }

        }
    }
}
