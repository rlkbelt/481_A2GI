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
	public partial class Meat_Step4 : UserControl
	{
		MainWindow window;

		public Meat_Step4()
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
				window.OpenCollapsed();

				// window._ExpanderButton.Expanded = Expander.Collap

			};

		}

		private void BackClicked(object sender, RoutedEventArgs e)
		{
			window.CurrentUserControl = window._meatStep3;
			window._Navigation.Navigate(window._meatStep3);
		}
		private void NextClicked(object sender, RoutedEventArgs e)
		{
			
			window.CurrentUserControl = window._meatComp;
			window._Navigation.Navigate(window._meatComp);
            MeatDesc md = window._recipesArray[10, 3] as MeatDesc;
            if (md.favFlag)
            {
                window._recipesArray[10, 3] = new MeatDesc(true);
            }
            else
            {
                window._recipesArray[10, 3] = new MeatDesc(false);
            }
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