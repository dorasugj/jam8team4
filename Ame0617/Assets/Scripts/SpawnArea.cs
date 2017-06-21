using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour {

    public float gravityScale = 0.1F;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float spawnTime = 1F;

    [SerializeField]
    private float areaWidth = 10F;

    private float time = 0F;
	
	// Update is called once per frame
	void Update () {
        // 時間を更新
        time += Time.deltaTime;
        if (spawnTime <= time)
        {
            // 指定された幅から乱数位置で生成
            var x = Random.Range(-areaWidth / 2F, areaWidth / 2F);
            var position = new Vector3(x, transform.position.y, transform.position.z);
            var falling = Instantiate(prefab, position, Quaternion.identity).GetComponent<Rigidbody2D>();
            falling.gravityScale = gravityScale;
            time = 0F;
        }
    }
}
