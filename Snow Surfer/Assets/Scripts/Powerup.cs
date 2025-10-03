using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private PowerupsSO powerupsSO;
    private bool isSpawn = false;

    private void Start()
    {
        isSpawn = powerupsSO.GetSpawnChance() > Random.value;
        if (isSpawn) Instantiate(powerupsSO.GetRandomPowerup(), transform.position, Quaternion.identity, transform);
    }
}
