using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public void MoveSnakeTail(Vector3 previousPartPosition)
    {
        transform.position = previousPartPosition;
    }
}
