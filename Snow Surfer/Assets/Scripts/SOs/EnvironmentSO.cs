using UnityEngine;

[CreateAssetMenu(fileName = "EnvironmentSO", menuName = "Scriptable Objects/EnvironmentSO")]
public class EnvironmentSO : ScriptableObject
{
    [SerializeField] Sprite[] sprites;

    public Sprite GetRandomSprite() => sprites[Random.Range(0, sprites.Length)];
}
