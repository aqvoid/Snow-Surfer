using UnityEngine;

[CreateAssetMenu(fileName = "StartChunkSetSO", menuName = "Scriptable Objects/StartChunkSetSO")]
public class StartChunkSetSO : ScriptableObject
{
    [SerializeField] private GameObject lowStart;
    [SerializeField] private GameObject mediumStart;
    [SerializeField] private GameObject highStart;

    public GameObject GetStartChunk(ChunkGenerator.HeightLevel height)
    {
        switch (height)
        {
            case ChunkGenerator.HeightLevel.Low: return lowStart;
            case ChunkGenerator.HeightLevel.Medium: return mediumStart;
            case ChunkGenerator.HeightLevel.High: return highStart;
        }
        return null;
    }
}
