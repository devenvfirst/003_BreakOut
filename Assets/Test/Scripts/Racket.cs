using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弹桌类
/// </summary>
public class Racket : MonoBehaviour
{
    public float speed = 10f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -5.2f)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            else
            {
                return;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            if (transform.position.x < 5.2f)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            else
            {
                return;
            }
        }
    }


    /// <summary>
    /// 弹桌碰到奖励物品
    /// </summary>
    /// <param name="name"></param>
    void PerformUpgrade(string name)
    {
        name = name.Remove(name.Length - 21);
        float x;
        Ball ballController = GameObject.Find("ball").GetComponent<Ball>();
    
        switch (name)
        {
            case "ball_speed_up":
                if (ballController.BallSpeed < 27)
                {
                    ballController.BallSpeed += 3;
                }
                break;
            case "ball_speed_down":
                if (ballController.BallSpeed > 18)
                {
                    ballController.BallSpeed -= 3;
                }
                break;
            case "paddle_size_up":
                x = gameObject.transform.localScale.x;
                if (x < 8.0f)
                {
                    gameObject.transform.localScale = new Vector3(x += 0.25f,
                        gameObject.transform.localScale.y,
                        1f);

                }
                break;
            case "paddle_size_down":
                x = this.gameObject.transform.localScale.x;
                if (x > 4.0f)
                {
                    gameObject.transform.localScale = new Vector3(x -= 0.25f,
                        gameObject.transform.localScale.y,
                        1f);
                }
                break;
            case "paddle_speed_up":
                speed += 3;
                break;
            case "paddle_speed_down":
                if(speed>7)
                {
                    speed -= 3;
                }
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "upgrade")
        {
            string name = col.gameObject.GetComponent<Upgrade>().upgradeName;

            PerformUpgrade(name);
            Destroy(col.gameObject);
        }
    }
}
