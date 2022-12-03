using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        FindObjectOfType<Snake>().Move = Vector3.zero;
        StartCoroutine(FindObjectOfType<Snake>().BlinkSnake());
    }
}
