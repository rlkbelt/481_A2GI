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
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class UserControl1 : UserControl
	{
		public string straw_quan1;
		public string straw_quan2;
		public string straw_quan3;
		public string straw_quan4;
		public string straw_quan5;
		public string straw_quan6;
		public string straw_quan7;
		public string straw_quan8;
		public string straw_quan9;
		
		public UserControl1()
		{
			straw_quan1 = "1 Cup";
			straw_quan2 = "2 Cups";
			straw_quan3 = "2 Tbsps.";
			straw_quan4 = "3";
			straw_quan5 = "1/4 Cup";
			straw_quan6 = "1 Cup";
			straw_quan7 = "1 Tsp.";
			straw_quan8 = "1 Tbsp.";
			straw_quan9 = "1 Cup";
		}
	}
}
