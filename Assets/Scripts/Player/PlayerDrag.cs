using UnityEngine;

public class PlayerDrag : MonoBehaviour
{
    [SerializeField] private Rigidbody2D targetRb; // SquareのRigidbody2D
    private Vector3 offset;
    private bool isDragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // マウス座標をワールド座標に変換
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0f;

            // クリック判定（Squareをクリックした時だけ掴める）
            Collider2D hit = Physics2D.OverlapPoint(mouseWorld);
            if (hit != null && hit.attachedRigidbody == targetRb)
            {
                isDragging = true;
                offset = targetRb.position - (Vector2)mouseWorld;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    void FixedUpdate()
    {
        if (!isDragging) return;

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        Vector2 targetPos = (Vector2)mouseWorld + (Vector2)offset;
        targetRb.MovePosition(targetPos);
    }
}
