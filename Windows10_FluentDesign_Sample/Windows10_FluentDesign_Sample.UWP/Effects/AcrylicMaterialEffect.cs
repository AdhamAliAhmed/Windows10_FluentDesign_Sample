using System;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows10_FluentDesign_Sample.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("Win10")]
[assembly: ExportEffect(typeof(Windows10_FluentDesign_Sample.UWP.Effects.AcrylicMaterialEffect), nameof(Windows10_FluentDesign_Sample.UWP.Effects.AcrylicMaterialEffect))]
[assembly: ExportEffect(typeof(Windows10_FluentDesign_Sample.UWP.Effects.RevealHighLightButtonEffect), nameof(Windows10_FluentDesign_Sample.UWP.Effects.RevealHighLightButtonEffect))]
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

        void UpdateControl()
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

    public class RevealHighLightButtonEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            //var button = Control as Windows.UI.Xaml.Controls.Button;
            var rect = Control as Windows.UI.Xaml.Shapes.Rectangle;

            var accentColor = (Windows.UI.Color)Windows.UI.Xaml.Application.Current.Resources["SystemAccentColor"];
            RevealBorderBrush borderBrush = new RevealBorderBrush() { TargetTheme = ApplicationTheme.Light, Color = accentColor, FallbackColor = accentColor };
            RevealBackgroundBrush backgroundBrush = new RevealBackgroundBrush() { TargetTheme = ApplicationTheme.Light, Color = accentColor, FallbackColor = accentColor };

            //button.Style = Windows.UI.Xaml.Application.Current.Resources["ButtonRevealStyle"] as Windows.UI.Xaml.Style;
        }

        private void Rect_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Hover");
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }
    }
}
