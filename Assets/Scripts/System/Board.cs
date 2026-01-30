using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boardCollider;

    public Vector2 GetRandomPositionInside()
    {
        Bounds b = boardCollider.bounds;

        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);

        return new Vector2(x, y);
    }
}
