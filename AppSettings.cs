using RuFramework.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Serialization;

/*
using RuFramework.Config;
namespace RuConfig
{
    public partial class Form1 : Form
    {
         AppSettings appSettings = new AppSettings();
        
        public Form1()
        {
            InitializeComponent();
            // Select the config data path
            //                                          ConfigManager.GetAppDataPath(AppDataPath.Local);
            //                                          ConfigManager.GetAppDataPath(AppDataPath.Common);
            //                                          ConfigManager.GetAppDataPath(AppDataPath.ExePath);
            //                                          ConfigManager.GetAppDataPath(AppDataPath.Roaming);
            // Default read data = ConfigManager.Read(ConfigManager.GetAppDataPath(AppDataPath.Roaming))
            appSettings = ConfigManager.Read(); // default Roaming
        }
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            //AppSettingsDialog appSettingsDialog = new AppSettingsDialog(appSettings, AppDataPath.Roaming);
            AppSettingsDialog appSettingsDialog = new AppSettingsDialog(appSettings); // default Roaming
            appSettingsDialog.propertyGrid.SelectedObject = appSettings;
            appSettingsDialog.ShowDialog();
            appSettings = appSettingsDialog.AppSettingsOk;

            // Property is changed in the program, you must save
            ChangeAppSettings();
         }
        private void ChangeAppSettings()
        {
            appSettings.MyString = "Property MyString changed";
            // ConfigManager.Save(appSettings, AppDataPath.Roaming);
            // or
            ConfigManager.Save(appSettings); // default Roaming
        }
    }
}
*/

namespace RuFramework.Config
{
    [XmlType(TypeName = "appSettings")]
    [Serializable]
    public class AppSettings : EventArgs
    {
        /*
        Standard category translated into the national language

        Action      Properties related to available actions.
        Appearance  Properties related to how an entity appears.
        Behavior    Properties related to how an entity acts. 
        Data        Properties related to data and data source management.
        Default     Properties that are grouped in a default category.
        Design      Properties that are available only at design time.
        DragDrop    Properties related to drag-and-drop operations. 
        Focus       Properties related to focus.
        Format      Properties related to formatting.
        Key         Properties related to the keyboard. 
        Layout      Properties related to layout.
        Mouse       Properties related to the mouse. 
        WindowStyle Properties related to the window style of top-level forms.
        */
        #region Bool as object with Enum-Converter
        // Property Boolean with Enum-Converter
        [Category("Bool as object with Enum-Converter")]
        [Description("Description Unit")]
        [DisplayName("UNIT")]
        [TypeConverter(typeof(EnumConverter))]
        [Browsable(true)]
        public Unit MyUnit { set; get; } = Unit.cm;

        // Property Boolean with Enum-Converter
        [Category("Bool as object with Enum-Converter")]
        [Description("Description Drinker doses")]
        [DisplayName("DRINKER DOSES")]
        [TypeConverter(typeof(DrinkDosesConverter))]
        [Browsable(true)]
        public DrinkDoses MyDoses { set; get; }


        [Category("Boolean as object with True/False Converter")]
        [Description("Description Yes or No")]
        [DisplayName("YES/NO")]
        [TypeConverter(typeof(TrueFalseConverter))]
        [Browsable(true)]
        public bool MyDrinkOrNot { set; get; } = true;
        #endregion

        #region General property
        // Property Boolean
        [Category("General property")]
        [Description("Description Boolean")]
        [DisplayName("BOOLEAN")]
        [Browsable(true)]
        public bool MyBoolean { set; get; } = false;

        // Property Byte
        [Category("General property")]
        [Description("Description Byte")]
        [DisplayName("BYTE")]
        [Browsable(true)]
        public byte MyByte { set; get; } = 30;

        // Property Collection
        [Category("General property")]
        [Description("Description Collection")]
        [DisplayName("COLLECTION")]
        [Browsable(true)]
        // List cannot set default values because, strangely enough, it is always added
        public List<double> MyCollection { set; get; } // new List<double>() {  1.5, 2.6, 3.7 };

        // Property Decimal
        [Category("General property")]
        [Description("Description Decimal")]
        [DisplayName("DECIMAL")]
        [Browsable(true)]
        public decimal MyDecimal { set; get; } = 5;

        // Property Integer
        [Category("General property")]
        [Description("Description Integer")]
        [DisplayName("INTEGER")]
        [Browsable(true)]
        public int MyInteger { set; get; } = 4;

        // Property Point
        [Category("General property")]
        [Description("Description Point")]
        [DisplayName("POINT")]
        [Browsable(true)]
        public Point MyPoint { set; get; } = new Point(10, 15);

        // Property Size
        [Category("General property")]
        [Description("Description Size")]
        [DisplayName("SIZE")]
        [Browsable(true)]
        public Size MySize { set; get; } = new Size(100, 200);

        // Property String
        [Category("General property")]
        [Description("Description String")]
        [DisplayName("STRING")]
        [Browsable(true)]
        public string MyString { set; get; } = "Klaus";
        #endregion

        #region UserType with converter

        // Property Address, UserType
        [Category("UserType with Converter")]
        [Description("Description Address")]
        [DisplayName("ADDRESS")]
        [Browsable(true)]
        [TypeConverterAttribute(typeof(AddressConverter))]

        public Address MyAddress { set; get; } = new Address("Mustermann", "Klaus", "10178", "Berlin", "Hauptstr. 1");

        // Property Lenght, UserType
        [Category("UserType with Converter")]
        [Description("Description Lenght")]
        [DisplayName("LENGTH")]
        [Browsable(true)]
        [TypeConverterAttribute(typeof(LenghtConverter))]
        public Length MyLength { set; get; } = new Length(10, Unit.cm);

        #endregion

        #region With deputy Property
        // Property Color, cannot be serialized
        [Category("With deputy Property")]
        [Description("Description Color")]
        [DisplayName("COLOR")]
        [XmlIgnore]
        public Color MyColor { get; set; } = Color.Red;

        // Property Deputy Color, this is serialized
        [XmlElement("MyColor")]
        [Browsable(false)]
        public string MyColor_Internal
        {
            get { return ColorTranslator.ToHtml(this.MyColor); }
            set { this.MyColor = ColorTranslator.FromHtml(value); }
        }

        #endregion

        #region With UITypeEdotor
        // Property Filename
        [Category("With UITypeEditor")]
        [Description("Description Filename")]
        [DisplayName("Filename")]
        [Editor(typeof(FileSelectorTypeEditor), typeof(UITypeEditor))]
        [Browsable(true)]
        public string MyFileName { set; get; } = @"D:\Temp\Killme.txt";

        // Property Guid
        [Category("With UITypeEditor")]
        [Description("Description Guid")]
        [DisplayName("GUID")]
        [Editor(typeof(GuidUITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Browsable(true)]
        public string MyGuid { set; get; } = new Guid().ToString();

        // Property Multiline
        [Category("With UITypeEditor")]
        [Description("Description Multiline")]
        [DisplayName("MULTILINE")]
        [Editor(typeof(MultiLineUITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Browsable(true)]
        public string MyMultiline { set; get; } = "aaaa\nbbbb\ncccc\n";

        // Property path, location
        [Category("With UITypeEditor")]
        [Description("Description Path")]
        [DisplayName("Path")]
        [Editor(typeof(FolderNameEditorWithRootFolder), typeof(System.Drawing.Design.UITypeEditor))]
        [Browsable(true)]
        public string MyPath { set; get; } = @"C:\Users";

        #endregion

    }

}
