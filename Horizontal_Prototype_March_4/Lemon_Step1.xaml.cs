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
	/// Interaction logic for Lemon_Step1.xaml
	/// </summary>
	public partial class Lemon_Step1 : UserControl
	{
		MainWindow window;

		public Lemon_Step1()
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
				window.OpenCollapsed();
                window._HomeButton.Background = Brushes.BurlyWood;
                window._SearchButton.Background = Brushes.BurlyWood;
                window._FavouritesButton.Background = Brushes.BurlyWood;
                window._SettingsButton.Background = Brushes.BurlyWood;
                lemon_step1wrap.Children.Clear();
                string[] ingredString = { window._lemonIngr.lemon_ingr1.Text };
                string[] quantities = { window._lemonIngr.lemon_quan1.Text };
                window.populateStep(quantities, ingredString, lemon_step1wrap);
            };


		}

		private void BackClicked(object sender, RoutedEventArgs e)
		{
            LemonChickenDesc lcd =  window._recipesArray[9, 3] as LemonChickenDesc;
            if (window.backStack.Peek() is LemonChickenDesc && lcd.lemonSidebarCollapsed == false)
            {
                window.OpenExpanded();
                window.isExpanded = true;
            }
            else if (window.backStack.Peek() is LemonIngred && window._lemonIngr.lemonIngrCollapsed == false)
            {
                window.OpenExpanded();
                window.isExpanded = true;
            }
            else
            {
                window.isExpanded = false;
                window.OpenCollapsed();
            }
            window.backStack.Pop();

            window.CurrentUserControl = window._recipesArray[9, 3];
            window._Navigation.Navigate(window.CurrentUserControl);
            window.changeWidth();
        }
		private void NextClicked(object sender, RoutedEventArgs e)
		{
			window.CurrentUserControl = window._lemonStep2;
			window._Navigation.Navigate(window._lemonStep2);
		}

		private void backToDesc_Click(object sender, RoutedEventArgs e)
		{
            window.backStack.Pop();
            window.CurrentUserControl = window._recipesArray[9,3];
			window._Navigation.Navigate(window.CurrentUserControl);
            window.OpenExpanded();
        }

	}
}