using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int startChunks = 4;
    [SerializeField] private int maxChunks = 10;
    [SerializeField] private float connectorSpawnChance = 0.2f;

    [Header("Prefabs")]
    [SerializeField] private GameObject[] lowChunks;
    [SerializeField] private GameObject[] mediumChunks;
    [SerializeField] private GameObject[] highChunks;
    [SerializeField] private GameObject[] connectorChunks;
    [SerializeField] private GameObject[] finishChunks;
    
    private const int CHUNKDISTANCE = 20;
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
            int rndPrefab = Random.Range(0, lowChunks.Length);
            Instantiate(lowChunks[rndPrefab], nextSpawnPosition, Quaternion.identity, transform);
            nextSpawnPosition.x += CHUNKDISTANCE;
        }

        GenerateLevel();
    }

    private void SpawnChunk(HeightLevel height)
    {
        GameObject prefab = PickRandomChunk(height);
        Instantiate(prefab, nextSpawnPosition, Quaternion.identity, transform);
        nextSpawnPosition.x += CHUNKDISTANCE;
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
            nextSpawnPosition.x += CHUNKDISTANCE;
        }
    }
    private void SpawnFinishChunk(HeightLevel height)
    {
        GameObject prefab = PickRandomFinishChunk(height);
        Instantiate(prefab, nextSpawnPosition, Quaternion.identity, transform);
        nextSpawnPosition.x += CHUNKDISTANCE;

        for (int i = 0; i < 4; i++)
        {
            Instantiate(PickRandomPostFinishChunks(height), nextSpawnPosition, Quaternion.identity, transform);
            nextSpawnPosition.x += CHUNKDISTANCE;
        }
    }

    // === Random Chunk Pickers ============================================================================ //
    private GameObject PickRandomChunk(HeightLevel height)
    {
        switch (height)
        {
            case HeightLevel.Low: return lowChunks[Random.Range(0, lowChunks.Length)];
            case HeightLevel.Medium: return mediumChunks[Random.Range(0, mediumChunks.Length)];
            case HeightLevel.High: return highChunks[Random.Range(0, highChunks.Length)];
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

    private GameObject PickRandomPostFinishChunks(HeightLevel height)
    {
        switch (height)
        {
            case HeightLevel.Low: return lowChunks[0];
            case HeightLevel.Medium: return mediumChunks[0];
            case HeightLevel.High: return highChunks[0];
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
