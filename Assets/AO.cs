using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AO : MonoBehaviour
    {

    void OnCollisionEnter2D(Collision2D other)　 //　当たった相手のデータを変数otherに取り込みます
    {
        if (other.gameObject.tag == "Player")　　　//　もし相手(other)のtagが”Player”ならば
        {
            this.gameObject.SetActive(false);   　　　//　このオブジェクトをScene から消します（setを「止めます」）　
        }
    }

}

