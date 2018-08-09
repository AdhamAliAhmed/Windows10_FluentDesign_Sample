using Windows10_FluentDesign_Sample.Models;
using Xamarin.Forms;

namespace Windows10_FluentDesign_Sample.Effects
{
    public static class AcrylicMaterial
    {
        public static readonly BindableProperty TintColorProperty = BindableProperty.CreateAttached("TintColor", typeof(Color), typeof(AcrylicMaterial), default(Color));
        public static readonly BindableProperty FallbackColorProperty = BindableProperty.CreateAttached("FallbackColor", typeof(Color), typeof(AcrylicMaterial), default(Color));
        public static readonly BindableProperty TintOpacityProperty = BindableProperty.CreateAttached("TintOpacity", typeof(double), typeof(AcrylicMaterial), default(double));
        public static readonly BindableProperty BackgroundSourceProperty = BindableProperty.CreateAttached("BackgroundSource", typeof(BackgroundSource), typeof(AcrylicMaterial), default(BackgroundSource));

        public static Color GetTintColor(BindableObject view)=>
            (Color)view.GetValue(TintColorProperty);
        public static void SetTintColor(BindableObject view, Color value) =>
            view.SetValue(TintColorProperty, value);

        public static double GetTintOpacity(BindableObject view) =>
            (double)view.GetValue(TintOpacityProperty);
        public static void SetTintOpacity(BindableObject view,double value) =>
            view.SetValue(TintOpacityProperty, value);

        public static Color GetFallbackColor(BindableObject view) =>
            (Color)view.GetValue(FallbackColorProperty);
        public static void SetFallbackColor(BindableObject view, Color value) =>
            view.SetValue(FallbackColorProperty, value);

        public static BackgroundSource GetBackgroundSource(BindableObject view) =>
            (BackgroundSource)view.GetValue(BackgroundSourceProperty);
        public static void SetBackgroundSource(BindableObject view, BackgroundSource value) =>
            view.SetValue(BackgroundSourceProperty, value);

    }

    public class AcrylicMaterialEffect : RoutingEffect
    {
        public AcrylicMaterialEffect(): base("Win10.AcrylicMaterialEffect")
        {
        }

    }
}
