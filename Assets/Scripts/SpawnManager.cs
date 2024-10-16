using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float StartDelay = 1f;
    private float RepeatRate = 2f;
    public GameObject obstaclePrefab;

    public Vector3 _spawnPos = new(35, 2f, 0);


    private PlayerController _playerController;

    // Start is called before the first frame update
    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnObstacle), StartDelay, RepeatRate);
    }
    private void SpawnObstacle()
    {
        if (!_playerController.gameOver) Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
    }
}