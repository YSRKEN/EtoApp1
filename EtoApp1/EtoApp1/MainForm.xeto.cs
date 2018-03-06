using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;
using System.ComponentModel;
using Reactive.Bindings;

namespace EtoApp1
{	
	public class MainForm : Form
	{	
		public MainForm()
		{
			XamlReader.Load(this);
			this.DataContext = new MainViewModel();
		}
	}
	public class MainViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ReactiveProperty<Image> SampleImage { get; } = new ReactiveProperty<Image>();
		public ReactiveCommand SampleCommand { get; } = new ReactiveCommand();
		public MainViewModel() {
			SampleImage.Value = new Bitmap(100, 100, PixelFormat.Format24bppRgb);
			SampleCommand.Subscribe(_ => {
				SampleImage.Value = new Bitmap(100, 100, PixelFormat.Format24bppRgb);
			});
		}
	}
}
