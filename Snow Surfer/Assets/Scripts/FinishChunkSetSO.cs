using UnityEngine;

[CreateAssetMenu(fileName = "FinishChunkSetSO", menuName = "Scriptable Objects/FinishChunkSetSO")]
public class FinishChunkSetSO : ScriptableObject
{
    [SerializeField] private GameObject lowFinish;
    [SerializeField] private GameObject mediumFinish;
    [SerializeField] private GameObject highFinish;

    public GameObject GetFinishChunk(ChunkGenerator.HeightLevel height)
    {
        switch (height)
        {
            case ChunkGenerator.HeightLevel.Low: return lowFinish;
            case ChunkGenerator.HeightLevel.Medium: return mediumFinish;
            case ChunkGenerator.HeightLevel.High: return highFinish;
        }
        return null;
    }
}
