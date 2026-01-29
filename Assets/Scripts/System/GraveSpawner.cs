using UnityEngine;
using System.Collections.Generic;

public class GraveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gravePrefab;
    [SerializeField] private int spawnCount = 4;

    [SerializeField] private Vector2 minSpawnPos;
    [SerializeField] private Vector2 maxSpawnPos;

    // ★ 今出ている grave を管理
    private List<GameObject> spawnedGraves = new List<GameObject>();

    public void SpawnGraves()
    {
        ClearGraves(); // 念のため既存を消す

        for (int i = 0; i < spawnCount; i++)
        {
            float x = Random.Range(minSpawnPos.x, maxSpawnPos.x);
            float y = Random.Range(minSpawnPos.y, maxSpawnPos.y);

            GameObject grave = Instantiate(
                gravePrefab,
                new Vector3(x, y, 0f),
                Quaternion.identity
            );

            spawnedGraves.Add(grave);
        }

        Debug.Log("grave を4つ生成");
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
}
