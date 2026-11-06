using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarSystem : MonoBehaviour
{
   public static event Action<SonarPingData> OnPingEmitted;
   public event Action<SonarReturnData> OnEchoReturned;

   [Header  ("Configuration")]
   public int myFrecuency = 1200;

   public void EmitPing(float power)
   {
   SonarPingData ping = new SonarPingData
         {
               frequencyId = myFrequency,
               power = power,
               originPosition = transform.position,
               sender = this.gameObject
         };

         OnPingEmitted?.Invoke(ping);
         Debug.Log($"[Sonar] Ping emitido con frecuencia: {ping.frequencyId} y potencia {power}");
   }

   public void RegisterEcho(SonarReturnData echo)
   { 
         StoreEchoInMemory(echo);
         OnEchoReceived?.Invoke(echo);
   }

   private void StoreEchoInMemory(SonarReturnData echo)
   {
         Debug.Log($"[Sonar Memoria] Eco guardado de {echo.targetObject.name} a {echo.distance:F2} metros.");
   }
}
