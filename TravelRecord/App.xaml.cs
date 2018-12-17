using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microsoft.WindowsAzure.MobileServices;
using TravelRecord.Model;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TravelRecord
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;

		// This DB no longer exists.. Create a new one on Azure
        public static MobileServiceClient MobileService =
            new MobileServiceClient(
            "https://atravelrecord.azurewebsites.net"
        );

        //OFFLINE DB SYNC
        //public static IMobileServiceSyncTable<Post> postsTable;

        public static User user = new User();


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaseLocation;

            //OFFLINE DB
            //var store = new MobileServiceSQLiteStore(databaseLocation);
            //store.DefineTable<Post>();

            //MobileService.SyncContext.InitializeAsync(store);

            //postsTable = MobileService.GetSyncTable<Post>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
