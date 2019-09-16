using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 小球类
/// </summary>
public class Ball : MonoBehaviour {

    //小球的速度
    public float BallSpeed = 10f;
    int num = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.anyKey && num==0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * BallSpeed;
            num++;
        }

        if(transform.position.y < -8f)
        {
            SceneManager.LoadScene("Main");
        }
	}


    /// <summary>
    /// 反弹公式
    /// </summary>
    /// <param name="ballPos"></param>
    /// <param name="racketPos"></param>
    /// <param name="racketWidth"></param>
    /// <returns></returns>
    float HitFactor(Vector2 ballPos,Vector2 racketPos,float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    /// <summary>
    /// 计算小球反弹方向的函数
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "racket" && num==1)
        {
            float x = HitFactor(transform.position,col.transform.position,col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x,1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * BallSpeed;
        }
    }
}
