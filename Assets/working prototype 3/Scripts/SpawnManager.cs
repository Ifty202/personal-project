using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private const float StartDelay = 1f;
    private const float RepeatRate = 2f;
    public GameObject obstaclePrefab;

    private readonly Vector3 _spawnPos = new(35, 2f, 0);

    // private readonly float _leftBound = -15f;
    private PlayerController _playerController;

    // Start is called before the first frame update
    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnObstacle), StartDelay, RepeatRate);
    }

    // Update is called once per frame
    private void Update()
    {
        // if (transform.position.x < -_leftBound && gameObject.CompareTag("Obstacle")) Destroy(gameObject);
    }

    private void SpawnObstacle()
    {
        if (!_playerController.gameOver) Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
    }
}