using UnityEngine;
using System.Collections.Generic;

public class GraveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gravePrefab;
    [SerializeField] private BoxCollider boardArea;

    [SerializeField] private int spawnCount = 4;
    [SerializeField] private float spawnHeight = 3.0f;

    // 生成した grave を管理するリスト
    private List<GameObject> spawnedGraves = new List<GameObject>();

    public void SpawnGraves()
    {
        ClearGraves(); // 念のため毎回クリア

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPos = GetRandomPositionOnBoard();
            GameObject graveObj = Instantiate(gravePrefab, spawnPos, Quaternion.identity);
            spawnedGraves.Add(graveObj);

            Grave grave = graveObj.GetComponent<Grave>();
            if (grave != null)
            {
                GraveType type = GetRandomGraveType();
                grave.SetType(type);
            }
        }
    }
    private GraveType GetRandomGraveType()
    {
        float r = Random.value; // 0.0〜1.0

        if (r < 0.40f) return GraveType.Front;        // 40%
        if (r < 0.80f) return GraveType.Back;         // 40%
        if (r < 0.895f) return GraveType.Side;        // 9.5%
        if (r < 0.99f) return GraveType.Vertical;     // 9.5%
        return GraveType.UpsideDown;                  // 1%
    }

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
    }

    private Vector3 GetRandomPositionOnBoard()
    {
        Bounds bounds = boardArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        float y = bounds.max.y + spawnHeight;

        return new Vector3(x, y, z);
    }
}
