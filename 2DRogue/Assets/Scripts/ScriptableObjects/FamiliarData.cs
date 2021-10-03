using UnityEngine;

[CreateAssetMenu(fileName ="Familiar.asset", menuName = "Familiars/FamilarObject")]
public class FamiliarData : ScriptableObject
{
    public string familiarType;
    public float speed;
    public float fireDelay;
    public GameObject bulletPrefab;

}
