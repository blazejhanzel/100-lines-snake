using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform PreviousPartTransform { get; set; }

    public void MoveSnakeTail()
    {
        transform.position = PreviousPartTransform.position;
    }
}
