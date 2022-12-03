using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    
    public void IncrementPoints()
    {
        textMeshPro.text = (int.Parse(textMeshPro.text) + 1).ToString();
    }
}
