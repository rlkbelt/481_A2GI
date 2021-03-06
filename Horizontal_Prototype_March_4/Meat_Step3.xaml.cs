﻿

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
	/// Interaction logic for Souffle_Step1.xaml
	/// </summary>
	public partial class Meat_Step3 : UserControl
	{
		MainWindow window;

		public Meat_Step3()
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
				window.OpenCollapsed();
                meat_step3wrap.Children.Clear();
                string[] ingredString = { window._meatIngr.meat_ingr6.Text, window._meatIngr.meat_ingr8.Text, window._meatIngr.meat_ingr9.Text };
                string[] quantities = { window._meatIngr.meat_quan1.Text, window._meatIngr.meat_quan8.Text, window._meatIngr.meat_quan9.Text };
                window.populateStep(quantities, ingredString, meat_step3wrap);

                // window._ExpanderButton.Expanded = Expander.Collap

            };


		}

		private void BackClicked(object sender, RoutedEventArgs e)
		{
			window.CurrentUserControl = window._meatStep2;
			window._Navigation.Navigate(window._meatStep2);
		}
		private void NextClicked(object sender, RoutedEventArgs e)
		{

			window.CurrentUserControl = window._meatStep4;
			window._Navigation.Navigate(window._meatStep4);
		}

		private void backToDesc_Click(object sender, RoutedEventArgs e)
		{

            window.backStack.Pop();
            window.CurrentUserControl = window._recipesArray[10,3];
			window._Navigation.Navigate(window.CurrentUserControl);
            window.OpenExpanded();
        }
	
	}
}