﻿using System;
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
		public bool favFlag;

		public Souffle_Complete(bool flag)
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
                window.OpenExpanded(); //if this doesn't opened as expanded it messes with futher program use
                                       // window._ExpanderButton.Expanded = Expander.Collap
            };
            favFlag = false;
            if (flag)
            {
                favFlag = flag;
                Image img = new Image();
                BitmapImage BitImg = new BitmapImage(new Uri("/images/buttons/star2fav.png", UriKind.Relative));
                img.Source = BitImg;

                favFlag = true;
                favButton.Content = img;

                favButton.Content = img;

            }

        }
        private void favClick(object sender, RoutedEventArgs e)
        {

            StrawberrySouffleDesc lcd = window._recipesArray[11, 3] as StrawberrySouffleDesc;
            if (!lcd.favFlag)
            {
                Image img = new Image();
                BitmapImage BitImg = new BitmapImage(new Uri("/images/buttons/star2fav.png", UriKind.Relative));
                img.Source = BitImg;

                lcd.favFlag = true;

                favButton.Content = img;
                lcd.favButton.Content = img;
                window.favouritesList.Add("strawberry souffle");
            }

            else
            {
                Image img = new Image();
                BitmapImage BitImg = new BitmapImage(new Uri("/images/buttons/star2.png", UriKind.Relative));
                img.Source = BitImg;
                lcd.favFlag = false;
                favButton.Content = img;
                lcd.favButton.Content = img;
                window.favouritesList.Remove("strawberry souffle");
            }
            window._recipesArray[11, 3] = lcd;
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
