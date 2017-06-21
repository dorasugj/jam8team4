using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingGUI : MonoBehaviour {
    public Text[] rankingScoreTexts;
    public Text[] rankingIndexTexts;
    public Text[] playerScoreTexts;
    public Color[] playerColors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow };

    public bool isTitle = false;

    void Start()
    {
        if (isTitle)
            TitleRankingView();
        else ResultRankingView();
    }

    private void ResultRankingView()
    {
        int[] _ranking = ScoreManager.Instance.nowRanking;
        int[] _playerScores = ScoreManager.Instance.scores;
        int[] _playerRankIdxes = ScoreManager.Instance.rankIdxes;
        for (int i = 0; i < ScoreManager.Instance.getPlayerNum; i++)
        {
            for (int j = 0; j < rankingScoreTexts.Length; j++)
            {
                rankingScoreTexts[j].text = _ranking[j].ToString();
                //今回でランクインしたものだったら色を変える
                if (_playerRankIdxes[i] == j)
                {
                    rankingScoreTexts[j].color = rankingIndexTexts[j].color = playerColors[i];
                }
            }
        }
        Debug.Log("通過１");
        for (int i = 0; i < playerScoreTexts.Length; i++)
        {
            Debug.Log("通過2");
            if (i < ScoreManager.Instance.getPlayerNum)
            {
                playerScoreTexts[i].text = _playerScores[i].ToString()+"個";
            }
            else
            {
                playerScoreTexts[i].text = "いない";

            }
        }


    }

    private void TitleRankingView()
    {
        int[] _ranking = ScoreManager.Instance.nowRanking;

        for (int i = 0; i < rankingScoreTexts.Length; i++)
        {
            rankingScoreTexts[i].text = _ranking[i].ToString();
        }
    }
    //ランキングを消去したら呼んで、スコア表示を全部０にする
    public void Reset()
    {
        for (int i = 0; i < rankingScoreTexts.Length; i++)
        {
            rankingScoreTexts[i].text = "0";
        }
    }
}
