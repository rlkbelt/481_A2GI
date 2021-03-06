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
    /// Interaction logic for Search.xaml
    /// </summary>
    
    public partial class Search : UserControl
    {
        
        MainWindow window;
        
        
        public Search()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
                window._HomeButton.Background = Brushes.BurlyWood;
                window._SearchButton.Background = Brushes.SaddleBrown;
                window._FavouritesButton.Background = Brushes.BurlyWood;
                window._SettingsButton.Background = Brushes.BurlyWood;
            };
        }

        public void Search_Click(object sender, RoutedEventArgs e)
        {
            _searchBar.Text = "";
        }
        public void Search_Text_Click (object sender, RoutedEventArgs e)
        {
            _SearchRecipesWrapPanel.Children.Clear();
            Stack<string> searchStack = new Stack<string>();
            string _searchTerm = _searchBar.Text.ToLower();

            for (int i = 0; i < window._recipesArray.GetLength(0); i++)
            {
                string recipe_name = window._recipesArray[i, 0].ToString().ToLower();
                string recipe_keywords = window._recipesArray[i, 1].ToString().ToLower();
                string recipe_imageSource = window._recipesArray[i, 2].ToString().ToLower();
                if (recipe_name.Contains(_searchTerm) || recipe_keywords.Contains(_searchTerm))
                {
                    
                    searchStack.Push(window._recipesArray[i, 0].ToString());
                    searchStack.Push(window._recipesArray[i, 1].ToString());
                    searchStack.Push(window._recipesArray[i, 2].ToString());
                    searchStack.Push("*");
                    

                }
            }

            while (!(searchStack.Count == 0))
            {
                _scroller.Visibility = Visibility.Visible;
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
                    _SearchRecipesWrapPanel.Children.Add(button);
                }
                
            }
            int j = 0;
            foreach(Button child in _SearchRecipesWrapPanel.Children)
            {
                j++;
            }
            
            if (j == 0)
            {
                _scroller.Visibility = Visibility.Visible;

                TextBlock none = new TextBlock();
                none.Text = "No Results Found, please check spelling and search again";
                none.FontFamily = new FontFamily("Tw Cen MT Condensed Extra Bold");
                none.Width = 335;
                none.Height = 200;
                none.FontSize = 20;
                none.TextAlignment = System.Windows.TextAlignment.Center;
                none.TextWrapping = TextWrapping.Wrap;

                StackPanel sp = new StackPanel();
                sp.Children.Add(none);

                _SearchRecipesWrapPanel.Children.Add(sp);

            }

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

        public void Back_Click (object sender, RoutedEventArgs e)
        {
            if(window.backStack.Peek() is HomePage)
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

		private void _searchBar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				Search_Text_Click(this, new RoutedEventArgs());
			}
		}
	}

}
