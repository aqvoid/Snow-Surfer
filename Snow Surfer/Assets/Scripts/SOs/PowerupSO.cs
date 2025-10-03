using UnityEngine;

[CreateAssetMenu(fileName = "PowerupSO", menuName = "Scriptable Objects/PowerupSO")]
public class PowerupSO : ScriptableObject
{
    [SerializeField] private string powerupType;
    [SerializeField] private float valueChange;
    [SerializeField] private float time; 

    public string GetPowerupType() => powerupType;
    public float GetValueChange() => valueChange;
    public float GetTime() => time;
}
