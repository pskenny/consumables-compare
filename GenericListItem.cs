using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumables_Compare
{
    public class GenericListItem : IEquatable<GenericListItem>, IComparable<GenericListItem>
    {
        //Constants
        public const string GRAM = "g";
        public const string CENTIMETER = "cm";
        public const string MILLILITRE = "ml";

        public string Unit;
        public double Price, UnitValue;
        double PricePerUnit
        {
            get { return Price / UnitValue; }
            set { }
        }
        public string Name;

        public GenericListItem(string name, double price, double unitValue, string unit)
        {
            Name = name;
            Price = price;
            UnitValue = unitValue;
            Unit = unit;
        }

        public override string ToString()
        {
            return Name + "   Price Per " + Unit + ": " + PricePerUnit;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            GenericListItem objAsItem = obj as GenericListItem;
            if (objAsItem == null) return false;
            else return Equals(objAsItem);
        }

        public int SortByNameAscending(string name1, string name2)
        {

            return name1.CompareTo(name2);
        }

        public int CompareTo(GenericListItem compareItem)
        {
            // A null value means that this object is greater.
            if (compareItem == null) return 1;
            else return this.PricePerUnit.CompareTo(compareItem.PricePerUnit);
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(PricePerUnit);
        }

        public bool Equals(GenericListItem other)
        {
            if (other == null) return false;
            return (this.PricePerUnit.Equals(other.PricePerUnit));
        }
    }
}
