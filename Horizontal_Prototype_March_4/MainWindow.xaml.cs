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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Stack<object> backStack = new Stack<object>();
        public List<string> favouritesList = new List<string>();

        public object[,] _recipesArray = new object[,] {   { "Italian Delux Pizza", "peperoni ham hamburger flour salt", "images/food/delux_pizza.jpg", new LemonChickenDesc() },
                                                           { "Vegan Stirfry", "green pepper beef cabage yam brocolli soy sauce", "images/food/gluten_free_stirfry.jpeg", new LemonChickenDesc() },
                                                           {"Honeysmoked Ham", "ham honey brown sugar salt" , "images/food/honeysmoked_ham.jpeg", new LemonChickenDesc() },
                                                           {"Homestyle Spaghetti", "spaghetti beef pepper marianara tomato paste" , "images/food/italian_spaghetti.jpg", new LemonChickenDesc() },
                                                           {"Tofu Burger", "tofu pepper salt bun lettuce tomato green pepper" , "images/food/tofu_burger.jpeg", new LemonChickenDesc() },
                                                           {"Cake", "flour salt milk eggs sugar icing sugar", "images/food/cake.jpeg", new LemonChickenDesc() },
                                                           {"Rosemary Fries", "french fries salt rosemary", "images/food/Rosemary_fry.jpeg", new LemonChickenDesc()},
                                                           {"Vegetarian Pasta", "broccoli celery salt pepper carrots", "images/food/veg_pasta.jpeg", new LemonChickenDesc() },
                                                           {"Vegtable Salad", "Spinach italian dressing peppers raisons ", "images/food/veg_salad.jpg", new LemonChickenDesc() },
                                                           { "Lemon Chicken" ,"chicken lemon lime pepper salt", "images/food/chicken.jpeg", new LemonChickenDesc() },
                                                           {"Meatloaf", "Beef pepper curry salt chilli onion", "images/food/Meatloaf-121.jpg", new MeatDesc() },
                                                           {"Strawberry Souffle", "icing sugar strawberry dessert", "images/food/straw_sou.jpg", new StrawberrySouffleDesc() } };
        public favourites _favourites = new favourites();
        public Search _search = new Search();

        public AllRecipes _allRecipes = new AllRecipes();
        public categories _categories = new categories();
		public Beat_Definition _beatDefinition = new Beat_Definition();
        public MeatIngr _meatIngr = new MeatIngr();
		public MeatDesc _meatDesc = new MeatDesc();
        public Popular _popular = new Popular();
        public StrawberrySouffleIngr _strawIngr = new StrawberrySouffleIngr();
		public StrawberrySouffleDesc _strawDesc = new StrawberrySouffleDesc();

        public Settings _settings = new Settings();

        public HomePage _homePage = new HomePage();
		public Souffle_Step1 _souffleStep1 = new Souffle_Step1();
		public Souffle_Step2 _souffleStep2 = new Souffle_Step2();
		public Souffle_Step3 _souffleStep3 = new Souffle_Step3();
		public Souffle_Complete _souffleComp = new Souffle_Complete();
		public LemonIngred _lemonIngr = new LemonIngred();
		public LemonChickenDesc _lemonDesc = new LemonChickenDesc();
		public Lemon_Step1 _lemonStep1 = new Lemon_Step1();
		public Lemon_Step2 _lemonStep2 = new Lemon_Step2();
		public Lemon_Step3 _lemonStep3 = new Lemon_Step3();
		public Lemon_Complete _lemonComp = new Lemon_Complete();

		public Meat_Step1 _meatStep1 = new Meat_Step1();
		public Meat_Step2 _meatStep2 = new Meat_Step2();
		public Meat_Step3 _meatStep3 = new Meat_Step3();
		public Meat_Step4 _meatStep4 = new Meat_Step4();
		public Meat_Complete _meatComp = new Meat_Complete();

		public Chopped_Definition _choppedDefinition = new Chopped_Definition();
		public Boolean isExpanded = true;

        public object CurrentUserControl { get; set; }


        
		
        public MainWindow()
        {
            InitializeComponent();
            _Navigation.Navigate(_homePage);
            CurrentUserControl = _homePage;
			_strawIngr.initVals();
            
        }
		public StrawberrySouffleIngr getStrawIngr()
		{
			return _strawIngr;
		}


        private void HomeClick(object sender, RoutedEventArgs e)
        {
            expanderInvisible();
            _Navigation.Navigate(_homePage);
            backStack.Push(CurrentUserControl);
            CurrentUserControl = _homePage;
        }
        public void SearchClick(object sender, RoutedEventArgs e)
        {
            expanderVisible();
            _Navigation.Navigate(_search);
            backStack.Push(CurrentUserControl);
            CurrentUserControl = _search;
            OpenExpanded();

        }

        public void FavouritesClick(object sender, RoutedEventArgs e)
        {
            expanderVisible();
            _favourites.initValues(_recipesArray, favouritesList);
            _Navigation.Navigate(_favourites);
            backStack.Push(CurrentUserControl);
            CurrentUserControl = _favourites;
            OpenExpanded();
        }

        public void SettingsClick(object sender, RoutedEventArgs e)
        {
            expanderVisible();
            _Navigation.Navigate(_settings);
            backStack.Push(CurrentUserControl);
            CurrentUserControl = _settings;
            OpenExpanded();
        }
     
        public void OpenCollapsed()
        {
            // this._ExpanderButton.IsExpanded = true;
            Expanded(null, null);
            _ExpanderButton.IsExpanded = true;



        }
        public void OpenExpanded()
        {
            // this._ExpanderButton.IsExpanded = true;
            Collapsed(null, null);
            _ExpanderButton.IsExpanded = false;


        }
        private void Collapsed(object sender, RoutedEventArgs e)
        {
            isExpanded = true;
            _HomeDP.Width = 95;
            _SeachDP.Width = 95;
            _FavouritesDP.Width = 95;
            _SettingsDP.Width = 95;
            _Sidebar.Width = 120;
            _BorderDP.Width = 120;
            _pagestack.Width = 462;
            _pagestack.Margin = new Thickness(32, 0, 0, 0);
            _ExpanderDP.Margin = new Thickness(91, -256, 0, 230);
            changeWidth();

        }
        private void Expanded(object sender, RoutedEventArgs e)
        {
            isExpanded = false;
            _HomeDP.Width = 0;
            _SeachDP.Width = 0;
            _FavouritesDP.Width = 0;
            _SettingsDP.Width = 0;
            _Sidebar.Width = 24;
            _BorderDP.Width = 30;
            _pagestack.Width = 462;
            _pagestack.Margin = new Thickness(28, 0, 0, 0);
            _ExpanderDP.Margin = new Thickness(0, -256, 0, 230);

            changeWidth();

        }

        public void expanderInvisible()
        {
            _HomeDP.Width = 120;
            _HomeButton.Width = 120;

            _SeachDP.Width = 120;
            _SearchButton.Width = 120;

            _FavouritesDP.Width = 120;
            _FavouritesButton.Width = 120;

            _SettingsDP.Width = 120;
            _SettingsButton.Width = 120;

            _ExpanderButton.Visibility = Visibility.Hidden;
            _Sidebar.Width = 120;
            _BorderDP.Width = 120;

        }

        public void expanderVisible()
        {
            _HomeDP.Width = 95;
            _HomeButton.Width = 95;

            _SeachDP.Width = 95;
            _SearchButton.Width = 95;

            _FavouritesDP.Width = 95;
            _FavouritesButton.Width = 95;

            _SettingsDP.Width = 95;
            _SettingsButton.Width = 95;

            _ExpanderButton.Visibility = Visibility.Visible;
            _Sidebar.Width = 120;
            _BorderDP.Width = 120;
        }

        public void changeWidth()
        {
            if (CurrentUserControl is favourites)
            {
                if (!isExpanded)
                {
                    _favourites._favourites_Grid.Width = 470;
					_favourites._FavsWrapPanel.Width = 430;
                    foreach (Button child in _favourites._FavsWrapPanel.Children)
                        if (child.Width > 110)
                        {
                            break;
                        }
                        else
                        {
                            incButtonSize(_favourites._FavsWrapPanel);
                            break;
                        }
                    
                    
                }
                else
                {
                    _favourites._favourites_Grid.Width = 372;
					_favourites._FavsWrapPanel.Width = 332;
					decButtonSize(_favourites._FavsWrapPanel);

				}
            }

            else if (CurrentUserControl is Search)
            {
                if (!isExpanded)
                {
                    _search._search_Grid.Width = 470;
					_search._SearchRecipesWrapPanel.Width = 430;
                    _search._searchWP.Margin = new Thickness(60, 160, 0, 345);
                    _search.search_instructions.Margin = new Thickness(94, 177, 84, 0);


                    foreach (Button child in _search._SearchRecipesWrapPanel.Children)
                        if (child.Width > 110)
                        {
                            break;
                        }
                        else
                        {
                            incButtonSize(_search._SearchRecipesWrapPanel);
                            break;
                        }
                }
                else
                {
                    _search._search_Grid.Width = 372;
					_search._SearchRecipesWrapPanel.Width = 340;
                    _search._searchWP.Margin = new Thickness(20, 160, 0, 345);
                    _search.search_instructions.Margin = new Thickness(54, 177, 84, 0);
                    decButtonSize(_search._SearchRecipesWrapPanel);
                   

				}
            }

            else if (CurrentUserControl is AllRecipes)
            {
				if (!isExpanded)
				{
					_allRecipes._allRecipes_Grid.Width = 470;
					_allRecipes._RecipesWrapPanel.Width = 430;
					
                    foreach (Button child in _allRecipes._RecipesWrapPanel.Children)
                        if (child.Width > 110)
                        {
                            break;
                        }
                        else
                        {
                            incButtonSize(_allRecipes._RecipesWrapPanel);
                            break;
                        }


                }
				else
				{
					_allRecipes._allRecipes_Grid.Width = 372;
					_allRecipes._RecipesWrapPanel.Width = 332;
					decButtonSize(_allRecipes._RecipesWrapPanel);

				}
            }

            else if (CurrentUserControl is categories)
            {
                if (!isExpanded)
                {
                    _categories._categories_Grid.Width = 470;
                    _categories._CategoriesWrapPanel.Width = 430;
					
                    foreach (Button child in _categories._CategoriesWrapPanel.Children)
                        if (child.Width > 110)
                        {
                            break;
                        }
                        else
                        {
                            incButtonSize(_categories._CategoriesWrapPanel);
                            break;
                        }


                }
                else
                {
                    _categories._categories_Grid.Width = 372;
                    _categories._CategoriesWrapPanel.Width = 332;
					decButtonSize(_categories._CategoriesWrapPanel);
				}

            }

           
            else if (CurrentUserControl is MeatDesc)
            {
				if(!isExpanded)
				{
					MeatDesc md = CurrentUserControl as MeatDesc;
					md._meatGrid.Width = 470;
                    md._ingredMeat.Margin = new Thickness(50, 266, 162, 120);
                    md.meat_desc_inrec.Margin = new Thickness(270, 280, 0, 120);
                    md.meat_desc_inrec.Width = 165;
                    md.meat_desc_inrec.FontSize = 16;
                    md.meat.Width = 216;
                }
				else
				{
                    MeatDesc md = CurrentUserControl as MeatDesc;
                    md._meatGrid.Width = 372;
                    md._ingredMeat.Margin = new Thickness(118, 266, 54, 120);
                    md.meat_desc_inrec.Margin = new Thickness(118, 218, 0, 272);
                    md.meat_desc_inrec.Width = 155;
                    md.meat_desc_inrec.FontSize = 12;
                    md.meat.Width = 161;
                }

            }
            else if (CurrentUserControl is MeatIngr)
            {
                if (!isExpanded)
                {
                    _meatIngr._meatIngr_Grid.Width = 470;
                }
                else
                {
                    _meatIngr._meatIngr_Grid.Width = 372;
                }
            }

			else if (CurrentUserControl is LemonChickenDesc)
			{
				if (!isExpanded)
				{
					LemonChickenDesc lcd = CurrentUserControl as LemonChickenDesc;
					lcd._lemonChickenGrid.Width = 470;
					lcd._ingredList.Margin = new Thickness(50, 266, 162, 120);
					lcd.chick_desc.Margin = new Thickness(270, 280, 0, 120);
					lcd.chick_desc.Width = 165;
					lcd.chick_desc.FontSize = 16;
				//	lcd.chicken.Width = 210;

				}
				else
				{
					LemonChickenDesc lcd = CurrentUserControl as LemonChickenDesc;
					lcd._lemonChickenGrid.Width = 372;

					lcd._ingredList.Margin = new Thickness(118, 266, 54, 120);
					lcd.chick_desc.Margin = new Thickness(137, 196, 0, 278);
					lcd.chick_desc.Width = 155;
					lcd.chick_desc.FontSize = 12;
					lcd.chicken.Width = 155;


				}
			}

			else if (CurrentUserControl is StrawberrySouffleDesc)
            {
                if (!isExpanded)
                {
                    StrawberrySouffleDesc ssd = CurrentUserControl as StrawberrySouffleDesc;
                    ssd._strawSouffleGrid.Width = 470;
                    ssd.straw_sou.Width = 210;
                    ssd._ingred.Margin = new Thickness(50, 266, 162, 120);
                    ssd.straw_desc_ingr.Margin = new Thickness(270, 280, 0, 120);
                    ssd.straw_desc_ingr.Width = 165;
                    ssd.straw_desc_ingr.FontSize = 16;
                    
                }
                else
                {
                    StrawberrySouffleDesc ssd = CurrentUserControl as StrawberrySouffleDesc;
                    ssd._strawSouffleGrid.Width = 372;
                    ssd.straw_sou.Width = 155;
                    ssd._ingred.Margin = new Thickness(118, 266, 54, 120);
                    ssd.straw_desc_ingr.Margin = new Thickness(137, 196, 0, 278);
                    ssd.straw_desc_ingr.Width = 155;
                    ssd.straw_desc_ingr.FontSize = 12;
                    

                }
            }

			
			else if (CurrentUserControl is StrawberrySouffleIngr)
            {
                if (!isExpanded)
                {
                    _strawIngr._strawIngr_Grid.Width = 470;
                }
                else
                {
                    _strawIngr._strawIngr_Grid.Width = 372;
                }
            }

			else if (CurrentUserControl is LemonIngred)
			{
				if (!isExpanded)
				{
					_lemonIngr._lemonIngr_Grid.Width = 470;
				}
				else
				{
					_lemonIngr._lemonIngr_Grid.Width = 372;
				}
			}

			else if (CurrentUserControl is Souffle_Complete)
			{
				if (!isExpanded)
				{
					_souffleComp._souffleCompGrid.Width = 470;
				}
				else
				{
					_souffleComp._souffleCompGrid.Width = 372;
				}
			}

			else if (CurrentUserControl is Lemon_Complete)
			{
				if (!isExpanded)
				{
					_lemonComp._lemonCompleteGrid.Width = 470;
				}
				else
				{
					_lemonComp._lemonCompleteGrid.Width = 372;
				}

			}


            else if (CurrentUserControl is Popular)
            {
                if (!isExpanded)
                {
                    _popular._popular_Grid.Width = 470;
                    _popular._PopularWrapPanel.Width = 430;
                    foreach (Button child in _popular._PopularWrapPanel.Children)
                        if (child.Width > 110) {
                            break;
                        }
                        else { 
                        incButtonSize(_popular._PopularWrapPanel);
                            break;
                        }

				}
                else
                {
                    _popular._popular_Grid.Width = 372;
                    _popular._PopularWrapPanel.Width = 332;
					decButtonSize(_popular._PopularWrapPanel);
				}
            }
            else if (CurrentUserControl is Settings)
            {
                if (!isExpanded)
                {
                    _settings._settings_Grid.Width = 470;
                    
                }
                else
                {
                    _settings._settings_Grid.Width = 372;
                    //_popular._PopularWrapPanel.Width = 330;
                }
            }

            else if (CurrentUserControl is Meat_Step1)
            {
                if (!isExpanded)
                {
                    _meatStep1.Meat_Step1Grid.Width = 470;
					_meatStep1.BackButton.Visibility = Visibility.Visible;
				}

                else
                {

                    _meatStep1.BackButton.Visibility = Visibility.Hidden;
                }
            }

			else if (CurrentUserControl is Souffle_Step1)
			{
				if (!isExpanded)
				{
					_souffleStep1.Souffle_Step1Grid.Width = 470;
					_souffleStep1.BackButton.Visibility = Visibility.Visible;
				}
				else
				{
					_souffleStep1.BackButton.Visibility = Visibility.Hidden;
				}
			}

			else if (CurrentUserControl is Souffle_Step2)
			{
				if (!isExpanded)
				{
					_souffleStep2.Souffle_Step2Grid.Width = 470;
					_souffleStep2.BackButton.Visibility = Visibility.Visible;
				}
				else
				{
					_souffleStep2.BackButton.Visibility = Visibility.Hidden;
				}
			}

			else if (CurrentUserControl is Souffle_Step3)
			{
				if (!isExpanded)
				{
					_souffleStep3.Souffle_Step3Grid.Width = 470;
					_souffleStep3.BackButton.Visibility = Visibility.Visible;
				}
				else
				{
					_souffleStep3.BackButton.Visibility = Visibility.Hidden;
				}
			}

			else if (CurrentUserControl is Lemon_Step1)
			{
				if (!isExpanded)
				{
					_lemonStep1.Lemon_Step1Grid.Width = 470;
					_lemonStep1.BackButton.Visibility = Visibility.Visible;
				}
				else
				{
					_souffleStep1.BackButton.Visibility = Visibility.Hidden;
				}
			}

			else if (CurrentUserControl is Lemon_Step2)
			{
				if (!isExpanded)
				{
					_lemonStep2.Lemon_Step2Grid.Width = 470;
					_lemonStep2.BackButton.Visibility = Visibility.Visible;
				}
				else
				{
					_lemonStep2.BackButton.Visibility = Visibility.Hidden;
				}
			}

			else if (CurrentUserControl is Lemon_Step3)
			{
				if (!isExpanded)
				{
					_lemonStep3.Lemon_Step3Grid.Width = 470;
					_lemonStep3.BackButton.Visibility = Visibility.Visible;
				}
				else
				{
					_lemonStep3.BackButton.Visibility = Visibility.Hidden;
				}
			}

		}

		public void decButtonSize(WrapPanel wp)
		{
			
			foreach (Button child in wp.Children)
			{
				if (child.Width <= 100)
				{
					break;
				}
				child.Width = child.Width - 30;
				StackPanel sp = child.Content as StackPanel;
				
				foreach (object spChild in sp.Children)
				{
					if (spChild is Image)
					{
						Image img = spChild as Image;
						img.Width = child.Width - 10;

					}
					else if (spChild is TextBlock)
					{
						TextBlock text = spChild as TextBlock;
						text.FontSize -= 2;
					}
				}

			}
		}

		public void incButtonSize(WrapPanel wp)
		{
			foreach (Button child in wp.Children)
			{

				child.Width = child.Width + 30;
				StackPanel sp = child.Content as StackPanel;
				
				
				foreach (object spChild in sp.Children)
				{
					if (spChild is Image)
					{
						Image img = spChild as Image;
						img.Width += 30;
						BitmapImage btmi = img.Source as BitmapImage;
						

					}
				
				if (spChild is TextBlock)
					{
						TextBlock text = spChild as TextBlock;
						text.FontSize += 2;
					}
				}

			}
		}


    }
}
