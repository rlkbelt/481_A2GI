using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Horizontal_Prototype_March_4
{
	/// <summary>
	/// Interaction logic for PrintDialog.xaml
	/// </summary>
	public partial class PrintDialog : Window
	{
		public PrintDialog()
		{
			InitializeComponent();
			

		}

		public void update()
		{
			while (_progress.Value != 100)
			{
				System.Threading.Thread.Sleep(100);
				_progress.Value++;
			}
			Close();
			// Status.Text = "Printing Complete";

		}
		private delegate void UpdateProgressBarDelegate(
		System.Windows.DependencyProperty dp, Object value);


		public void Process()
		{
			//Configure the ProgressBar
			_progress.Minimum = 0;
			_progress.Maximum = short.MaxValue;
			_progress.Value = 0;

			//Stores the value of the ProgressBar
			double value = 0;

			//Create a new instance of our ProgressBar Delegate that points
			// to the ProgressBar's SetValue method.
			UpdateProgressBarDelegate updatePbDelegate =
				new UpdateProgressBarDelegate(_progress.SetValue);

			//Tight Loop: Loop until the ProgressBar.Value reaches the max
			do
			{
				value += 2;
				percent.Text = (int)(_progress.Value/326.27) + "%";


				/*Update the Value of the ProgressBar:
					1) Pass the "updatePbDelegate" delegate
					   that points to the ProgressBar1.SetValue method
					2) Set the DispatcherPriority to "Background"
					3) Pass an Object() Array containing the property
					   to update (ProgressBar.ValueProperty) and the new value */
				Dispatcher.Invoke(updatePbDelegate,
					System.Windows.Threading.DispatcherPriority.Background,
					new object[] { ProgressBar.ValueProperty, value });
			}
			while (_progress.Value != _progress.Maximum);
			
			System.Threading.Thread.Sleep(1000);
			Close();
		}

		private void Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
