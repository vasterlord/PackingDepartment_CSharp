using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PackingDepartment_CSharp
{
    public class DigitalScales : RealNumber
    {
        public DigitalScales() : base()
        {
            WeightError = 0.1;
            OneCost = 10;
            CommonCost = 100;
        }
        public DigitalScales(double min, double max, double value, double weightError, double oneCost, double commonCost) : base(min, max, value)
        {
            WeightError = weightError;
            OneCost = oneCost;
            CommonCost = 100;
        }
        public double WeightError { get; set; }
        public double OneCost { get; set; }
        public double CommonCost { get; set; }

        public override double Cost()
        {
            return (double)this.Number * OneCost;
        }
    }
}
