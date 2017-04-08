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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Horizontal_Prototype_March_4
{

	/// <summary>
	/// Interaction logic for AllRecipes.xaml
	/// </summary>
	public partial class AllRecipes : UserControl
    {

		MainWindow window;
        public AllRecipes()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
                window.changeWidth();
                window._HomeButton.Background = Brushes.BurlyWood;
                window._SearchButton.Background = Brushes.BurlyWood;
                window._FavouritesButton.Background = Brushes.BurlyWood;
                window._SettingsButton.Background = Brushes.BurlyWood;
            };

        }
        public void ClearBox(object sender, RoutedEventArgs e)
        {
            _searchboxAR.Text = "";
        }
        public void Filter(object sender, RoutedEventArgs e)
        {
			Boolean expand = false;
			try { expand = window._ExpanderButton.IsExpanded; } catch (Exception) { };
			_RecipesWrapPanel.Children.Clear();
			Stack<string> searchStack = new Stack<string>();
            
            string _searchTerm = _searchboxAR.Text.ToLower();
			

			for (int i = 0; i < window._recipesArray.GetLength(0); i++)
            {
                string recipe_name = window._recipesArray[i, 0].ToString().ToLower();
                if (recipe_name.Contains(_searchTerm))
                {
                    searchStack.Push(window._recipesArray[i, 0].ToString());
                    searchStack.Push(window._recipesArray[i, 1].ToString());
                    searchStack.Push(window._recipesArray[i, 2].ToString());
                    searchStack.Push("*");
                }
            }
            while (!(searchStack.Count == 0))
            {
                _scrollerAR.Visibility = Visibility.Visible;
                string temp = searchStack.Pop();
                if (!(temp == "*"))
                {

                }
                else
                {
					Image Img = new Image();
					BitmapImage BitImg = new BitmapImage(new Uri(searchStack.Pop(), UriKind.Relative));
					Img.Source = BitImg;

					if (expand)
					{
						searchStack.Pop();
						TextBlock text = new TextBlock();
						text.Text = searchStack.Pop();
						text.FontSize = 16;
						text.TextAlignment = System.Windows.TextAlignment.Center;
						text.FontFamily = new FontFamily("Tw Cen MT Condensed Extra Bold");
						text.TextWrapping = TextWrapping.Wrap;

						StackPanel sp = new StackPanel();
						sp.Children.Add(Img);
						sp.Children.Add(text);
						Button button = new Button();
						button.Height = 127;
						button.Width = 130;
						text.Width = button.Width - 10;
						button.Content = sp;
						button.Tag = text.Text;
						button.Background = Brushes.BurlyWood;
						button.Click += new RoutedEventHandler(ButtonClick);
						_RecipesWrapPanel.Children.Add(button);
					}
					else
					{
						searchStack.Pop();
						TextBlock text = new TextBlock();
						text.Text = searchStack.Pop();
						text.FontSize = 14;
						text.TextAlignment = System.Windows.TextAlignment.Center;
						text.FontFamily = new FontFamily("Tw Cen MT Condensed Extra Bold");
						text.TextWrapping = TextWrapping.Wrap;

						StackPanel sp = new StackPanel();
						sp.Children.Add(Img);
						sp.Children.Add(text);
						Button button = new Button();
						button.Height = 127;
						button.Width = 100;
						text.Width = button.Width - 10;
						button.Content = sp;
						button.Tag = text.Text;
						button.Background = Brushes.BurlyWood;
						button.Click += new RoutedEventHandler(ButtonClick);
						_RecipesWrapPanel.Children.Add(button);
					}
				}
            }
            int j = 0;
            foreach (Button child in _RecipesWrapPanel.Children)
            {
                j++;
            }

            if (j == 0)
            {
                _scrollerAR.Visibility = Visibility.Visible;

                TextBlock none = new TextBlock();
                none.Text = "No Results Found, please check spelling and search again";
                none.FontFamily = new FontFamily("Tw Cen MT Condensed Extra Bold");
                none.Width = 320;
                none.Height = 200;
                none.FontSize = 20;
                none.TextAlignment = System.Windows.TextAlignment.Center;
                none.TextWrapping = TextWrapping.Wrap;

                StackPanel sp = new StackPanel();
                sp.Children.Add(none);

                _RecipesWrapPanel.Children.Add(sp);

            }
            searchStack.Clear();
        }
        public void initValues(object[,] _recipesArray)
        {
			_RecipesWrapPanel.Children.Clear();
			Boolean expand = false;
			try {expand = window.isExpanded; } catch (Exception) { };
            Stack<string> searchStack = new Stack<string>();
            int end = _recipesArray.GetLength(0);
            for (int i = 0; i < end; i++)
            {
                searchStack.Push(_recipesArray[i, 0].ToString());
                searchStack.Push(_recipesArray[i, 1].ToString());
                searchStack.Push(_recipesArray[i, 2].ToString());
                searchStack.Push("*");
            }
			
            while (!(searchStack.Count == 0))
            {
                _scrollerAR.Visibility = Visibility.Visible;
                string temp = searchStack.Pop();
                if (!(temp == "*"))
                {

                }
                else
                {

                    Image Img = new Image();
                    BitmapImage BitImg = new BitmapImage(new Uri(searchStack.Pop(), UriKind.Relative));
                    Img.Source = BitImg;
					

					
					searchStack.Pop();
					TextBlock text = new TextBlock();
					text.Text = searchStack.Pop();
					text.FontSize = 14;
					text.TextAlignment = System.Windows.TextAlignment.Center;
					text.FontFamily = new FontFamily("Tw Cen MT Condensed Extra Bold");
					text.TextWrapping = TextWrapping.Wrap;

					StackPanel sp = new StackPanel();
					sp.Children.Add(Img);
					sp.Children.Add(text);
					Button button = new Button();
					button.Height = 127;
					button.Width = 100;
					text.Width = button.Width - 10;
					button.Content = sp;
					button.Tag = text.Text;
					button.Background = Brushes.BurlyWood;
                    
	
					
					button.Click += new RoutedEventHandler(ButtonClick);
					
					_RecipesWrapPanel.Children.Add(button);
					
                }
				
            }
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            if (window.backStack.Peek() is HomePage)
            {
				window.OpenExpanded();
				window.expanderInvisible();
				
            }
            if (window.backStack.Peek() is favourites)
            {
                window._favourites.initValues(window._recipesArray, window.favouritesList);
            }
            window.CurrentUserControl = window.backStack.Pop();
            window._Navigation.Navigate(window.CurrentUserControl);
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {

            window.backStack.Push(this);
            
            Button but = sender as Button;

            for (int i = 0; i < window._recipesArray.GetLength(0); i++)
            {

                if (but.Tag.ToString().ToLower().Equals(window._recipesArray[i, 0].ToString().ToLower()))
                {
                    window.CurrentUserControl = window._recipesArray[i, 3];
                    window.changeWidth();
                    window._Navigation.Navigate(window._recipesArray[i, 3]);
                    break;
                }
            }
        }
    }
}
