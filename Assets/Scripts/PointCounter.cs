using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    private int score;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            UpdateText();
        }
    }

    private void Start()
    {
        UpdateText();
    }
    
    private void UpdateText()
    {
        textMeshPro.text = score.ToString();
    }
}
