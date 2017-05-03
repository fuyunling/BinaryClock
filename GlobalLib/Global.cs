using System.Collections.Generic;
using System.Drawing;

namespace GlobalLib
{
    public class Global
    {
        public static Rectangle[] Matrix { get; set; }
        public static Rectangle[] Bits { get; set; }
        public static List<Rectangle> ListBits { get; set; }
        //public static Bitmap Icon { get; set; }
        public static Brush ShadowBrush { get; set; }
        public static Brush ClockBrush { get; set; }
        public static Pen ClockPen { get; set; }

        public static Color ClockColor { get; set; }
        public static Color ShadowColor { get; set; }
        public static Color DefaultColor = Color.GhostWhite;
        public static Color DefaultShadow = Color.DarkGray;

        public const string MenuSnapshot = "Snapshot";
        public const string MenuSetting = "Setting...";
        public const string MenuColor = "Color...";
        public const string MenuReverse = "Reverse";
        public const string MenuAbout = "About";
        public const string MenuExit = "Exit";
        public const string SaveSnapshot = "Save snapshot";

        public static string ConfigFile = "binaryclock.ini";

        public const string CatagoryAppearance = "Appearance";
        public const string FieldOpacity = "Opacity";
        public const string FieldGridWidth = "Grid Width";
        public const string FieldOrder = "Order";
        
        public const string CatagoryLocation = "Location";
        public const string FieldLocation = "Location";
        public const string FieldAlwaysOnTop = "Always on Top";

        public const string CatagoryBox = "Box";
        public const string FieldBoxType = "Box Type";
        public const string FieldBoxSize = "Box Size";
        public const string FieldBoxColor = "Box Color";
        public const string FieldShadowColor = "Shadow Color";

        public const string Order1248 = "1248";
        public const string Order8421 = "8421";
    }

    public enum BoxType
    {
        None,
        Border,
        Shadow
    }
}
