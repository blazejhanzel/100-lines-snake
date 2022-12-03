using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Snake : MonoBehaviour
{
    [SerializeField] private GameObject tailPrefab;

    public Vector3 Move { get; set; } = Vector3.left;
    public List<GameObject> SnakeTails { get; } = new();

    private void FixedUpdate()
    {
        if (Move == Vector3.zero) return;
        for (var i = SnakeTails.Count - 1; i >= 0; i--)
        {
            SnakeTails[i].transform.position = i > 0 ? SnakeTails[i - 1].transform.position : transform.position;
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
        SnakeTails.Add(Instantiate(tailPrefab, transform.position, Quaternion.identity));
    }

    public IEnumerator BlinkSnake()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GetComponentInChildren<SpriteRenderer>().enabled = !GetComponentInChildren<SpriteRenderer>().enabled;
            SnakeTails.ForEach(snakeTail => snakeTail.gameObject.SetActive(!snakeTail.gameObject.activeSelf));
        }
    }
}
