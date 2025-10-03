using UnityEngine;

[CreateAssetMenu(fileName = "PowerupsSO", menuName = "Scriptable Objects/PowerupsSO")]
public class PowerupsSO : ScriptableObject
{
    [SerializeField] private GameObject[] powerUps;
    [SerializeField, Range(0, 1)] private float spawnChance = 0.5f;

    public GameObject GetRandomPowerup() => powerUps[Random.Range(0, powerUps.Length)];
    public float GetSpawnChance() => spawnChance;
}
