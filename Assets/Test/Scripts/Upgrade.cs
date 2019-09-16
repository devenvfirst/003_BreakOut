using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 奖励道具类
/// </summary>
public class Upgrade : MonoBehaviour {


    public Sprite[] upgradeSprites;
    public string upgradeName;

	// Use this for initialization
	void Start () {

        Sprite icon = upgradeSprites[Random.Range(0, upgradeSprites.Length)];

        upgradeName = icon.ToString();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = icon;
    }
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y-0.05f,
            0);
        if(gameObject.transform.position.y <= -8f)
        {
            Destroy(this.gameObject);
        }
	}
}
