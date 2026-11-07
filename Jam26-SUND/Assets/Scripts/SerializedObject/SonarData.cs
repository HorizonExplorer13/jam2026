using UnityEngine;

[System.Serializable]
public struct SonarPingData
{
    public int frequencyId;
    public float power;
    public Vector3 originPosition;
    public object sender;
}
[System.Serializable]
public struct SonarReturnData
{
    public int targetFrequencyId;
    public float distance;
    public Vector3 hitPoint;
    public GameObject targetObject;
}