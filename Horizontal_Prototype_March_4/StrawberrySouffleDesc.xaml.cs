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
	/// Interaction logic for AllRecipes.xaml
	/// </summary>
	public partial class StrawberrySouffleDesc : UserControl
	{
		public Stack<object> backStack = new Stack<object>();


		public object CurrentUserControl { get; set; }

		MainWindow window;
        public bool strawDescSidebarCollapsed;
        public bool favFlag;
        public StrawberrySouffleDesc(bool flag)
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
                window._HomeButton.Background = Brushes.Beige;
                window._SearchButton.Background = Brushes.Beige;
                window._FavouritesButton.Background = Brushes.Beige;
                window._SettingsButton.Background = Brushes.Beige;
                strawDescSidebarCollapsed = false;
                if (!window.isExpanded)
                {
                    strawDescSidebarCollapsed = true;
                }
                
            };
            favFlag = false;
            if (flag)
            {
                favFlag = flag;
                Image img = favButton.Content as Image;
                BitmapImage BitImg = new BitmapImage(new Uri("/images/buttons/star2fav.png", UriKind.Relative));
                img.Source = BitImg;
                favButton.Content = img;

            }
		}

		private void BackClick(object sender, RoutedEventArgs e)
		{
			if (window.backStack.Peek() is HomePage)
			{
				window.expanderInvisible();
			}
			if (window.backStack.Peek() is favourites)
			{
				window._favourites.initValues(window._recipesArray, window.favouritesList);
			}
			window.CurrentUserControl = window.backStack.Pop();
			window._Navigation.Navigate(window.CurrentUserControl);
			window.changeWidth();
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
                window._souffleComp.favButton.Content = img;
                
				if (!window.favouritesList.Contains("strawberry souffle"))
				{
					window.favouritesList.Add("strawberry souffle");

				}


                window._recipesArray[11, 3] = this;
                        

            }
            else
            {
                favFlag = false;
                Image img = favButton.Content as Image;
                BitmapImage BitImg = new BitmapImage(new Uri("/images/buttons/star2.png", UriKind.Relative));
                img.Source = BitImg;
                favButton.Content = img;
                window._souffleComp.favButton.Content = img;
                window.favouritesList.Remove("strawberry souffle");
                window._recipesArray[11, 3] = this;
                        

			}

		}

		private void straw_BeginClick(object sender, RoutedEventArgs e)
		{
			window.backStack.Push(this);

			window.CurrentUserControl = window._souffleStep1;
			window._Navigation.Navigate(window._souffleStep1);
            window.changeWidth();
            string[] ingredString = { window._strawIngr.straw_ingr1.Text, window._strawIngr.straw_ingr2.Text, window._strawIngr.straw_ingr3.Text, window._strawIngr.straw_ingr4.Text, window._strawIngr.straw_ingr5.Text };
            string[] quantities = { window._strawIngr.straw_quan1.Text, window._strawIngr.straw_quan2.Text, window._strawIngr.straw_quan3.Text, window._strawIngr.straw_quan4.Text, window._strawIngr.straw_quan5.Text };
            window.populateStep(quantities, ingredString, window._souffleStep1.straw_step1wrap);
            if (favFlag)
            {
                window._souffleComp = new Souffle_Complete(true);
            }
            else
            {

                window._souffleComp = new Souffle_Complete(false);

            }

        }

		private void straw_IngredClick(object sender, RoutedEventArgs e)

		{
			window.backStack.Push(this);
			window._Navigation.Navigate(window._strawIngr);
 
			window.changeWidth();
			

        }
	}
}
