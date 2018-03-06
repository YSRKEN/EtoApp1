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
		public ReactiveProperty<string> SampleLabel { get; } = new ReactiveProperty<string>();
		public ReactiveCommand SampleCommand { get; } = new ReactiveCommand();
		public ReactiveCommand SampleCommand2 { get; } = new ReactiveCommand();
		public MainViewModel() {
			SampleImage.Value = new Bitmap(100, 200, PixelFormat.Format24bppRgb);
			SampleLabel.Value = "A";
			SampleCommand.Subscribe(_ => {
				SampleImage.Value = new Bitmap(200, 100, PixelFormat.Format24bppRgb);
			});
			SampleCommand2.Subscribe(_ => {
				SampleLabel.Value += "B";
			});
		}
	}
}
