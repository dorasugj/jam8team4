using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed = 1F;

    public Color spriteColor;

    [SerializeField]
    private Text playerScoreText;

    [SerializeField]
    private Sprite[] sprites;

    private Vector3 target;

    private int score = 0;
    public int Score { get { return score;} }

    private AudioSource getAudio;

    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        // 動的にタグを設定しておく
        tag = "Player";
        // 初期のスコアや色を設定
        score = 0;
        target = transform.position;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = spriteColor;
        // オーディオを取得
        getAudio = GetComponent<AudioSource>();
        getAudio.Stop();
        // 書き換え用にスプライトを取得
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        // タッチした位置に線形補間する
        if(Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.y = transform.position.y;
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // 目的地までの差分で向きのスプライトを変更
        var sub = target - transform.position;
        if(sub.x > 0)
        {
            sprite.sprite = sprites[2];
        }
        else if(sub.x < 0)
        {
            sprite.sprite = sprites[1];
        }
        else if (sub.x == 0)
        {
            sprite.sprite = sprites[0];
        }

        // スコアの個数をGUIに表示
        playerScoreText.text = score.ToString() + "個";
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 落下物にぶつかった際にスコアを更新
        if(collision.gameObject.tag == "Falling")
        {
            getAudio.Play();
            score++;
            Destroy(collision.gameObject);
        }
    }
}
