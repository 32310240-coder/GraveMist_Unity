using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private GraveSpawner graveSpawner;
    [SerializeField] private DragAreaController dragAreaController;

    public static TurnManager Instance;

    // 振りフェーズ中かどうか
    public bool isShakePhase { get; private set; } = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ボタンなどから呼ぶ：振りフェーズ開始
    public void StartShakePhase()
    {
        if (isShakePhase) return;

        isShakePhase = true;
        Debug.Log("振りフェーズ開始");

        dragAreaController.ResetDragState();
    }

    // DragAreaController から呼ばれる：振りフェーズ終了
    public void EndShakePhase()
    {
        if (!isShakePhase) return;

        isShakePhase = false;
        Debug.Log("振りフェーズ終了");

        graveSpawner.ClearGraves(); // ★ ここで消す
    }

}
