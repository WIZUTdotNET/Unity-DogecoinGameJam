using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 100f;
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Transform player;

    private Vector3 _lastEndPosition;

    private void Awake()
    {
        _lastEndPosition = levelPart_Start.Find("EndPosition").position;
        SpawnLevelPart();
        SpawnLevelPart();
        var startingSpawnLevelParts = 5;
        for (var i = 0; i < startingSpawnLevelParts; i++) SpawnLevelPart();
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, _lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART) SpawnLevelPart();
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void SpawnLevelPart()
    {
        var chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        var lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, _lastEndPosition);
        _lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        var levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}