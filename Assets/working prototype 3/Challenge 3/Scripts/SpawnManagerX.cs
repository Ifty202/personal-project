using UnityEngine;

namespace Challenge_3.Scripts
{
    public class SpawnManagerX : MonoBehaviour
    {
        private const float SpawnDelay = 2;
        private const float SpawnInterval = 1.5f;
        public GameObject[] objectPrefabs;

        private PlayerControllerX playerControllerScript;

        // Start is called before the first frame update
        private void Start()
        {
            InvokeRepeating(nameof(SpawnObjects), SpawnDelay, SpawnInterval);
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        }

        // Spawn obstacles
        private void SpawnObjects()
        {
            // Set random spawn location and random object index
            var spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
            var index = Random.Range(0, objectPrefabs.Length);

            // If game is still active, spawn new object
            if (!playerControllerScript.gameOver)
                Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }
    }
}