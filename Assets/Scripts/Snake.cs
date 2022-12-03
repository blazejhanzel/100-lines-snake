using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Snake : MonoBehaviour
{
    // NOTE: scene is 40 u x 30 u

    [SerializeField]
    private GameObject tailPrefab;
    
    public enum Direction { Up, Down, Left, Right, Null }

    public Direction MoveDirection { get; set; } = Direction.Left;
    private List<SnakeTail> snakeTails = new();
    
    private void FixedUpdate()
    {
        if (MoveDirection == Direction.Null) return;
        
        for (var i = snakeTails.Count - 1; i >= 0; i--)
        {
            snakeTails[i].MoveSnakeTail();
        }
        
        var move = MoveDirection switch
        {
            Direction.Up => Vector2.up,
            Direction.Down => Vector2.down,
            Direction.Left => Vector2.left,
            Direction.Right => Vector2.right,
            Direction.Null => Vector2.zero
        };
        transform.Translate(move);
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        if (MoveDirection != Direction.Null)
        {
            if (value == Vector2.up && MoveDirection != Direction.Down) MoveDirection = Direction.Up;
            else if (value == Vector2.down && MoveDirection != Direction.Up) MoveDirection = Direction.Down;
            else if (value == Vector2.left && MoveDirection != Direction.Right) MoveDirection = Direction.Left;
            else if (value == Vector2.right && MoveDirection != Direction.Left) MoveDirection = Direction.Right;
        }
    }

    public void AddSnakeTail()
    {
        var obj = Instantiate(tailPrefab, transform.position, Quaternion.Euler(Vector3.zero));
        var tail = obj.GetComponent<SnakeTail>();
        tail.PreviousPartTransform = (snakeTails.Count > 0) ? snakeTails.Last().transform : transform;
        snakeTails.Add(tail);
    }

    public IEnumerator BlinkSnake()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GetComponentInChildren<SpriteRenderer>().enabled = !GetComponentInChildren<SpriteRenderer>().enabled;
            foreach (var snakeTail in snakeTails)
            {
                snakeTail.GetComponentInChildren<SpriteRenderer>().enabled =
                    !snakeTail.GetComponentInChildren<SpriteRenderer>().enabled;
            }
        }
    }
}
