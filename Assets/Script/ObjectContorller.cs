using UnityEngine;

public enum ObjectKind
{
    Obstacle,
    Bonus
}

public class ObjectBehavior : MonoBehaviour
{
    [SerializeField] private ObjectKind objectKind;
    [SerializeField] private float moveSpeed = 2f; // скорость движения влево

    private void Start()
    {
        Destroy(gameObject, 20f);
    }

    private void Update()
    {
        if (!ObjectSpawner.Instance.IsSpawning)
        {
            Destroy(gameObject);
            return;
        }

        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        switch (objectKind)
        {
            case ObjectKind.Obstacle:
                GameManager.Instance.GameOver();
                break;

            case ObjectKind.Bonus:
                GameManager.Instance.AddPoint();
                break;
        }

        Destroy(gameObject);
    }
}
