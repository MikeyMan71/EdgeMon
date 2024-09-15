using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace RuFramework.Config
{
    // Class + Converter Address
    #region Address
    [Serializable]
    public class Address
    {

        public static readonly Address Empty = new Address();

        private string lastname;
        private string firstname;
        private string zipcode;
        private string city;
        private string streat;

        public Address()
        {
            this.lastname = String.Empty;
            this.firstname = String.Empty;
            this.zipcode = String.Empty;
            this.city = String.Empty;
            this.streat = String.Empty;
        }

        /// <devdoc>
        ///    with the specified coordinates.
        /// </devdoc>
        public Address(string lastname, string firstname, string zipcode, string city, string streat)
        {
            this.lastname = lastname;
            this.firstname = firstname;
            this.zipcode = zipcode;
            this.city = city;
            this.streat = streat;
        }
        /// <devdoc>
        ///    <para>
        ///    </para>
        /// </devdoc>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return lastname == null && firstname == null && zipcode == null && city == null && streat == null;
            }
        }

        public String Lastname
        {
            set { lastname = value; }
            get { return lastname; }
        }
        public String Firstname
        {
            set { firstname = value; }
            get { return firstname; }
        }


        public String Zipcode
        {
            set { zipcode = value; }
            get { return zipcode; }
        }


        public String City
        {
            set { city = value; }
            get { return city; }
        }


        public String Streat
        {
            set { streat = value; }
            get { return streat; }
        }


        /// <devdoc>
        ///    <para>
        ///       the same coordinates as the specified <see cref='System.Object'/>.
        ///    </para>
        /// </devdoc>
        public override bool Equals(object obj)
        {
            if (!(obj is Address)) return false;
            Address comp = (Address)obj;
            // Note value types can't have derived classes, so we don't need 
            // to check the types of the objects here.  -- Microsoft, 2/21/2001
            return comp.lastname == this.lastname && comp.firstname == this.firstname && comp.zipcode == this.zipcode && comp.city == this.city && comp.streat == this.streat;
        }

        /// <devdoc>
        ///    <para>
        ///       Returns a hash code.
        ///    </para>
        /// </devdoc>
        public override int GetHashCode()
        {
            return (lastname + firstname + zipcode + city + streat).GetHashCode();
        }
    }

    #endregion
    #region Length
    public class Length
    {
        #region Overridden Members
        public Length()
        {
        }

        public Length(float value, Unit unit)
        {
            this.Value = value;
            this.Unit = unit;
        }

        public override string ToString()
        {
            string value;
            string unit;

            value = this.Value.ToString(CultureInfo.InvariantCulture);
            unit = this.Unit.ToString();

            return string.Concat(value, unit);
        }

        public float Value { get; set; }

        [XmlIgnore]
        public Unit Unit { get; set; }

        [XmlElement("Unit")]
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public int UnitInt32
        {
            get { return (int)Unit; }
            set { Unit = (Unit)value; }
        }
        #endregion
    }
    #endregion
    #region Enum
    public enum Unit
    {
        cm,
        mm,
        pt,
        px
    }

    #endregion
}
