using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {
    private const int RANKING_LENGTH = 5;
    private int playerNum = 1;
    public int getPlayerNum { get { return playerNum; } }
    private int gameCount = 0;
    public bool isEnd { get { return !(gameCount < playerNum); } }
    
    public int[] scores { get; private set; }
    public int[] rankIdxes { get; private set; }

    public int[] nowRanking { get; private set; }
    

    private readonly string[] RANK_STRS = new string[] { "1st", "2nd", "3rd", "4th", "5th" };

    protected override void Awake()
    {
        base.Awake();
        nowRanking = new int[RANK_STRS.Length];
        for (int i = 0; i < RANK_STRS.Length; i++)
        {
            //キーがなかったら作成する
            if (!PlayerPrefs.HasKey(RANK_STRS[i]))
            {
                PlayerPrefs.SetInt(RANK_STRS[i], 0);
            }
            nowRanking[i] = PlayerPrefs.GetInt(RANK_STRS[i]);
        }
        Init();
    }


    public void Save(int score)
    {
        scores[gameCount] = score;
        RankingUpdate();
        gameCount++;
        //全プレイヤー終わったら、ランクインしているプレイヤーと位置を調べる
        if (isEnd)
            RankInIdxUpdate();
        GameManager.wave = gameCount + 1;
    }
    public void Init()
    {
        SetPlayerNum(1);
    }


    private void RankingUpdate()
    {
        int[] _ranking=new int[RANKING_LENGTH];
        int thisScore = scores[gameCount];
        //現在のランキング取得とランキング更新
        for (int i = 0; i < _ranking.Length; i++)
		{
            bool isChange = false;
            int getScore = PlayerPrefs.GetInt(RANK_STRS[i]);
            if (thisScore > getScore)
            {
                int _temp = thisScore;
                thisScore = getScore;
                getScore = _temp;
                isChange = true;
            }
            _ranking[i] = getScore;
            //変わってたら保存
            if (isChange)
            {
                PlayerPrefs.SetInt(RANK_STRS[i], getScore);
            }
		}

        
        nowRanking = _ranking;

    }
    private void RankInIdxUpdate()
    {
        for (int i = 0; i < playerNum; i++)
        {
            //ランクインの位置を探す
            int _idx = nowRanking.Length - 1;
            for (; _idx > -1 && scores[i] != nowRanking[_idx]; _idx--) ;
            //なかったら-1
            rankIdxes[i] = _idx;
        }
    }

    public void SetPlayerNum(int num)
    {
        playerNum = num;
        gameCount = 0;
        scores = new int[playerNum];
        rankIdxes = new int[playerNum];
        GameManager.wave = 1;
    }

    //ランキングを消す
    public void RankingReset()
    {
        for (int i = 0; i < RANKING_LENGTH; i++)
        {
            PlayerPrefs.SetInt(RANK_STRS[i], 0);
        }
    }
}
