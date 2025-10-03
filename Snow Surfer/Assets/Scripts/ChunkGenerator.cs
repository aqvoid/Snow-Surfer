using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    [Header("=== Settings ===")]
    [SerializeField] private int chunksGenerateAmount = 10;
    [SerializeField, Range(0f, 1f), Tooltip("The more chance, the more height changes will be")] private float connectorSpawnChance = 0.2f;
    [SerializeField, Range(0f, 1f), Tooltip("The more chance, the more long chunks will be, instead of short ones")] private float longChunkChance = 0.7f;
    [SerializeField] private HeightLevel startHeight = HeightLevel.Medium;

    [Header("=== Randomized Chunks ===")]
    [SerializeField] private ChunkSetSO shortChunks;
    [SerializeField] private ChunkSetSO longChunks;

    [Header("=== Other Chunks ===")]
    [SerializeField] private StartChunkSetSO startChunks;
    [SerializeField] private ConnectorChunkSetSO connectorChunks;
    [SerializeField] private FinishChunkSetSO finishChunks;

    private const int SHORT_CHUNK_DISTANCE = 20;
    private const int LONG_CHUNK_DISTANCE = 40;
    private const int START_CHUNK_DISTANCE = 80;
    private Vector2 nextSpawnPosition = Vector2.zero;
    private bool lastWasConnector = false;

    private void Start()
    {
        SpawnStartChunks(startHeight);
    }

    private void GenerateLevel()
    {
        for (int i = 0; i < chunksGenerateAmount; i++)
        {
            bool useConnector = Random.value < connectorSpawnChance && !lastWasConnector;

            if (useConnector)
            {
                HeightLevel newHeight = PickNewHeight(startHeight);
                SpawnConnectorChunk(startHeight, newHeight);
                startHeight = newHeight;
                lastWasConnector = true;
            }
            else
            {
                SpawnChunk(startHeight);
                lastWasConnector = false;
            }
        }
        SpawnFinishChunk(startHeight);
    }



    // === Chunks ========================================================================================== //
    private void SpawnStartChunks(HeightLevel height)
    {
        GameObject chunk = startChunks.GetStartChunk(height);
        Instantiate(chunk, nextSpawnPosition, Quaternion.identity, transform);
        nextSpawnPosition.x += START_CHUNK_DISTANCE;

        GenerateLevel();
    }

    private void SpawnChunk(HeightLevel height)
    {
        bool isLong = Random.value < longChunkChance;

        GameObject chunk = (isLong ? longChunks : shortChunks).GetRandomChunk(height);
        Instantiate(chunk, nextSpawnPosition, Quaternion.identity, transform);
        nextSpawnPosition.x += isLong ? LONG_CHUNK_DISTANCE : SHORT_CHUNK_DISTANCE;
    }

    private void SpawnConnectorChunk(HeightLevel from, HeightLevel to)
    {
        GameObject chunk = connectorChunks.GetConnector(from, to);
        Instantiate(chunk, nextSpawnPosition, Quaternion.identity, transform);
        nextSpawnPosition.x += SHORT_CHUNK_DISTANCE;
    }
    private void SpawnFinishChunk(HeightLevel height)
    {
        GameObject chunk = finishChunks.GetFinishChunk(height);
        Instantiate(chunk, nextSpawnPosition, Quaternion.identity, transform);
    }

    // === Height =================================================================================== //

    private HeightLevel PickNewHeight(HeightLevel current)
    {
        if (current == HeightLevel.Low) return HeightLevel.Medium;
        if (current == HeightLevel.High) return HeightLevel.Medium;

        return (Random.value < 0.5f) ? HeightLevel.Low : HeightLevel.High;
    }

    public enum HeightLevel { Low, Medium, High }
}
