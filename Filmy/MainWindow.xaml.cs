using ControlAt;
using Fluent;
using System;
using System.Windows;

namespace Filmy
{
	/// <summary>
	/// Interakční logika pro MainWindow.xaml
	/// </summary>
	public partial class MainWindow : RibbonWindow
	{
		public Splash _splash = new Splash();

		public MainWindow()
		{
			_splash.Show();
			InitializeComponent();
		}

		private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
		{

			ModifyRegistry mreg = new ModifyRegistry();
			mreg.SubKey = "SOFTWARE\\Atma\\Filmy";
			string connectionString = mreg.Read("DbString");

			KontrolaDatabaze kontrola = new KontrolaDatabaze();

			if (string.IsNullOrEmpty(connectionString) || kontrola.TestExistenceDatabáze(connectionString, "SELECT Seznam.* FROM Seznam") != 23)
			{
				_splash.Visibility = Visibility.Hidden;
				//databáze není v registru, nebo je chybný connectionString
				connectionString = Filmy.Properties.Settings.Default.FilmotekaConnectionString;	//nahradit načtením nebo vytvořením databáze


				//MessageBox.Show("Databáze nepatří k programu, nebo není přístupná", "Databázi nelze připojit", MessageBoxButton.OK, MessageBoxImage.Error);
				//Application.Current.Shutdown();
				//return;
			}

			Filmy.Properties.Settings.ChangeConnectionString(connectionString);
			_splash.Close();
		}

		private void RibbonWindow_Closed(object sender, EventArgs e)
		{
			ModifyRegistry mreg = new ModifyRegistry();
			mreg.SubKey = "SOFTWARE\\Atma\\Filmy";
			mreg.Write("DbString", Filmy.Properties.Settings.Default.FilmotekaConnectionString);
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
