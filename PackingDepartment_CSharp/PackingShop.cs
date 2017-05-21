using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingDepartment_CSharp
{
    public class PackingShop
    { 
        public List<RealNumber> digitalScales { get; set; }

        public PackingShop()
        {
            digitalScales = new List<RealNumber>();
        }

        public double PrepackCost(double commonWeight)
        {
            double prepackCost = 0; 
            /// сортуєм наш список
            digitalScales.OrderBy(scale => scale.Number);
            /// вибираємо тільки те із списку, де вага менша-рівна за введену
            foreach (var item in digitalScales.Where(scale=>scale.Number<=commonWeight))
            {
                prepackCost = prepackCost + item.Cost();
            }
            return prepackCost;
        }


        public double TotalError()
        {
            double totalError = 0;
            foreach (var item in digitalScales)
            {
                totalError = totalError + (item as DigitalScales).WeightError;
            }
            return totalError;
        }

        public double TotalProductsCost()
        {
            double totalProductsCost = 0;
            foreach (var item in digitalScales)
            {
                totalProductsCost = totalProductsCost + item.Cost();
            }
            return totalProductsCost;
        }

        public DigitalScales this[int x]
        {
            get
            {
                if (x < digitalScales.Count && x>-1)
                {
                    return ((DigitalScales)digitalScales[x]);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                digitalScales[x] = value;
            }
        }

        public RealNumber RealNumber
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
