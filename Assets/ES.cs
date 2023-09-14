using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ES : MonoBehaviour
{
	private bool gameOn;         //　bool型の変数gameOnを用意します
	public GameObject enemy;            //enemyのPrefabを格納する変数を用意します

	private void Start()
	{
		gameOn = true;                  //gameOnをtrueにします
		InvokeRepeating("EnemySet", 1.0f, 1.0f);    //　関数を繰り返し呼び出すメソッド、2秒後に、3秒ごとに”EnemySet”関数を呼び出します
	}

	void EnemySet()     //エネミーをセットするメソッド、　はじめから繰り返して呼び出されます
	{               //生成する位置を決めます、ｘの値とｙの値を、Randam.Range(A,B)で範囲を決めてランダムに設定します
		Vector3 setPos = new Vector3(Random.Range(-6.0f, 6.0f), Random.Range(5.0f, 6.0f), 0);
		Instantiate(enemy, setPos, transform.rotation);     //Instantiate関数（prefab、場所、回転角度）で、生成します
	}

	private void Update()
	{
		if (gameOn != true) //　もしｍGameManagerのgameOnフラグが真（true）でなければ
		{
			CancelInvoke("EnemySet");       //　EnemySetメソッドを呼び出すことを止めます
		}
	}
}
