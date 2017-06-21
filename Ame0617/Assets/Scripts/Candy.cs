using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Candy : MonoBehaviour {
    
    private Rigidbody2D rb2d;
    
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    
        // 乱数で柄の配色を決定
        var pattern = Random.Range(0, 5);
        var color = Color.white;
        switch(pattern)
        {
            case 0:
                color = Color.red;
                break;
            case 1:
                color = Color.blue;
                break;
            case 2:
                color = Color.green;
                break;
            case 3:
                color = Color.yellow;
                break;
            case 4:
                color = Color.cyan;
                break;
            default:
                color = Color.white;
                break;
        }
        GetComponent<SpriteRenderer>().color = color;
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 床にぶつかった場合の消滅
        if(collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
