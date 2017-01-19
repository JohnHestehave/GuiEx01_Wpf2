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

namespace Wpf2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controler controler;
        public MainWindow()
        {
            controler = Controler.GetInstance();
            InitializeComponent();
			UpdateLabels();
		}

		void UpdateLabels()
		{
			personcount.Content = "Person Count: " + controler.PerconCount;
			index.Content = "Index: " + controler.PersonIndex;
		}
		private void firstname_TextChanged(object sender, TextChangedEventArgs e)
		{
			if(controler.CurentPerson == null && firstname.Text != "")
			{
				controler.AddPerson();
				UpdateLabels();
			}
			if(firstname.Text != "")
			{
				controler.CurentPerson.FirstName = firstname.Text;
			}
		}
		private void lastname_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (controler.CurentPerson == null && lastname.Text != "")
			{
				controler.AddPerson();
				UpdateLabels();
			}
			if (lastname.Text != "")
			{
				controler.CurentPerson.LastName = lastname.Text;
			}
		}
		private void age_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (controler.CurentPerson == null && age.Text != "")
			{
				controler.AddPerson();
				UpdateLabels();
			}
			int num;
			bool parsed = Int32.TryParse(age.Text, out num);
			if (parsed && age.Text != "")
			{
				controler.CurentPerson.Age = num;
			}
		}
		private void tlf_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (controler.CurentPerson == null && tlf.Text != "")
			{
				controler.AddPerson();
				UpdateLabels();
			}
			if(tlf.Text != "")
			{
				controler.CurentPerson.TelephoneNr = tlf.Text;
			}
		}
		private void _new_Click(object sender, RoutedEventArgs e)
		{
			controler.AddPerson();
			firstname.Text = "";
			lastname.Text = "";
			age.Text = "";
			tlf.Text = "";
			UpdateLabels();
			
		}

		private void delete_Click(object sender, RoutedEventArgs e)
		{
			controler.DeletePerson();
			if (controler.CurentPerson != null)
			{
				firstname.Text = controler.CurentPerson.FirstName;
				lastname.Text = controler.CurentPerson.LastName;
				age.Text = controler.CurentPerson.Age.ToString();
				tlf.Text = controler.CurentPerson.TelephoneNr;
				UpdateLabels();
			}else
			{
				firstname.Text = "";
				lastname.Text = "";
				age.Text = "";
				tlf.Text = "";
				UpdateLabels();
			}
			
		}

		private void up_Click(object sender, RoutedEventArgs e)
		{
			controler.PrevPerson();
			if(controler.CurentPerson != null)
			{
				firstname.Text = controler.CurentPerson.FirstName;
				lastname.Text = controler.CurentPerson.LastName;
				age.Text = controler.CurentPerson.Age.ToString();
				tlf.Text = controler.CurentPerson.TelephoneNr;
				UpdateLabels();
			}
			
		}

		private void down_Click(object sender, RoutedEventArgs e)
		{
			controler.NextPerson();
			if (controler.CurentPerson != null)
			{
				firstname.Text = controler.CurentPerson.FirstName;
				lastname.Text = controler.CurentPerson.LastName;
				age.Text = controler.CurentPerson.Age.ToString();
				tlf.Text = controler.CurentPerson.TelephoneNr;
				UpdateLabels();

			}

		}
		
	}
}
