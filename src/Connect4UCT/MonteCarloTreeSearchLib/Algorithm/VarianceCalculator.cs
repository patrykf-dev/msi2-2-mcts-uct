using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class VarianceCalculator
    {
        public float Value { get; private set; }

        private float _itemSum = 0f;
        private List<float> _values = new List<float>();

        public void AddValue(float value)
        {
            _values.Add(value);
            _itemSum += value;
            UpdateVariance();
        }

        private void UpdateVariance()
        {
            float avg = _itemSum / _values.Count;

            float denominator = 0f;
            foreach (float value in _values)
            {
                denominator += (value - avg) * (value - avg);
            }
            Value = denominator / _values.Count;
        }
    }
}
