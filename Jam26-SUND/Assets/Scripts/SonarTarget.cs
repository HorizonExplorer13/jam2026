using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarTarget : MonoBehaviour
{
    public int targetFrequency = 1200; 
    [Range(0f, 1f)] public float reflectivity = 0.8f; 

    private void OnEnable()
    {
        SonarSystem.OnPingEmitted += EvaluateIncomingPing;
    }

    private void OnDisable()
    {
        SonarSystem.OnPingEmitted -= EvaluateIncomingPing;
    }

    private void EvaluateIncomingPing(SonarPingData ping)
    {
 
        if (ping.sender == this.gameObject) return;

        float distance = Vector3.Distance(ping.originPosition, transform.position);

        if (distance <= ping.power && Mathf.Abs(ping.frequencyId - targetFrequency) < 300)
        {
            SonarSystem emitter = (ping.sender as GameObject).GetComponent<SonarSystem>();
            if (emitter != null)
            {
                SonarReturnData echo = new SonarReturnData
                {
                    targetFrequencyId = targetFrequency,
                    distance = distance,
                    hitPoint = transform.position,
                    targetObject = this.gameObject
                };
                emitter.RegisterEcho(echo);
            }
        }
    }
}
