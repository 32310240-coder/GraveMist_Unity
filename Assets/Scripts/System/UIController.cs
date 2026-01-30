using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject dragArea;

    public void OnPlayButtonPressed()
    {
        playButton.SetActive(false);
        dragArea.SetActive(true);

        TurnManager.Instance.StartShakePhase();
    }

    public void OnShakePhaseEnded()
    {
        dragArea.SetActive(false);
        playButton.SetActive(true);
    }
}
