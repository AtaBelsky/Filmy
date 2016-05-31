namespace Filmy.Properties {
    
    
	// Tato třída Vám umožňuje zpracovávat specifické události v třídě nastavení:
	//  Událost SettingChanging je vyvolána před změnou hodnoty nastavení.
	//  Událost PropertyChanged  je vyvolána po změně hodnoty nastavení.
	//  Událost SettingsLoaded je vyvolána po načtení hodnot nastavení.
	//  Událost SettingsSaving je vyvolána před uložením hodnot nastavení.
	internal sealed partial class Settings {
        
		public Settings() {
			// Pro přidávání obslužných rutin událostí určených pro ukládání a změnu nastavení odkomentujte prosím níže uvedené řádky:

			// this.SettingChanging += this.SettingChangingEventHandler;

			// this.SettingsSaving += this.SettingsSavingEventHandler;

					
			///podle Codeproject.com
			///http://www.codeproject.com/Articles/57037/How-to-change-ConnectionString-easily

			this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.Settings_PropertyChanged);
			this.SettingsLoaded += new System.Configuration.SettingsLoadedEventHandler(this.Settings_SettingsLoaded);
			///
		}
        
		private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
		// Kód pro zpracování události SettingChangingEvent přidejte zde.
		}
        
		private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
		// Kód pro zpracování události SettingsSaving přidejte zde.
		}

		///podle Codeproject.com
		///http://www.codeproject.com/Articles/57037/How-to-change-ConnectionString-easily
		///
		[global::System.Configuration.UserScopedSettingAttribute()]
		public string ConnectionString {
			get { return (string)this["ConnectionString"]; }
			set { this["ConnectionString"] = value; }
		}

		private void Settings_PropertyChanged(System.Object sender, 	System.ComponentModel.PropertyChangedEventArgs e) 	{
			if (e.PropertyName == "ConnectionString") 	{
				this["FilmotekaConnectionString"] = this.ConnectionString;
			}
		}

		private void Settings_SettingsLoaded(System.Object sender, System.Configuration.SettingsLoadedEventArgs e) {
			// Advanced codes for post loading process...
		}

		public static void ChangeConnectionString(string connectionstring) {
			global::Filmy.Properties.Settings.Default.ConnectionString = connectionstring;
		}
		///
	}
}
