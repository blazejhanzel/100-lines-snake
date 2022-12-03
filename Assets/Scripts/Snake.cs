using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Snake : MonoBehaviour
{
    [SerializeField] private GameObject tailPrefab;

    public Vector3 Move { get; set; } = Vector3.left;
    public List<SnakeTail> SnakeTails { get; } = new();

    private void FixedUpdate()
    {
        if (Move == Vector3.zero) return;
        for (var i = SnakeTails.Count - 1; i >= 0; i--)
        {
            SnakeTails[i].MoveSnakeTail(i > 0 ? SnakeTails[i - 1].transform.position : transform.position);
        }

        transform.Translate(Move);
    }
    
    public void MoveInput(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        if (value == Vector2.up && Move != Vector3.down && Move != Vector3.zero) Move = Vector3.up;
        else if (value == Vector2.down && Move != Vector3.up && Move != Vector3.zero) Move = Vector3.down;
        else if (value == Vector2.left && Move != Vector3.right && Move != Vector3.zero) Move = Vector3.left;
        else if (value == Vector2.right && Move != Vector3.left && Move != Vector3.zero) Move = Vector3.right;
    }

    public void AddSnakeTail()
    {
        var obj = Instantiate(tailPrefab, transform.position, Quaternion.identity);
        SnakeTails.Add(obj.GetComponent<SnakeTail>());
    }

    public IEnumerator BlinkSnake()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GetComponentInChildren<SpriteRenderer>().enabled = !GetComponentInChildren<SpriteRenderer>().enabled;
            foreach (var snakeTail in SnakeTails)
            {
                snakeTail.GetComponentInChildren<SpriteRenderer>().enabled =
                    !snakeTail.GetComponentInChildren<SpriteRenderer>().enabled;
            }
        }
    }
}
