using UnityEngine;

public class Grave : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    private MaterialPropertyBlock block;

    void Awake()
    {
        block = new MaterialPropertyBlock();
    }

    public void SetType(GraveType type)
    {
        Color color = GetColor(type);
        block.SetColor("_BaseColor", color);
        meshRenderer.SetPropertyBlock(block);
    }

    Color GetColor(GraveType type)
    {
        switch (type)
        {
            case GraveType.Front: return Color.red;
            case GraveType.Back: return Color.blue;
            case GraveType.Side: return Color.yellow;
            case GraveType.Vertical: return Color.green;
            case GraveType.UpsideDown: return new Color(0.5f, 0f, 0.5f);
            default: return Color.white;
        }
    }
}
