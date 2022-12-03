using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    private int score;

    public void IncrementPoints()
    {
        score++;
        textMeshPro.text = score.ToString();
    }
}
