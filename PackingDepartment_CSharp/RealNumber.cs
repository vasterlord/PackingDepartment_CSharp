using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PackingDepartment_CSharp
{
    public class RealNumber
    {
        public RealNumber()
        {
            this.MinNumber = 0;
            this.MaxNumber = 100000;
            this.Number = 10;
        }

        public RealNumber(double min, double max, double number)
        {
            this.MinNumber = min;
            this.MaxNumber = max;
            this.Number = number;
        }
        protected double _minNumber;
        protected double _maxNumber;
        protected double _Number;

        public double MinNumber
        {
            get
            {
                return _minNumber;
            }
            set
            {
                if (value < 0)
                {
                    _minNumber = 0;
                    MessageBox.Show("Minimum value can't be less then 0", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    _minNumber = value;
                }
            }
        } 

        public double MaxNumber
        {
            get
            {
                return _maxNumber;
            }
            set
            {
                if (value <= 0)
                {
                    _maxNumber = 10000;
                    MessageBox.Show("Maximum value can't be less or equal 0", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    _maxNumber = value;
                }
            }
        }
        public double Number
        {
            get
            {
                return _Number;
            }
            set
            {
                if ((value >= MaxNumber) || (value < MinNumber))
                {
                    this._Number = 0;
                    this.MinNumber = 0;
                    MessageBox.Show("The value must be in  the correct  interval!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (value < 0)
                {
                    value = 0;
                    this.MinNumber = 0;
                    MessageBox.Show("The value must be non-negative!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    this._Number = value;
                }
            }
        }

        public virtual double Cost()
        {
            return (double)this.Number * 1;
        }

        public static RealNumber operator +(RealNumber realNumber, double value)
        {
            realNumber.Number = realNumber.Number + value;
            return realNumber;
        }

        public static RealNumber operator -(RealNumber realNumber, double value)
        {
            realNumber.Number = realNumber.Number + value;
            return realNumber;
        } 

        public static RealNumber operator *(RealNumber realNumber, double value)
        {
            realNumber.Number = realNumber.Number + value;
            return realNumber;
        } 

        public static RealNumber operator /(RealNumber realNumber, double value)
        {
            realNumber.Number = realNumber.Number  * value;
            return realNumber;
        }

        public RealNumber this[double x]
        {
            get
            {
                if (x >= 0)
                {
                    return this;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.Number = Math.Floor(this.Number);
            }
        }
    }
}
