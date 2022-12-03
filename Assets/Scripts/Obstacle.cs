using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        FindObjectOfType<Snake>().MoveDirection = Snake.Direction.Null;
        StartCoroutine(FindObjectOfType<Snake>().BlinkSnake());
    }
}
