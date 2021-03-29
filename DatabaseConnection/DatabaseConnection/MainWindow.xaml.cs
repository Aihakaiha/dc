using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using DiscordRPC;
using DiscordRPC.Logging;

namespace DatabaseConnection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DiscordRpcClient client;
        void Initialize()
        {
            client = new DiscordRpcClient("744803710730764310");

            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            client.OnReady += (sender, e) =>
            {
                Console.WriteLine($"Ready from user { e.User.Username}");
            };
            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine($"Update {e.Presence}");
            };

            client.Initialize();


            client.SetPresence(new RichPresence()
            {
                State = "Not connected",
                Assets = new Assets()
                {
                    LargeImageKey = "nconn",
                    LargeImageText = "MyDatabConn not connected"
                }
            });
        }


        public string server;
        public string port;
        public string database;
        public string username;
        public string password;


        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            server = ServerText.Text;
            port = PortText.Text;
            database = DatabaseText.Text;
            username = UsernameText.Text;
            password = PasswordText.Text;
            MessageBox.Show($"{server} {port} {database} {username} {password}");
            client.SetPresence(new RichPresence()
            {
                State = "Connected",
                Assets = new Assets()
                {
                    LargeImageKey = "conn",
                    LargeImageText = "MyDatabConn connected"
                }
            });
        }
    }
}
