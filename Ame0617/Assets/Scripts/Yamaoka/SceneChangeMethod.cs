using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GUIボタンにシーン遷移の関数を入れるための置き場
public class SceneChangeMethod : MonoBehaviour {

    public void Title()
    {
        ScoreManager.Instance.Init();
        SceneChangeManager.Instance.LoadTitle();
    }
    public void Game()
    {
        SceneChangeManager.Instance.LoadGame();
    }
    public void Result()
    {
        SceneChangeManager.Instance.LoadResult();
    }

    //ランキングをリセット
    public void RankingReset()
    {
        ScoreManager.Instance.RankingReset();
    }
}
