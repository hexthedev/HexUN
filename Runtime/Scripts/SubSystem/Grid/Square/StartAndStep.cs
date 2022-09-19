using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using HexCS.Core;

namespace Hex.UN.Runtime.SubSystem.Grid.Square
{
    /// <summary>
    /// Represents a starting coordinate and step. Can be used to performing stepping algorithms
    /// </summary>
    public struct StartAndStep
    {
        public readonly DiscreteVector2 Origin;
        public readonly DiscreteVector2 Step;
        
        public StartAndStep(DiscreteVector2 origin, DiscreteVector2 step)
        {
            Origin = origin;
            Step = step;
        }

        /// <summary>
        /// Starting form origin generate a number of steps
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public DiscreteVector2[] GetSteps(int count)
        {
            DiscreteVector2[] points = new DiscreteVector2[count];

            points[0] = Origin;
            for (int i = 1; i < count; i++)
                points[i] = points[i - 1] + Step;

            return points;
        }

        /// <summary>
        /// Runs forever stepping forward and returning the next step
        /// </summary>
        /// <returns></returns>
        public IEnumerator<DiscreteVector2> StepGenerator()
        {
            return new StepEnumerator(Origin, Step);
        }
        
        public class StepEnumerator : IEnumerator<DiscreteVector2>
        {
            private DiscreteVector2 _origin;
            private DiscreteVector2 _step;

            public StepEnumerator(DiscreteVector2 origin, DiscreteVector2 step)
            {
                _origin = origin;
                _step = step;
            }

            public DiscreteVector2 Current { get; private set; }
            
            public bool MoveNext()
            {
                Current += _step;
                return true;
            }

            public void Reset() => Current = _origin;

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }
        
    }
}