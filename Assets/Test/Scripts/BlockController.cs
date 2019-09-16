using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 砖块控制类
/// </summary>
public class BlockController : MonoBehaviour {

    public GameObject upgradePfb;

    private void Start()
    {
        string spriteFileName = "Sprites/block_" + GetComponent<Block>().color;
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(spriteFileName);
    }

    /// <summary>
    /// 检测球与砖块的碰撞
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject go = Camera.main.gameObject;
        LevelLoader levelLoader = go.GetComponent<LevelLoader>();
        GetComponent<Block>().hits_required -= 1;
        if(GetComponent<Block>().hits_required == 0)
        {
            Destroy(gameObject);
            levelLoader.block_count--;

            //生成奖励道具
            if(Random.value < 0.5f)
            {
                Instantiate(upgradePfb,
                    new Vector3(col.transform.position.x,col.transform.position.y,0),
                    Quaternion.identity);
            }
        }
    }
}
