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
                window.OpenExpanded(); //if this doesn't opened as expanded it messes with futher program use
                                       // window._ExpanderButton.Expanded = Expander.Collap
            };

		}
        private void favClick(object sender, RoutedEventArgs e)
        {

            StrawberrySouffleDesc md = window._strawDesc;
            if (!md.favFlag)
            {
                Image img = md.favButton.Content as Image;
                BitmapImage BitImg = new BitmapImage(new Uri("/images/buttons/star2fav.png", UriKind.Relative));
                img.Source = BitImg;
                md.favButton.Content = img;

                md.favFlag = true;
                Image img2 = md.favButton.Content as Image;


                favButton.Content = img2;
				if (!window.favouritesList.Contains("strawberry souffle"))
				{
					window.favouritesList.Add("strawberry souffle");

				}
			}

            else
            {
                Image img = md.favButton.Content as Image;
                BitmapImage BitImg = new BitmapImage(new Uri("/images/buttons/star2.png", UriKind.Relative));
                img.Source = BitImg;
                md.favButton.Content = img;

                md.favFlag = false;
                Image img2 = md.favButton.Content as Image;


                favButton.Content = img2;
                window.favouritesList.Remove("strawberry souffle");
            }

            for (int i = 0; i < window._recipesArray.GetLength(0); i++)
            {

                if (window._recipesArray[i, 0].ToString().ToLower().Equals("strawberry souffle"))
                {

                    window._recipesArray[i, 3] = md;
                    break;


                }
            }
			window._souffleComp = this;


        }


        private void BackClicked(object sender, RoutedEventArgs e)
		{
			if (window.backStack.Peek() is HomePage)
			{
				window.expanderInvisible();
			}
			if (window.backStack.Peek() is favourites)
			{
				window._favourites.initValues(window._recipesArray, window.favouritesList);
			}
            window.CurrentUserControl = window._souffleStep3;
			window._Navigation.Navigate(window._souffleStep3);
			window.changeWidth();
			window.expanderVisible();
			if (window.isExpanded == false)
			{
				window.OpenCollapsed();
			}
		}

		private void DoneClicked(object sender, RoutedEventArgs e)
		{
			
			window.OpenExpanded();
			window.CurrentUserControl = window._homePage;
            window.expanderInvisible();
			window._Navigation.Navigate(window._homePage);

		}
	}
}
