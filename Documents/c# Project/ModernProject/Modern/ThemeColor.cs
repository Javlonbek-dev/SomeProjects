using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern
{
  public static class ThemeColor
    {
     public static Color PrimaryColor { get; set; }
     public static Color SecondaryColor { get; set; }
     public static List<string> ColorList = new List<string>()
        {
            "#009688",
            "#FF5722",
            "#607D8b",
            "#6C27b0",
            "#2196f3",
            "#EA676C",
            "#E41A4a",
            "#5978BB",
            "#018790",
            "#0E3441",
            "#00B0AD",
            "#721D47",
            "#EA4833",
            "#EF937E",
            "#F37521",
            "#A12059",
            "#126881",
            "#8BC240",
            "#364D5b",
            "#c7DC5B",
            "#0094BC",
            "#E4126B",
            "#43B76E",
            "#7BCfE9",
            "#B71C46"
        };
        public static Color ChangeColorBrightness(Color color,double currectionFactor)
        {
            double red=color.R;
            double green=color.G;
            double blue=color.B;
            if(currectionFactor < 0)
            {
                currectionFactor = 1 + currectionFactor;
                red = red * currectionFactor;
                green = green * currectionFactor;
                blue = blue * currectionFactor;
            }
            else
            {
                red=(255-red) * currectionFactor+red;
                green=(255-green) * currectionFactor+green;
                blue=(255-blue) * currectionFactor+blue;
            }
            return Color.FromArgb(color.A,(byte)red, (byte)green, (byte)blue); 
        } 
    }
}
