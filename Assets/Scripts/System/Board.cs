using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private BoxCollider boardCollider;

    public Vector3 GetRandomPositionOnBoard(float graveHalfHeight)
    {
        Bounds b = boardCollider.bounds;

        float x = Random.Range(b.min.x, b.max.x);
        float z = Random.Range(b.min.z, b.max.z);

        float y = b.max.y + graveHalfHeight;

        return new Vector3(x, y, z);
    }
}
