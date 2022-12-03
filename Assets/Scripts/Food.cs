using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private GameObject foodPrefab;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(-19, 20), Random.Range(-14, 15));
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        FindObjectOfType<PointCounter>().Score++;
        col.GetComponent<Snake>().AddSnakeTail();
        Instantiate(foodPrefab, Vector3.zero, Quaternion.Euler(Vector3.zero), null);
        Destroy(gameObject);
    }
}
