using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    [Header("=== Settings ===")]
    [SerializeField] private int startChunks = 2;
    [SerializeField] private int maxChunks = 10;
    [SerializeField] private float connectorSpawnChance = 0.2f;
    [SerializeField, Range(0f, 1f)] private float longChunkChance = 0.7f;

    [Header("===== Prefabs =====")]
    [Header("=== Short Chunks ===")]
    [SerializeField] private GameObject[] shortLowChunks;
    [SerializeField] private GameObject[] shortMediumChunks;
    [SerializeField] private GameObject[] shortHighChunks;

    [Header("=== Long Chunks ===")]
    [SerializeField] private GameObject[] longLowChunks;
    [SerializeField] private GameObject[] longMediumChunks;
    [SerializeField] private GameObject[] longHighChunks;

    [Header("=== Other Chunks ===")]
    [SerializeField] private GameObject[] connectorChunks;
    [SerializeField] private GameObject[] finishChunks;

    private const int SHORT_CHUNK_DISTANCE = 20;
    private const int LONG_CHUNK_DISTANCE = 40;
    private Vector2 nextSpawnPosition = Vector2.zero;
    private HeightLevel currentHeight = HeightLevel.Low;
    private bool lastWasConnector = false;

    private void Start()
    {
        SpawnStartChunks();
    }

    private void GenerateLevel()
    {
        for (int i = 0; i < maxChunks; i++)
        {
            bool useConnector = Random.value < connectorSpawnChance && !lastWasConnector;

            if (useConnector)
            {
                HeightLevel newHeight = PickNewHeight(currentHeight);
                SpawnConnectorChunk(currentHeight, newHeight);
                currentHeight = newHeight;
                lastWasConnector = true;
            }
            else
            {
                SpawnChunk(currentHeight);
                lastWasConnector = false;
            }
        }
        SpawnFinishChunk(currentHeight);
    }



    // === Chunks ========================================================================================== //
    private void SpawnStartChunks()
    {
        for (int i = 0; i < startChunks; i++)
        {
            Instantiate(longLowChunks[0], nextSpawnPosition, Quaternion.identity, transform);
            nextSpawnPosition.x += LONG_CHUNK_DISTANCE;
        }

        GenerateLevel();
    }

    private void SpawnChunk(HeightLevel height)
    {
        bool isLong = Random.value < longChunkChance;

        GameObject prefab = PickRandomChunk(height, isLong);
        Instantiate(prefab, nextSpawnPosition, Quaternion.identity, transform);
        nextSpawnPosition.x += isLong ? LONG_CHUNK_DISTANCE : SHORT_CHUNK_DISTANCE;
    }

    private void SpawnConnectorChunk(HeightLevel from, HeightLevel to)
    {
        GameObject prefab = null;

        if (from == HeightLevel.Low && to == HeightLevel.Medium) prefab = connectorChunks[0];
        else if (from == HeightLevel.Medium && to == HeightLevel.Low) prefab = connectorChunks[1];
        else if (from == HeightLevel.Medium && to == HeightLevel.High) prefab = connectorChunks[2];
        else if (from == HeightLevel.High && to == HeightLevel.Medium) prefab = connectorChunks[3];

        if (prefab != null)
        {
            Instantiate(prefab, nextSpawnPosition, Quaternion.identity, transform);
            nextSpawnPosition.x += SHORT_CHUNK_DISTANCE;
        }
    }
    private void SpawnFinishChunk(HeightLevel height)
    {
        GameObject prefab = PickRandomFinishChunk(height);
        Instantiate(prefab, nextSpawnPosition, Quaternion.identity, transform);
        nextSpawnPosition.x += LONG_CHUNK_DISTANCE;
    }

    // === Random Chunk Pickers ============================================================================ //
    private GameObject PickRandomChunk(HeightLevel height, bool isLong)
    {
        switch (height)
        {
            case HeightLevel.Low:
                return isLong
                    ? longLowChunks[Random.Range(0, longLowChunks.Length)]
                    : shortLowChunks[Random.Range(0, shortLowChunks.Length)];
            case HeightLevel.Medium:
                return isLong
                    ? longMediumChunks[Random.Range(0, longMediumChunks.Length)]
                    : shortMediumChunks[Random.Range(0, shortMediumChunks.Length)];
            case HeightLevel.High:
                return isLong
                    ? longHighChunks[Random.Range(0, longHighChunks.Length)]
                    : shortHighChunks[Random.Range(0, shortHighChunks.Length)];
        }
        return null;
    }

    private GameObject PickRandomFinishChunk(HeightLevel height)
    {
        switch (height)
        {
            case HeightLevel.Low: return finishChunks[0];
            case HeightLevel.Medium: return finishChunks[1];
            case HeightLevel.High: return finishChunks[2];
        }
        return null;
    }

    // === Height =================================================================================== //

    private HeightLevel PickNewHeight(HeightLevel current)
    {
        if (current == HeightLevel.Low) return HeightLevel.Medium;
        if (current == HeightLevel.High) return HeightLevel.Medium;

        return (Random.value < 0.5f) ? HeightLevel.Low : HeightLevel.High;
    }

    private enum HeightLevel { Low, Medium, High }
}
