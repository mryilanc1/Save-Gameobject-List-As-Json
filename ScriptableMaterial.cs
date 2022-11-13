using UnityEngine;

[CreateAssetMenu(fileName = "MaterialsPool", menuName = "ScriptableObjects/MaterialsPool", order = 1)]

public class ScriptableMaterial : ScriptableObject

{
    public Material[] Material;
}