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
	/// Interaction logic for AllRecipes.xaml
	/// </summary>
	public partial class LemonChickenDesc : UserControl
	{
		public Stack<object> backStack = new Stack<object>();

		/// public LemonChickenDesc _lemonChickenDesc = new LemonChickenDesc();

		public object CurrentUserControl { get; set; }

		MainWindow window;
		public LemonChickenDesc()
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
			};
		}

        private void BackClick(object sender, RoutedEventArgs e)
        {
            if (window.backStack.Peek() is HomePage)
            {
                window.expanderInvisible();
            }
            window.CurrentUserControl = window.backStack.Pop();
            window._Navigation.Navigate(window.CurrentUserControl);
        }
        private void favClick(object sender, RoutedEventArgs e)
        {
            Image img = favButton.Content as Image;
            BitmapImage BitImg = new BitmapImage(new Uri("/images/buttons/star2fav.png", UriKind.Relative));
            img.Source = BitImg;
            favButton.Content = img;

            window.favouritesStack.Push("lemon chicken");
            for (int i = 0; i < window._recipesArray.GetLength(0); i++)
            {

                if (window._recipesArray[i,0].ToString().ToLower().Equals("lemon chicken"))
                {

                    window._recipesArray[i, 3] = this;
                    break;


                }
            }
        }

        private void IngredClick(object sender, RoutedEventArgs e)
        {
            window.backStack.Push(this);
            window._Navigation.Navigate(window._meatIngr);
        }
    }
}