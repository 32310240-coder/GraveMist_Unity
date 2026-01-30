using UnityEngine;
using System.Collections;

public class DragAreaController : MonoBehaviour
{
    [SerializeField] private GraveSpawner graveSpawner;

    private bool isDragging = false;
    private bool hasDragged = false;

    void Update()
    {
        if (!TurnManager.Instance.isShakePhase) return;
        if (hasDragged) return;

        // 左クリック押し始め
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerOnDragArea())
            {
                isDragging = true;
                Debug.Log("ドラッグ開始");
            }
        }

        // 左クリック離した
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            hasDragged = true;

            Debug.Log("ドラッグ終了");
            graveSpawner.SpawnGraves();
            StartCoroutine(EndShakePhaseAfterDelay());
        }
    }

    // 3D RaycastでDragAreaに当たってるか判定
    bool IsPointerOnDragArea()
    {
        if (Camera.main == null) return false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            // DragArea自身、または子に当たっていたらOK
            return hit.transform == transform || hit.transform.IsChildOf(transform);
        }
        return false;
    }

    void OnEnable()
    {
        ResetDragState();
    }

    public void ResetDragState()
    {
        hasDragged = false;
        isDragging = false;
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
