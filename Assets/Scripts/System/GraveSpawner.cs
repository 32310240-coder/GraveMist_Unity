using UnityEngine;
using System.Collections.Generic;

public class GraveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gravePrefab;
    [SerializeField] private int spawnCount = 4;

    [SerializeField] private Vector2 minSpawnPos;
    [SerializeField] private Vector2 maxSpawnPos;

    [SerializeField] private float frontBackRate = 0.8f;
    [SerializeField] private float sideVerticalRate = 0.19f;
    [SerializeField] private float upsideDownRate = 0.01f;

    [SerializeField] private Board board;



    // ★ 今出ている grave を管理
    private List<GameObject> spawnedGraves = new List<GameObject>();

    public void SpawnGraves()
    {
        ClearGraves();

        for (int i = 0; i < spawnCount; i++)
        {
            Vector2 pos2D = board.GetRandomPositionInside();
            Vector3 pos = new Vector3(pos2D.x, pos2D.y, 0f);

            GameObject obj = Instantiate(gravePrefab, pos, Quaternion.identity);
            spawnedGraves.Add(obj);

            Grave grave = obj.GetComponent<Grave>();
            GraveType type = GetRandomGraveType();
            grave.SetType(type);
        }

        Debug.Log("grave を4つ生成（状態付き）");
    }


    // ★ 振りフェーズ終了時に呼ぶ
    public void ClearGraves()
    {
        foreach (GameObject grave in spawnedGraves)
        {
            if (grave != null)
            {
                Destroy(grave);
            }
        }

        spawnedGraves.Clear();
        Debug.Log("grave を全て削除");
    }

    GraveType GetRandomGraveType()
    {
        float rand = Random.value; // 0.0〜1.0

        if (rand < upsideDownRate)
        {
            return GraveType.UpsideDown;
        }

        rand -= upsideDownRate;

        if (rand < sideVerticalRate)
        {
            // 横 or 縦は50:50
            return Random.value < 0.5f ? GraveType.Side : GraveType.Vertical;
        }

        // 残りは表 or 裏（80%）
        return Random.value < 0.5f ? GraveType.Front : GraveType.Back;
    }

}
