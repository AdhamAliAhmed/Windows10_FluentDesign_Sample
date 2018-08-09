using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Windows10_FluentDesign_Sample.Effects;
using Windows10_FluentDesign_Sample.Models;
using Xamarin.Forms;

namespace Windows10_FluentDesign_Sample.ViewModels
{
    public class AcrylicMaterialPageViewModel : BaseViewModel
    {
        Color _tintColor;
        int _tintColorR;
        int _tintColorG;
        int _tintColorB;

        Color _fallbackColor;
        int _fallbackColorR;
        int _fallbackColorG;
        int _fallbackColorB;

        double _tintOpacity;
        BackgroundSource _backgroundSource;
        IList<BackgroundSource> _backgroundSources;

        public int TintColorR
        {
            get { return _tintColorR; }
            set { SetProperty(ref _tintColorR, value, onChanged: ()=> { TintColor = new Color(value, TintColorG, TintColorB); }); }
        }
        public int TintColorG
        {
            get { return _tintColorG; }
            set { SetProperty(ref _tintColorG, value, onChanged: () => { TintColor = new Color(TintColorR, value, TintColorB); }); }
        }
        public int TintColorB
        {
            get { return _tintColorB; }
            set { SetProperty(ref _tintColorB, value, onChanged: () => { TintColor = Color.FromRgb(TintColorR, TintColorG, value); }); }
        }
        public Color TintColor
        {
            get => _tintColor;

            private set
            {
                SetProperty(ref _tintColor, value);
            }
        }

        public int FallbackColorR
        {
            get { return _fallbackColorR; }
            set { SetProperty(ref _fallbackColorR, value, onChanged: () => { FallbackColor = new Color(value, FallbackColorG, FallbackColorB); }); }
        }
        public int FallbackColorG
        {
            get { return _fallbackColorG; }
            set { SetProperty(ref _fallbackColorG, value, onChanged: () => { FallbackColor = new Color(FallbackColorR, value, FallbackColorB); }); }
        }
        public int FallbackColorB
        {
            get { return _fallbackColorB; }
            set { SetProperty(ref _fallbackColorB, value, onChanged: () => { FallbackColor = Color.FromRgb(FallbackColorR, FallbackColorG, value); }); }
        }
        public Color FallbackColor
        {
            get { return _fallbackColor; }
            private set { SetProperty(ref _fallbackColor, value); }
        }

        public double TintOpacity
        {
            get { return _tintOpacity; }
            set { SetProperty(ref _tintOpacity, value); }
        }

        public BackgroundSource BackgroundSource
        {
            get { return _backgroundSource; }
            set { SetProperty(ref _backgroundSource, value); }
        }

        public IList<BackgroundSource> BackgroundSources
        {
            get { return _backgroundSources; }
            set { _backgroundSources = value; }
        }

        public AcrylicMaterialPageViewModel()
        {
            TintColorR =
            TintColorG =
            TintColorB =

            FallbackColorR = 
            FallbackColorG = 
            FallbackColorB = 96;

            BackgroundSource = BackgroundSource.Backdrop;

            TintOpacity = 0.5;

            BackgroundSources = new List<BackgroundSource>
            {
                BackgroundSource.Backdrop,
                BackgroundSource.HostBackdrop
            };
        }
    }
}
