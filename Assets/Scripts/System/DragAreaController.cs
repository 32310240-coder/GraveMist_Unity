using UnityEngine;
using System.Collections;

public class DragAreaController : MonoBehaviour
{
    private bool isDragging = false;
    private bool hasDragged = false;

    void Update()
    {
        if (!TurnManager.Instance.isShakePhase) return;
        if (hasDragged) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mouseWorld);

            if (hit != null && hit.transform.IsChildOf(transform))
            {
                isDragging = true;
                Debug.Log("ドラッグ開始");
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            hasDragged = true;

            Debug.Log("ドラッグ終了");
            StartCoroutine(EndShakePhaseAfterDelay());
        }
    }

    IEnumerator EndShakePhaseAfterDelay()
    {
        int count = 3;

        while (count > 0)
        {
            Debug.Log(count);
            yield return new WaitForSeconds(1f);
            count--;
        }

        TurnManager.Instance.EndShakePhase();
    }
}
