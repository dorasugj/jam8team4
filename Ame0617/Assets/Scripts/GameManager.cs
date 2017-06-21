using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int wave = 0;

    [SerializeField]
    private Player player;

    [SerializeField]
    private SpawnArea area;

    [SerializeField]
    private Text gameTimeText;

    [SerializeField]
    private Text startText;

    [SerializeField]
    private float maxTime = 10F;

    private bool first;

    private float count;

    private float timer;

    private static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start() {
        // 一回きりの処理
        first = false;
        count = 0F;
        // タイマーの初期化
        timer = maxTime;
        // 色と落下速度の設定
        switch(wave)
        {
            case 1:
                player.spriteColor = Color.red;
                break;
            case 2:
                player.spriteColor = Color.blue;
                break;
            case 3:
                player.spriteColor = Color.green;
                break;
            case 4:
                player.spriteColor = Color.yellow;
                break;
            default:
                player.spriteColor = Color.white;
                break;
        }
        area.gravityScale = 0.1F + (float)wave * 0.1F;
        area.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        // ゲーム開始前の処理
        if (!first)
        {
            // スタート推奨文字の点滅
            var show = (count++ > 60) ? false : true;
            startText.gameObject.SetActive(show);
            if (count >= 120) count = 0;

            // ここでゲーム開始
            if (Input.GetMouseButtonDown(0))
            {
                first = true;
                startText.gameObject.SetActive(false);
                area.enabled = true;
            }
        }
        else
        {
            // ゲームのカウントダウン
            if (timer >= 0F)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                // ここでゲーム終了
                Debug.Log("End");
                //セーブ後、プレイヤー全員終わったかを確認してシーン遷移
                ScoreManager.Instance.Save(player.Score);
                if (ScoreManager.Instance.isEnd)
                    SceneChangeManager.Instance.LoadResult();
                else SceneChangeManager.Instance.LoadGame();

                area.enabled = false;
            }
        }

        // ゲームの残り時間を表示
        gameTimeText.text = ((int)timer).ToString() + "秒";
    }
}
