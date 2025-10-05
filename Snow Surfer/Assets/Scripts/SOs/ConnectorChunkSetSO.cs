using UnityEngine;

[System.Serializable]
public class ConnectorEntry
{
    public ChunkGenerator.HeightLevel from;
    public ChunkGenerator.HeightLevel to;
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "ConnectorChunkSetSO", menuName = "Scriptable Objects/ConnectorChunkSetSO")]
public class ConnectorChunkSetSO : ScriptableObject
{

    [SerializeField] private ConnectorEntry[] connectors;

    public GameObject GetConnector(ChunkGenerator.HeightLevel from, ChunkGenerator.HeightLevel to)
    {
        foreach (ConnectorEntry entry in connectors)
        {
            if (entry.from == from && entry.to == to)
                return entry.prefab;
        }
        return null;
    }
}
