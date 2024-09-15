using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace RuFramework.Config
{
    internal class TrueFalseConverter : BooleanConverter

    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            return (bool)value ? "Yes" : "No"; // or "On": Off
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return (string)value == "Yes"; // or "On"
        }
    }

    internal class AddressConverter : TypeConverter
    {
        /// <devdoc>
        ///     Bestimmt, ob dieser Konverter ein Objekt in der angegebenen Quelle konvertieren kann
        ///     vom typ auf den systemeigenen Typ des Konverters.
        /// </devdoc>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        /// <devdoc>
        ///     <para>
        ///         Ruft einen Wert ein, der angibt, ob dieser Konverter
        ///         das Konvertieren eines Objekts in den angegebenen Zieltyp mithilfe der context erlaubt.
        ///     </para>
        /// <(devdoc>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }
        /// <devdoc>
        ///     Konvertiert das angegebene Objekt in den systemeigenen Typ des Konverters.
        ///     Sonst wird eine NotSupportedException auslösen.
        /// </devdoc>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1808:AvoidCallsThatBoxValueTypes")]
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {

            string strValue = value as string;

            //  Debug.Print("Address From: " + strValue);

            if (strValue != null)
            {

                string text = strValue.Trim();

                if (text.Length == 0)
                {
                    return null;
                }
                else
                {
                    // Parse 5 string values.
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }
                    char sep = culture.TextInfo.ListSeparator[0];
                    string[] tokens = text.Split(new char[] { sep });

                    if (tokens.Length == 5)
                    {
                        // Debug.Print("Address From: " + tokens[0].ToString() + tokens[1].ToString());
                        return new Address(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4]);
                    }
                    else
                    {
                        ; // throw new ArgumentException(SR.GetString(SR.TextParseFailedFormat, text, "x, y"));
                    }
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
        /// <devdoc>
        ///     Konvertiert das angegebene Objekt in einen anderen Typ.Die am häufigsten zu konvertierenden Typen
        ///     sind zu und von einem String-Objekt.Die Standardimplementierung führt einen Aufruf aus.
        ///     ToString() auf dem Objekt, wenn das Objekt gültig ist und wenn das Ziel vom Typ ist String.
        ///     Wenn dies nicht in den Entsendetyp konvertiert werden kann, wird eine NotSupportedException auslösen.
        /// </devdoc>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }

            if (value is Address)
            {
                if (destinationType == typeof(string))
                {
                    Address address = (Address)value;
                    //   Debug.Print("Address TO: " + address.Lastname + "/" + address.Firstname + " (Source)");

                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }
                    string sep = culture.TextInfo.ListSeparator + " ";
                    //   TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(int));
                    TypeConverter stringConverter = TypeDescriptor.GetConverter(typeof(string));
                    string[] args = new string[5];
                    int nArg = 0;

                    // Note: ConvertToString will raise exception if value cannot be converted.
                    args[nArg++] = stringConverter.ConvertToString(context, culture, address.Lastname);
                    args[nArg++] = stringConverter.ConvertToString(context, culture, address.Firstname);
                    args[nArg++] = stringConverter.ConvertToString(context, culture, address.Zipcode);
                    args[nArg++] = stringConverter.ConvertToString(context, culture, address.City);
                    args[nArg++] = stringConverter.ConvertToString(context, culture, address.Streat);

                    string s = string.Join(sep, args);
                    //   Debug.Print("Address TO: " + s + " (Destinatiom)");
                    return string.Join(sep, args);
                }
                if (destinationType == typeof(InstanceDescriptor))
                {
                    Address address = (Address)value;

                    ConstructorInfo ctor = typeof(Address).GetConstructor(new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) });
                    if (ctor != null)
                    {
                        return new InstanceDescriptor(ctor, new object[] { address.Lastname, address.Firstname, address.Zipcode, address.City, address.Streat });
                    }
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
        /// <devdoc>
        ///     Erstellt eine Instanz dieses Typs unter Beanstehen eines Satzes von Eigenschaftswerten
        ///     für das Objekt.Dies ist nützlich für Objekte, die unveränderlich sind, aber dennoch
        ///     wechselnden Eigenschaften bereitstellen möchten.
        /// </devdoc>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1808:AvoidCallsThatBoxValueTypes")]
        [SuppressMessage("Microsoft.Security", "CA2102:CatchNonClsCompliantExceptionsInGeneralHandlers")]
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }

            object lastname = propertyValues["Lastname"];
            object firstname = propertyValues["Firstname"];
            object zipcode = propertyValues["Zipcode"];
            object city = propertyValues["City"];
            object streat = propertyValues["Streat"];

            if (lastname == null || firstname == null || zipcode == null || city == null || streat == null ||
                !(lastname is string) || !(firstname is string) || !(zipcode is string) || !(city is string) || !(streat is string))
            {
                ; // throw new ArgumentException(SR.GetString(SR.TextParseFailedFormat, text, "x, y"));
            }


            return new Address((string)lastname, (string)firstname, (string)zipcode, (string)city, (string)streat);

        }
        /// <devdoc>
        ///     Legt fest, ob das Ändern eines Werts für dieses Objekt einen Aufruf
        ///     CreateInstance erfordert, um einen neuen Wert zu erstellen.        
        /// </devdoc>

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        /// <devdoc>
        ///     Ruft den Satz von Eigenschaften für diesen Typ ab.Standardmäßig hat ein Typ
        ///     gibt keine Eigenschaften zurück.Eine einfache Implementierung dieser Methode
        ///     kann nur TypeDescriptor.GetProperties für den richtigen Datentyp aufrufen.
        /// </devdoc>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(Address), attributes);
            return props.Sort(new string[] { "Lastname", "Firstname", "Zipcode", "City", "Streat" });
        }
        /// <devdoc>
        /// Bestimmt, ob dieses Objekt Eigenschaften unterstützt.Standardmäßig wird dies ist false.       
        /// </devdoc>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }

    internal class LenghtConverter : TypeConverter
    {
        /// Bestimmt, ob dieser Konverter ein Objekt in der angegebenen Quelle konvertieren kann
        /// vom typ (in der Regel sring) auf den systemeigenen Typ des Konverters.    
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        /// Bestimmt, ob dieser Konverter ein Objekt vom Typ des Konverters in einen anderen Typ
        /// (in der Regel sring) kovertiert werden kann.    
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }
        /// Konvertiert das angegebene Objekt in den systemeigenen Typ des Konverters.
        /// Sonst wird eine NotSupportedException auslösen.
        [SuppressMessage("Microsoft.Performance", "CA1808:AvoidCallsThatBoxValueTypes")]
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string strValue = value as string;
            // Debug.Print("Lenght From: " + strValue);
            if (strValue != null)
            {
                string text = strValue.Trim();

                if (text.Length == 0)
                {
                    return null;
                }
                else
                {

                    // Parse 2 string values.
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }
                    char sep = culture.TextInfo.ListSeparator[0];
                    string[] tokens = text.Split(new char[] { sep });

                    if (tokens.Length == 2)
                    {
                        //   Debug.Print("Lenght From: " + tokens[0].ToString() + "/" + tokens[1].ToString());
                        Unit unit = new Unit();
                        unit = (Unit)Enum.Parse(typeof(Unit), tokens[1], true);
                        return new Length(Convert.ToSingle(tokens[0]), (Unit)Enum.Parse(typeof(Unit), tokens[1], true));
                    }
                    else
                    {
                        throw new ArgumentException(String.Format("{0} (\"Lengt; Unit\") does not have the right format", text));
                    }
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
        /// Konvertiert das angegebene Objekt in einen anderen Typ.Die am häufigsten zu konvertierenden Typen
        /// sind zu und von einem String-Objekt.Die Standardimplementierung führt einen Aufruf aus.
        /// ToString() auf dem Objekt, wenn das Objekt gültig ist und wenn das Ziel vom Typ ist String.
        /// Wenn dies nicht in den Entsendetyp konvertiert werden kann, wird eine NotSupportedException auslösen.
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            // To funktioniert
            // Von z.B. 10 - cm to 10;cm
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if (value is Length)
            {
                if (destinationType == typeof(string))
                {
                    Length lenght = (Length)value;
                    //  Debug.Print("Lenght TO: " + lenght.Value.ToString() + "/" + lenght.Unit.ToString() + " (Source)");

                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }
                    string sep = culture.TextInfo.ListSeparator + " ";
                    TypeConverter stringConverter = TypeDescriptor.GetConverter(typeof(string));
                    string[] args = new string[2];
                    int nArg = 0;
                    args[nArg++] = stringConverter.ConvertToString(context, culture, lenght.Value);
                    args[nArg++] = stringConverter.ConvertToString(context, culture, lenght.Unit);

                    string s = string.Join(sep, args);
                    //  Debug.Print("Lenght TO: " + s + " (Destination)");
                    return string.Join(sep, args);

                }
                if (destinationType == typeof(InstanceDescriptor))
                {
                    Length length = (Length)value;

                    ConstructorInfo ctor = typeof(Length).GetConstructor(new Type[] { typeof(float), typeof(string) });
                    if (ctor != null)
                    {
                        return new InstanceDescriptor(ctor, new object[] { length.Value, length.Unit });
                    }
                }

            }
            return base.ConvertTo(context, culture, value, destinationType);

        }
        /// Erstellt eine Instanz dieses Typs unter Beanstehen eines Satzes von Eigenschaftswerten
        /// für das Objekt.Dies ist nützlich für Objekte, die unveränderlich sind, aber dennoch
        /// wechselnden Eigenschaften bereitstellen möchten.
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }

            object value = propertyValues["Value"];
            object unit = propertyValues["Unit"];

            if (value == null || unit is null || !(value is float) || !(unit is Unit))
            {
                throw new ArgumentException(String.Format("{0} {1} (\"Lengt; Unit\") does not have the right format", value.ToString(), unit.ToString()));
            }
            return new Length((float)value, (Unit)Enum.Parse(typeof(Unit), unit.ToString(), true));
        }
        /// Legt fest, ob das Ändern eines Werts für dieses Objekt einen Aufruf
        /// CreateInstance erfordert, um einen neuen Wert zu erstellen.        
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        /// Ruft den Satz von Eigenschaften für diesen Typ ab.Standardmäßig hat ein Typ
        /// gibt keine Eigenschaften zurück.Eine einfache Implementierung dieser Methode
        /// kann nur TypeDescriptor.GetProperties für den richtigen Datentyp aufrufen.
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(Length), attributes);
            return props.Sort(new string[] { "Value", "Unit" });
        }
        /// Bestimmt, ob dieses Objekt Eigenschaften unterstützt.Standardmäßig wird dies ist false.       
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
    public class DrinkDosesConverter : EnumConverter
    {
        private Type _enumType;
        /// <summary />Initializing instance</summary />
        /// <param name=""type"" />type Enum</param />
        /// this is only one function, that you must
        /// change. All another functions for enums
        /// you can use by Ctrl+C/Ctrl+V
        public DrinkDosesConverter(Type type)
            : base(type)
        {
            _enumType = type;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context,
            Type destType)
        {
            return destType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture,
            object value, Type destType)
        {
            FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, value));
            DescriptionAttribute dna =
                (DescriptionAttribute)Attribute.GetCustomAttribute(
                fi, typeof(DescriptionAttribute));

            if (dna != null)
                return dna.Description;
            else
                return value.ToString();
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context,
            Type srcType)
        {
            return srcType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture,
            object value)
        {
            foreach (FieldInfo fi in _enumType.GetFields())
            {
                DescriptionAttribute dna =
                (DescriptionAttribute)Attribute.GetCustomAttribute(
                fi, typeof(DescriptionAttribute));

                if ((dna != null) && ((string)value == dna.Description))
                    return Enum.Parse(_enumType, fi.Name);
            }
            return Enum.Parse(_enumType, (string)value);
        }
    }
    public enum DrinkDoses
    {
        litre,
        oneLitre,
        twoLitre,
        threeLitres,
        fourLitres,
        fiveLitres
    }

}

