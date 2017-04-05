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
	public partial class Souffle_Step1 : UserControl
	{
		MainWindow window;

		public Souffle_Step1()
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
			window.backStack.Push(this);
			window.CurrentUserControl = window._strawDesc;
			window._Navigation.Navigate(window._strawDesc);
		}
		private void NextClicked(object sender, RoutedEventArgs e)
		{
			window.backStack.Push(this);
			window.CurrentUserControl = window._souffleStep2;
			window._Navigation.Navigate(window._souffleStep2);
		}

		private void backToDesc_Click(object sender, RoutedEventArgs e)
		{
			window.backStack.Push(this);
			window.CurrentUserControl = window._strawDesc;
			window._Navigation.Navigate(window._strawDesc);
		}

		private void term_Click(object sender, RoutedEventArgs e)
		{
			window.CurrentUserControl = window._beatDefinition;
			window._Navigation.Navigate(window._beatDefinition);
		}

		public void populateStep()
		{
			string[] ingredString = { "Pureed Strawberries", "Chilled Cream", "Lemon Juice", "Eggs", "Lukewarm Water" };
			TextBox[] arrayTB = new TextBox[ingredString.Length];
			TextBox[] ingredName = new TextBox[ingredString.Length];
            for (int i=0; i < arrayTB.Length; i++)
            {
                arrayTB[i] = new TextBox();
            }
            for (int i = 0; i < ingredName.Length; i++)
            {
                ingredName[i] = new TextBox();
            }


            UserControl1 uc = new UserControl1();
            uc.changeMetrics();

            string[] metric = { uc.straw_quan1, uc.straw_quan2, uc.straw_quan3, uc.straw_quan4, uc.straw_quan5 };
            
			
			
	
		
		
			for (int i = 0; i < ingredString.Length; i++)
			{
                
                arrayTB[i].Text = metric[i];
				arrayTB[i].FontSize = 12;
				arrayTB[i].HorizontalAlignment = HorizontalAlignment.Left;
				arrayTB[i].FontFamily = new FontFamily("Tw Cen MT Condensed Extra Bold");
				arrayTB[i].Height = 22;
				arrayTB[i].TextWrapping = TextWrapping.Wrap;
				arrayTB[i].VerticalAlignment = VerticalAlignment.Top;
				arrayTB[i].Width = 70;
				straw_step1wrap.Children.Add(arrayTB[i]);

				ingredName[i].Text = ingredString[i];
				ingredName[i].FontSize = 12;
				ingredName[i].HorizontalAlignment = HorizontalAlignment.Left;
				ingredName[i].FontFamily = new FontFamily("Tw Cen MT Condensed Extra Bold");
				ingredName[i].Height = 22;
				ingredName[i].TextWrapping = TextWrapping.Wrap;
				ingredName[i].VerticalAlignment = VerticalAlignment.Top;
				ingredName[i].Width = 146;
				straw_step1wrap.Children.Add(ingredName[i]);

			}
			

			

			
		

		}

	}
}
