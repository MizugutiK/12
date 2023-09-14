using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DE : MonoBehaviour
{
    public float lifeTime = 2.0f;       //　浮動小数点型の変数lifeTimeを用意します、とりあえず数字を入れておきます

    void Start()
    {
        Destroy(gameObject, lifeTime);　　　　 //　このObjectを、「LifeTime」秒後に破壊します
    }

}
