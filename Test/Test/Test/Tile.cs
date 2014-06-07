using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Tile
    {
        int value, displayValue;

        public Tile()
        {
            value = displayValue = 0;
        }

        public int GetValue()
        {
            return value;
        }

        public void DoubleValue()
        {
            value++;
            displayValue *= 2;
        }

        public void ResetValue()
        {
            value = displayValue = 0;
        }

        public void InitializeValue()
        {
            value = 1;
            displayValue = 2;
        }

        public int GetDisplayValue()
        {
            return displayValue;
        }
    }
}
