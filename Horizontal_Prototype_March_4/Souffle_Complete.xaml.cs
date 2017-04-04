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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Horizontal_Prototype_March_4
{
	/// <summary>
	/// Interaction logic for Souffle_Step3.xaml
	/// </summary>
	public partial class Souffle_Complete : UserControl
	{
		MainWindow window;
		public Boolean favFlag = false;

		public Souffle_Complete()
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
				window.OpenCollapsed();
				// window._ExpanderButton.Expanded = Expander.Collap
			};

		}
		private void favClick(object sender, RoutedEventArgs e)
		{


			if (!favFlag)
			{
				favFlag = true;
				Image img = favButton.Content as Image;
				BitmapImage BitImg = new BitmapImage(new Uri("/images/buttons/star2fav.png", UriKind.Relative));
				img.Source = BitImg;
				favButton.Content = img;
				window.favouritesList.Add("strawberry souffle");
				for (int i = 0; i < window._recipesArray.GetLength(0); i++)
				{

					if (window._recipesArray[i, 0].ToString().ToLower().Equals("strawberry souffle"))
					{

						window._recipesArray[i, 3] = this;
						break;


					}
				}
			}
			else
			{
				favFlag = false;
				Image img = favButton.Content as Image;
				BitmapImage BitImg = new BitmapImage(new Uri("/images/buttons/star2.png", UriKind.Relative));
				img.Source = BitImg;
				favButton.Content = img;
				window.favouritesList.Remove("strawberry souffle");
				for (int i = 0; i < window._recipesArray.GetLength(0); i++)
				{

					if (window._recipesArray[i, 0].ToString().ToLower().Equals("strawberry souffle"))
					{

						window._recipesArray[i, 3] = this;
						break;

					}
				}
			}

		}

		private void BackClicked(object sender, RoutedEventArgs e)
		{
			window.backStack.Push(this);
			window.CurrentUserControl = window._souffleStep3;
			window._Navigation.Navigate(window._souffleStep3);
		}

		private void DoneClicked(object sender, RoutedEventArgs e)
		{
			window.backStack.Push(this);
			window.CurrentUserControl = window._homePage;
			window._Navigation.Navigate(window._homePage);
		}
	}
}
