using UnityEngine;

public class Grave : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public GraveType CurrentType { get; private set; }

    public void SetType(GraveType type)
    {
        CurrentType = type;
        ApplyColor(type);
    }

    void ApplyColor(GraveType type)
    {
        switch (type)
        {
            case GraveType.Front:
                spriteRenderer.color = Color.red;
                break;
            case GraveType.Back:
                spriteRenderer.color = Color.blue;
                break;
            case GraveType.Side:
                spriteRenderer.color = Color.yellow;
                break;
            case GraveType.Vertical:
                spriteRenderer.color = Color.green;
                break;
            case GraveType.UpsideDown:
                spriteRenderer.color = new Color(0.5f, 0f, 0.5f); // Ž‡
                break;
        }
    }
}
