using UnityEngine;

[CreateAssetMenu(fileName = "ChunkSetSO", menuName = "Scriptable Objects/ChunkSetSO")]
public class ChunkSetSO : ScriptableObject
{
    [SerializeField] private GameObject[] lowChunks;
    [SerializeField] private GameObject[] mediumChunks;
    [SerializeField] private GameObject[] highChunks;

    public GameObject GetRandomChunk(ChunkGenerator.HeightLevel height)
    {
        switch (height)
        {
            case ChunkGenerator.HeightLevel.Low:
                return lowChunks[Random.Range(0, lowChunks.Length)];
            case ChunkGenerator.HeightLevel.Medium:
                return mediumChunks[Random.Range(0, mediumChunks.Length)];
            case ChunkGenerator.HeightLevel.High:
                return highChunks[Random.Range(0, highChunks.Length)];
        }
        return null;
    }

    public GameObject GetStartChunk(ChunkGenerator.HeightLevel height)
    {
        switch (height)
        {
            case ChunkGenerator.HeightLevel.Low: return lowChunks[0];
            case ChunkGenerator.HeightLevel.Medium: return mediumChunks[0];
            case ChunkGenerator.HeightLevel.High: return highChunks[0];
        }
        return null;
    }
}
