using UnityEngine;
using System;

namespace HexUN.Events
{
   [CreateAssetMenu(fileName = "BooleanArraySoEvent", menuName = "HexUN/Core/Events/BooleanArray")]
   public class BooleanArraySoEvent : ScriptableObjectEvent<Boolean[]>
   {
   }
}