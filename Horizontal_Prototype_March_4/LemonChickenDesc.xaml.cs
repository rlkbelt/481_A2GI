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
	/// Interaction logic for LemonChickenDesc.xaml
	/// </summary>
	public partial class LemonChickenDesc : UserControl
	{
		public Stack<object> backStack = new Stack<object>();


		public object CurrentUserControl { get; set; }

		MainWindow window;
        public bool favFlag;
        public bool lemonSidebarCollapsed;
        public LemonChickenDesc(bool flag)
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				
				window = Window.GetWindow(this) as MainWindow;
				window.step_expander.Visibility = Visibility.Hidden;
				window._HomeButton.Background = Brushes.BurlyWood;
                window._SearchButton.Background = Brushes.BurlyWood;
                window._FavouritesButton.Background = Brushes.BurlyWood;
                window._SettingsButton.Background = Brushes.BurlyWood;
                lemonSidebarCollapsed = false;
                if (!window.isExpanded)
                {
                    lemonSidebarCollapsed = true;
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
                window._lemonComp.favButton.Content = img;
                window.favouritesList.Add("lemon chicken");



                for (int i = 0; i < window._recipesArray.GetLength(0); i++)
				{

					if (window._recipesArray[i, 0].ToString().ToLower().Equals("lemon chicken"))
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
                window._lemonComp.favButton.Content = img;
                window.favouritesList.Remove("lemon chicken");



                for (int i = 0; i < window._recipesArray.GetLength(0); i++)
				{

					if (window._recipesArray[i, 0].ToString().ToLower().Equals("lemon chicken"))
					{

						window._recipesArray[i, 3] = this;
						break;

					}
				}
			}
            

        }

		private void BeginClick(object sender, RoutedEventArgs e)
		{
			window.backStack.Push(this);
			window.CurrentUserControl = window._lemonStep1;
			window._Navigation.Navigate(window._lemonStep1);
			window.changeWidth();
            if (favFlag)
            {
                window._lemonComp = new Lemon_Complete(true);
            }
            else
            {

                window._lemonComp = new Lemon_Complete(false);

            }
        }

		private void IngredClick(object sender, RoutedEventArgs e)

		{
			window.backStack.Push(this);
			window._Navigation.Navigate(window._lemonIngr);
			window.changeWidth();

			if (window.isExpanded)
			{
				window.OpenExpanded();
			}
		//	window.expanderInvisible();
		}
	}
}
