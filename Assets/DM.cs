using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM : MonoBehaviour
{
    private bool gameOn;		 //　bool型の変数gameOnを用意します
    private Vector2 targetPos; 	  	//　Vector2型の変数targetPosを用意します
    public float power;    		 //　float型の変数 powerを用意します
    private Vector2 lastMousePos;        //　「最後にマウスのあった場所」を格納する変数を用意します
    public GameObject dragPointObj;  //　表示するスプライトを格納する変数dragPointObjを用意します

    void Start()
    {
        gameOn = true;            　　    //gameOnをtrueにします
    }
    void Update()
    {
        if (gameOn == true)			// もしgameOnフラグがtrueなら・・	
        {
            if (Input.GetMouseButton(2))		// もし、真ん中のマウスボタンが押されたら（押し続けた状態も含む）
            {
                lastMousePos = Input.mousePosition;          	// そのマウスの位置の座標を取得する
                targetPos = Camera.main.ScreenToWorldPoint(lastMousePos);  // マウスカーソルの位置をワールド座標targetPosに変換して入れます
                
                    dragPointObj.transform.position = targetPos;  //　dragPointObjの位置をtargetPosの位置にします
                    // dragPointObjオブジェクトを生成します（マウスカーソルの位置にスプライトを置いて行きます）
                    Instantiate(dragPointObj, targetPos, dragPointObj.transform.rotation);
                 
            }
            // このロケットオブジェクトの位置をtargetPosの位置に、ゆっくりと補完して移動させます
            transform.position = Vector2.Lerp(transform.position, targetPos, power);
        }
        else return;
    }
}
