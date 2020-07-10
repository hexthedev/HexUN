using UnityEngine;
using System;

namespace TobiasUN.Core.Events
{
   [CreateAssetMenu(fileName = "BooleanArraySoEvent", menuName = "TobiasUN/Core/Events/BooleanArray")]
   public class BooleanArraySoEvent : ScriptableObjectEvent<Boolean[]>
   {
   }
}