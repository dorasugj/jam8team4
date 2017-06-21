using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingWindowSwitch : MonoBehaviour {
    public GameObject rankingWidow;

    public void Push()
    {
        rankingWidow.SetActive(!rankingWidow.active);
    }
}
