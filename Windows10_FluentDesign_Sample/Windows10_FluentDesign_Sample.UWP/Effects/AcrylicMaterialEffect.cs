using System;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows10_FluentDesign_Sample.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("Win10")]
[assembly: ExportEffect(typeof(Windows10_FluentDesign_Sample.UWP.Effects.AcrylicMaterialEffect), nameof(Windows10_FluentDesign_Sample.UWP.Effects.AcrylicMaterialEffect))]
namespace Windows10_FluentDesign_Sample.UWP.Effects
{
    public class AcrylicMaterialEffect : PlatformEffect
    {
        AcrylicBrush brush;
        AcrylicBackgroundSource backgroundSource;
        Windows.UI.Color tintColor, fallbackColor;
        double tintOpacity;

        protected override void OnAttached()
        {
            UpdateTintColor();
            UpdateFallbackColor();
            UpdateTintOpacity();
            UpdateBackgroundSource();

            UpdateControl();

            //var brush = Windows.UI.Xaml.Application.Current.Resources["SystemControlAccentAcrylicWindowAccentMediumHighBrush"] as AcrylicBrush;
            //var tintColor = brush.TintColor;
            //var fallbackColor = brush.FallbackColor;
            //var opacity = brush.TintOpacity;
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if(args.PropertyName == AcrylicMaterial.TintColorProperty.PropertyName)
            {
                UpdateTintColor();
                UpdateControl();
            }
            else if (args.PropertyName == AcrylicMaterial.FallbackColorProperty.PropertyName)
            {
                UpdateFallbackColor();
                UpdateControl();
            }
            else if (args.PropertyName == AcrylicMaterial.TintOpacityProperty.PropertyName)
            {
                UpdateTintOpacity();
                UpdateControl();
            }
            else if (args.PropertyName == AcrylicMaterial.BackgroundSourceProperty.PropertyName)
            {
                UpdateBackgroundSource();
                UpdateControl();
            }
        }
        void UpdateTintColor()
        {
            tintColor = AcrylicMaterial.GetTintColor(Element).ToUwpColor();
        }
        void UpdateTintOpacity()
        {
            tintOpacity = AcrylicMaterial.GetTintOpacity(Element);
            //tintOpacity = (double)Element.GetValue(AcrylicMaterial.TintOpacityProperty);
        }
        void UpdateBackgroundSource()
        {
            backgroundSource = (AcrylicBackgroundSource)Enum.Parse(typeof(AcrylicBackgroundSource), AcrylicMaterial.GetBackgroundSource(Element).ToString());
        }
        void UpdateFallbackColor()
        {
            fallbackColor = AcrylicMaterial.GetFallbackColor(Element).ToUwpColor();
        }

        private void UpdateControl()
        {
            brush = new AcrylicBrush()
            {
                TintColor = tintColor,
                TintOpacity = tintOpacity,
                BackgroundSource = backgroundSource,
                FallbackColor = fallbackColor
            };

            try
            {
                Control.GetType().GetProperty("Background").SetValue(Control, brush);
            }
            catch
            {
                Control.GetType().GetProperty("Fill").SetValue(Control, brush);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
