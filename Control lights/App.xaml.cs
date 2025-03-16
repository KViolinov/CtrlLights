using Supabase.Interfaces;
using Supabase;

namespace Control_lights
{
    public partial class App : Application
    {


        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
