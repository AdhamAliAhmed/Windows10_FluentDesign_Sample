using System;
using Xamarin.Forms;

namespace Windows10_FluentDesign_Sample.UWP
{
    public static class Utils
    {
        public static Windows.UI.Color ToUwpColor(this Xamarin.Forms.Color color) =>
            new Windows.UI.Color() { A = (Byte)(color.A * 255), R = (Byte)(color.R * 255), G = (Byte)(color.G * 255), B = (Byte)(color.B * 255) };
    }
}
