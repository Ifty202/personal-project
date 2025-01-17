using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float Speed = 10f;
    private float LeftBound = -9f;
    private PlayerController _playerController;

    // Start is called before the first frame update
    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_playerController.gameOver) transform.Translate(Vector3.left * (Time.deltaTime * Speed));

        if (transform.position.x < LeftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}