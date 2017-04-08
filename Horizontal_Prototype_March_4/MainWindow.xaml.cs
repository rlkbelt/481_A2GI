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


        public object[,] _recipesArray = new object[,] {   { "Italian Delux Pizza", "peperoni ham hamburger flour salt", "images/food/delux_pizza.jpg", new ComingSoon() },
                                                           { "Vegan Stirfry", "green pepper beef cabage yam brocolli soy sauce", "images/food/gluten_free_stirfry.jpeg", new ComingSoon() },
                                                           {"Honeysmoked Ham", "ham honey brown sugar salt" , "images/food/honeysmoked_ham.jpeg", new ComingSoon() },
                                                           {"Homestyle Spaghetti", "spaghetti beef pepper marianara tomato paste" , "images/food/italian_spaghetti.jpg", new ComingSoon() },
                                                           {"Tofu Burger", "tofu pepper salt bun lettuce tomato green pepper" , "images/food/tofu_burger.jpeg", new ComingSoon() },
                                                           {"Cake", "flour salt milk eggs sugar icing sugar", "images/food/cake.jpeg", new ComingSoon() },
                                                           {"Rosemary Fries", "french fries salt rosemary", "images/food/Rosemary_fry.jpeg", new ComingSoon()},
                                                           {"Vegetarian Pasta", "broccoli celery salt pepper carrots", "images/food/veg_pasta.jpeg",new ComingSoon() },
                                                           {"Vegtable Salad", "Spinach italian dressing peppers raisons ", "images/food/veg_salad.jpg",new ComingSoon() },
                                                           { "Lemon Chicken" ,"chicken lemon lime pepper salt", "images/food/chicken.jpeg", new LemonChickenDesc(false) },
                                                           {"Meatloaf", "Beef pepper curry salt chilli onion", "images/food/Meatloaf-121.jpg", new MeatDesc(false) },
                                                           {"Strawberry Souffle", "icing sugar strawberry dessert", "images/food/straw_sou.jpg", new StrawberrySouffleDesc(false) } };


        public favourites _favourites = new favourites();
        public Search _search = new Search();

        public AllRecipes _allRecipes = new AllRecipes();
        public categories _categories = new categories();
		public Beat_Definition _beatDefinition = new Beat_Definition();
        public MeatIngr _meatIngr = new MeatIngr();
        public Popular _popular = new Popular();
        public StrawberrySouffleIngr _strawIngr = new StrawberrySouffleIngr();
		

        public Settings _settings = new Settings();

        public HomePage _homePage = new HomePage();
		public Souffle_Step1 _souffleStep1 = new Souffle_Step1();
		public Souffle_Step2 _souffleStep2 = new Souffle_Step2();
		public Souffle_Step3 _souffleStep3 = new Souffle_Step3();
		public Souffle_Complete _souffleComp = new Souffle_Complete(false);
		public LemonIngred _lemonIngr = new LemonIngred();
		
		public Lemon_Step1 _lemonStep1 = new Lemon_Step1();
		public Lemon_Step2 _lemonStep2 = new Lemon_Step2();
		public Lemon_Step3 _lemonStep3 = new Lemon_Step3();
		public Lemon_Complete _lemonComp = new Lemon_Complete(false);

		public Meat_Step1 _meatStep1 = new Meat_Step1();
		public Meat_Step2 _meatStep2 = new Meat_Step2();
		public Meat_Step3 _meatStep3 = new Meat_Step3();
		public Meat_Step4 _meatStep4 = new Meat_Step4();
		public Meat_Complete _meatComp = new Meat_Complete(false);

		public Chopped_Definition _choppedDefinition = new Chopped_Definition();

		public bool isExpanded = true;

        public GlutenFree _glutenFree = new GlutenFree();
		public Intro intro = new Intro();


		public object CurrentUserControl { get; set; }


        
		
        public MainWindow()
        {
            InitializeComponent();
			
            Show();
            _Navigation.Navigate(_allRecipes);
            
            intro.Show();
			
            
            
           intro.close();
            

            _Navigation.Navigate(_homePage);
            CurrentUserControl = _homePage;

            _settings.imperialRadio.IsChecked = true;
            try { _meatIngr.SliderMover(null, null); } catch (Exception) { }
            try { _strawIngr.SliderMover(null, null); } catch (Exception) { }
            try { _lemonIngr.SliderMover(null, null); } catch (Exception) { }

        }




        public void initStrawMetric()
        {
            _strawIngr.straw_quan1.Text = "250 mL";
            _strawIngr.straw_quan2.Text = "500 mL";
            _strawIngr.straw_quan3.Text = "30 mL";
            _strawIngr.straw_quan4.Text = "3";
            _strawIngr.straw_quan5.Text = "60 mL";
            _strawIngr.straw_quan6.Text = "250 mL";
            _strawIngr.straw_quan7.Text = "5 mL";
            _strawIngr.straw_quan8.Text = "15 mL";
            _strawIngr.straw_quan9.Text = "250 mL";
        }

        public void initMeatMetric ()
        {
            _meatIngr.meat_quan1.Text = "0.45 kg.";
            _meatIngr.meat_quan2.Text = "2";
            _meatIngr.meat_quan3.Text = "500 mL.";
            _meatIngr.meat_quan4.Text = "250 mL.";
            _meatIngr.meat_quan5.Text = "1";
            _meatIngr.meat_quan6.Text = "250 mL.";
            _meatIngr.meat_quan7.Text = "15 mL.";
            _meatIngr.meat_quan8.Text = "15 mL.";
            _meatIngr.meat_quan9.Text = "Taste";
        }

        public void initLemonMetric()
        {
            _lemonIngr.lemon_quan1.Text = "4";
            _lemonIngr.lemon_quan2.Text = "60 mL";
            _lemonIngr.lemon_quan3.Text = "45 mL";
            _lemonIngr.lemon_quan4.Text = "30 mL";
            _lemonIngr.lemon_quan5.Text = "15 mL";
            _lemonIngr.lemon_quan6.Text = "15 mL";
            _lemonIngr.lemon_quan7.Text = "235 mL";
            _lemonIngr.lemon_quan8.Text = "5 mL";
            _lemonIngr.lemon_quan9.Text = " Taste";
        }

    public void initStrawImp()
        {
            _strawIngr.straw_quan1.Text = "1 Cup";
            _strawIngr.straw_quan2.Text = "2 Cups";
            _strawIngr.straw_quan3.Text = "2 Tbsps.";
            _strawIngr.straw_quan4.Text = "3";
            _strawIngr.straw_quan5.Text = "1/4 Cup";
            _strawIngr.straw_quan6.Text = "1 Cup";
            _strawIngr.straw_quan7.Text = "1 Tsp.";
            _strawIngr.straw_quan8.Text = "1 Tbsp.";
            _strawIngr.straw_quan9.Text = "1 Cup";
        }

        public void initMeatImp()
        {
            _meatIngr.meat_quan1.Text = "1 lb.";
            _meatIngr.meat_quan2.Text = "2";
            _meatIngr.meat_quan3.Text = "2 Cups";
            _meatIngr.meat_quan4.Text = "1 Cup";
            _meatIngr.meat_quan5.Text = "1";
            _meatIngr.meat_quan6.Text = "1 Cup";
            _meatIngr.meat_quan7.Text = "1 tbsp.";
            _meatIngr.meat_quan8.Text = "1 tbsp.";
            _meatIngr.meat_quan9.Text = "Taste";
        }

        public void initLemonImp()
        {
            _lemonIngr.lemon_quan1.Text = "4";
            _lemonIngr.lemon_quan2.Text = "1/4 Cup";
            _lemonIngr.lemon_quan3.Text = "3 Tbsps.";
            _lemonIngr.lemon_quan4.Text = "2 Tbsps.";
            _lemonIngr.lemon_quan5.Text = "1 Tbsp.";
            _lemonIngr.lemon_quan6.Text = "1 Tbsp.";
            _lemonIngr.lemon_quan7.Text = "1/3 Cup";
            _lemonIngr.lemon_quan8.Text = "1 Tsp.";
            _lemonIngr.lemon_quan9.Text = "Taste";
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
            //reinit();
        }



		public void reinit(object Control)
		{


			if (CurrentUserControl is Meat_Step2)
            {

            }
            else if (CurrentUserControl is Meat_Step3)
            {

            }
            else if (CurrentUserControl is Meat_Step4)
            {

            }
            else if (CurrentUserControl is Lemon_Step1)
            {

            }
            else if (CurrentUserControl is Lemon_Step2)
            {

            }
            else if (CurrentUserControl is Lemon_Step3)
            {

            }
            else if (Control is Souffle_Step1)
            {
                try { _strawIngr.SliderMover(null, null); } catch (Exception) { }
                string[] ingredString = { _strawIngr.straw_ingr1.Text, _strawIngr.straw_ingr2.Text, _strawIngr.straw_ingr3.Text, _strawIngr.straw_ingr4.Text, _strawIngr.straw_ingr5.Text };
                string[] quantities = { _strawIngr.straw_quan1.Text, _strawIngr.straw_quan2.Text, _strawIngr.straw_quan3.Text, _strawIngr.straw_quan4.Text, _strawIngr.straw_quan5.Text };
                populateStep(quantities, ingredString, _souffleStep1.straw_step1wrap);
                
            }
            else if (CurrentUserControl is Souffle_Step2)
            {

            }
            else if (CurrentUserControl is Souffle_Step3)
            {

            }
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
			if ((CurrentUserControl is Meat_Step1 || CurrentUserControl is Meat_Step2 || CurrentUserControl is Meat_Step3 || CurrentUserControl is Meat_Step4 ||
				CurrentUserControl is Lemon_Step1 || CurrentUserControl is Lemon_Step2 || CurrentUserControl is Lemon_Step3 ||
				CurrentUserControl is Souffle_Step1 || CurrentUserControl is Souffle_Step2 || CurrentUserControl is Souffle_Step3))
			{
				
				
				step_expander.Visibility = Visibility.Visible;
			}
			if (CurrentUserControl is StrawberrySouffleDesc)
            {
                StrawberrySouffleDesc ssd = CurrentUserControl as StrawberrySouffleDesc;
                ssd.strawDescSidebarCollapsed = false;
                _recipesArray[11, 3] = ssd;
            }
            else if (CurrentUserControl is StrawberrySouffleIngr)
            {
                _strawIngr.strawSoufIngrCollapsed = false;
            }

            else if (CurrentUserControl is MeatDesc)
            {
                MeatDesc md = CurrentUserControl as MeatDesc;
                md.meatDescSidebarCollapsed = false;
                _recipesArray[10, 3] = md;
            }
            else if (CurrentUserControl is MeatIngr)
            {
                _meatIngr.meatIngrCollapsed = false;
            }

            else if (CurrentUserControl is LemonChickenDesc)
            {
                LemonChickenDesc lcd = CurrentUserControl as LemonChickenDesc;
                lcd.lemonSidebarCollapsed = false;
                _recipesArray[9, 3] = lcd;
            }
            else if (CurrentUserControl is LemonIngred)
            {
                _lemonIngr.lemonIngrCollapsed = false;
            }

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
			if ((CurrentUserControl is Meat_Step1 || CurrentUserControl is Meat_Step2 || CurrentUserControl is Meat_Step3 || CurrentUserControl is Meat_Step4 ||
				CurrentUserControl is Lemon_Step1 || CurrentUserControl is Lemon_Step2 || CurrentUserControl is Lemon_Step3 ||
				CurrentUserControl is Souffle_Step1 || CurrentUserControl is Souffle_Step2 || CurrentUserControl is Souffle_Step3))
			{
				
				step_expander.Visibility = Visibility.Hidden;
			}
			if (CurrentUserControl is StrawberrySouffleDesc)
            {
                StrawberrySouffleDesc ssd = CurrentUserControl as StrawberrySouffleDesc;
                ssd.strawDescSidebarCollapsed = true;
                _recipesArray[11, 3] = ssd;
            }
            else if (CurrentUserControl is StrawberrySouffleIngr)
            {
                _strawIngr.strawSoufIngrCollapsed = true;
            }
            else if (CurrentUserControl is MeatDesc)
            {
                MeatDesc md = CurrentUserControl as MeatDesc;
                md.meatDescSidebarCollapsed = true;
                _recipesArray[10, 3] = md;
            }
            else if (CurrentUserControl is MeatIngr)
            {
                _meatIngr.meatIngrCollapsed = true;
            }

            else if (CurrentUserControl is LemonChickenDesc)
            {
                LemonChickenDesc lcd = CurrentUserControl as LemonChickenDesc;
                lcd.lemonSidebarCollapsed = true;
                _recipesArray[9, 3] = lcd;
            }
            else if (CurrentUserControl is LemonIngred)
            {
                _lemonIngr.lemonIngrCollapsed = true;
            }
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
					md.meat_desc_inrec.Visibility = Visibility.Visible;
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
					md.meat_desc_inrec.Visibility = Visibility.Hidden;
                }

            }
            else if (CurrentUserControl is MeatIngr)
            {
                MeatIngr mi = CurrentUserControl as MeatIngr;
                if (!isExpanded)
                {
                    mi._meatIngr_Grid.Width = 470;
                    mi._meatIngr_Grid.Margin = new Thickness(40, 0, 0, 0);  
                }
                else
                {
                    mi._meatIngr_Grid.Width = 372;
                    mi._meatIngr_Grid.Margin = new Thickness(90, 0, 0, 0);
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
					lcd.chick_desc.Visibility = Visibility.Visible;

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
					lcd.chick_desc.Visibility = Visibility.Hidden;

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
					ssd.straw_desc_ingr.Visibility = Visibility.Visible;
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
					ssd.straw_desc_ingr.Visibility = Visibility.Hidden;
                    

                }
            }

			
			else if (CurrentUserControl is StrawberrySouffleIngr)
            {
                StrawberrySouffleIngr ssi = CurrentUserControl as StrawberrySouffleIngr;
                if (!isExpanded)
                {
                    
                    ssi._strawIngr_Grid.Width = 470;
                    ssi._strawIngr_Grid.Margin = new Thickness(40, 0, 0, 0);
                }
                else
                {
                    ssi._strawIngr_Grid.Width = 372;
                    ssi._strawIngr_Grid.Margin = new Thickness(90, 0, 0, 0);
                }
            }

			else if (CurrentUserControl is LemonIngred)
			{
                LemonIngred li = CurrentUserControl as LemonIngred;

                if (!isExpanded)
				{
					li._lemonIngr_Grid.Width = 470;
                    li._lemonIngr_Grid.Margin = new Thickness(40, 0, 0, 0);
                }
				else
				{
					li._lemonIngr_Grid.Width = 372;
                    li._lemonIngr_Grid.Margin = new Thickness(90, 0, 0, 0);
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

			else if (CurrentUserControl is Meat_Step2)
			{
				if (!isExpanded)
				{
					_meatStep2.Meat_Step2Grid.Width = 470;
					_meatStep2.BackButton.Visibility = Visibility.Visible;
				}

				else
				{

					_meatStep2.BackButton.Visibility = Visibility.Hidden;
				}
			}

			else if (CurrentUserControl is Meat_Step3)
			{
				if (!isExpanded)
				{
					_meatStep3.Meat_Step3Grid.Width = 470;
					_meatStep3.BackButton.Visibility = Visibility.Visible;
				}

				else
				{

					_meatStep3.BackButton.Visibility = Visibility.Hidden;
				}
			}

			else if (CurrentUserControl is Meat_Step4)
			{
				if (!isExpanded)
				{
					_meatStep4.Meat_Step4Grid.Width = 470;
					_meatStep4.BackButton.Visibility = Visibility.Visible;
				}

				else
				{

					_meatStep4.BackButton.Visibility = Visibility.Hidden;
				}
			}

			else if (CurrentUserControl is Souffle_Step1)
			{
				if (!isExpanded)
				{
					_souffleStep1.Souffle_Step1Grid.Width = 470;
					//_souffleStep1.BackButton.Visibility = Visibility.Visible;
				}
				else
				{
					//_souffleStep1.BackButton.Visibility = Visibility.Hidden;
				}
			}

			else if (CurrentUserControl is Souffle_Step2)
			{
				if (!isExpanded)
				{
					_souffleStep2.Souffle_Step2Grid.Width = 470;
					//_souffleStep2.BackButton.Visibility = Visibility.Visible;
				}
				else
				{
					//_souffleStep2.BackButton.Visibility = Visibility.Hidden;
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
					//_souffleStep3.BackButton.Visibility = Visibility.Hidden;
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
					//_souffleStep1.BackButton.Visibility = Visibility.Hidden;
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
					//_lemonStep2.BackButton.Visibility = Visibility.Hidden;
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
					//_lemonStep3.BackButton.Visibility = Visibility.Hidden;
				}
			}
            else if (CurrentUserControl is GlutenFree)
            {
                if (!isExpanded)
                {
                    _glutenFree._glutenFree_Grid.Width = 470;
                    _glutenFree._GlutenWrapPanel.Width = 430;
                    foreach (Button child in _glutenFree._GlutenWrapPanel.Children)
                        if (child.Width > 110)
                        {
                            break;
                        }
                        else
                        {
                            incButtonSize(_glutenFree._GlutenWrapPanel);
                            break;
                        }

                }
                else
                {
                    _glutenFree._glutenFree_Grid.Width = 372;
                    _glutenFree._GlutenWrapPanel.Width = 332;
                    decButtonSize(_glutenFree._GlutenWrapPanel);
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

        public void populateStep(string[] quantities, string[] ingredString, WrapPanel wp)
        {

            TextBlock[] arrayTB = new TextBlock[ingredString.Length];
            TextBlock[] ingredName = new TextBlock[ingredString.Length];
            for (int k = 0; k < arrayTB.Length; k++)
            {
                arrayTB[k] = new TextBlock();
            }
            for (int k = 0; k < ingredName.Length; k++)
            {
                ingredName[k] = new TextBlock();
            }

            
            for (int k = 0; k < arrayTB.Length; k++)
            {



                arrayTB[k].Text = quantities[k];

                arrayTB[k].FontSize = 12;
                arrayTB[k].HorizontalAlignment = HorizontalAlignment.Left;
                arrayTB[k].FontFamily = new FontFamily("Tw Cen MT Condensed Extra Bold");
                arrayTB[k].Height = 22;
                arrayTB[k].TextWrapping = TextWrapping.Wrap;
                arrayTB[k].VerticalAlignment = VerticalAlignment.Top;
                arrayTB[k].Width = 70;
                wp.Children.Add(arrayTB[k]);
                


              
                ingredName[k].Text = ingredString[k];
                ingredName[k].FontSize = 12;
                ingredName[k].HorizontalAlignment = HorizontalAlignment.Left;
                ingredName[k].FontFamily = new FontFamily("Tw Cen MT Condensed Extra Bold");
                ingredName[k].Height = 22;
                ingredName[k].TextWrapping = TextWrapping.Wrap;
                ingredName[k].VerticalAlignment = VerticalAlignment.Top;
                ingredName[k].Width = 146;
                wp.Children.Add(ingredName[k]);

            }

        }

		private void step_expander_Click(object sender, RoutedEventArgs e)
		{
			OpenCollapsed();

		}
	}
}
