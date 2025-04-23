using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    private float prevSpawnHeight = 10;

    [SerializeField] [Min(5)] private float heightLowerThreshold;
    [SerializeField] [Min(10)] private float heightHigherThreshold;
    [SerializeField] [Min(0)] private float horizontalVariance = 3.0f;
    [SerializeField] [Min(0)] private float verticalVariance = 3.0f;
    [SerializeField] [Min(0.1f)] private float spawnTimer = 1;

    
    
    private bool _mSpawnPlatformsFlag;
    private Transform _mPlayerTransform;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        _mPlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        while (isActiveAndEnabled)
        {
            if (NeedsMorePlatforms()) SpawnPlatform();
            yield return new WaitForSeconds(spawnTimer);
        }   
    }

    // Checks if the last spawned platform is within or past the threshold for spawning more platforms
    // If it's higher than the maximum, change the flag to false
    // If it's lower than the minimum, change the flag to true
    bool NeedsMorePlatforms()
    {
        if (_mSpawnPlatformsFlag)
        {
            _mSpawnPlatformsFlag &= !(prevSpawnHeight - _mPlayerTransform.position.y > heightHigherThreshold);
        }
        else
        {
            _mSpawnPlatformsFlag |= (prevSpawnHeight - _mPlayerTransform.position.y < heightLowerThreshold);
        }
        return _mSpawnPlatformsFlag;
    }

    void SpawnPlatform()
    {
        Vector3 spawnPos = new Vector3(Random.value*horizontalVariance, Random.value*verticalVariance, 0);
        spawnPos.y += prevSpawnHeight;
        var prefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
        Instantiate(prefab, spawnPos, Quaternion.identity);

        prevSpawnHeight = spawnPos.y;
    }

}
