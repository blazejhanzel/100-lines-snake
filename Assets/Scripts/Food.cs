using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(-19, 20), Random.Range(-14, 15));
        for (var i = 0; i < FindObjectOfType<Snake>().SnakeTails.Count; i++)
        {
            if (FindObjectOfType<Snake>().SnakeTails[i].transform.position == transform.position)
            {
                transform.position = new Vector3(Random.Range(-19, 20), Random.Range(-14, 15));
                i = -1;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        FindObjectOfType<PointCounter>().IncrementPoints();
        col.GetComponent<Snake>().AddSnakeTail();
        Instantiate(foodPrefab, Vector3.zero, Quaternion.Euler(Vector3.zero), null);
        Destroy(gameObject);
    }
}
