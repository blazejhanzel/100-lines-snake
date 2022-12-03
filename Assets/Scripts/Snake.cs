using UnityEngine;
using UnityEngine.InputSystem;

public class Snake : MonoBehaviour
{
    private enum Direction { Up, Down, Left, Right }

    private Direction direction = Direction.Left;
    
    private void FixedUpdate()
    {
        var move = direction switch
        {
            Direction.Up => Vector2.up,
            Direction.Down => Vector2.down,
            Direction.Left => Vector2.left,
            Direction.Right => Vector2.right
        };
        transform.Translate(move * (Time.deltaTime * 15f));
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        if (value == Vector2.up && direction != Direction.Down) direction = Direction.Up;
        else if (value == Vector2.down && direction != Direction.Up) direction = Direction.Down;
        else if (value == Vector2.left && direction != Direction.Right) direction = Direction.Left;
        else if (value == Vector2.right && direction != Direction.Left) direction = Direction.Right;
    }
}
