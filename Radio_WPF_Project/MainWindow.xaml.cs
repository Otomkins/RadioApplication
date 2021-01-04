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

namespace Radio_WPF_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string station = "";
        public int channel = 0;

        private void On_Off_Button_Click(object sender, RoutedEventArgs e)
        {
            if (On_Off_Button.Content == FindResource("Off"))
            {
                On_Off_Button.Content = FindResource("On");
                Channel_1.Visibility = Visibility.Visible;
                Channel_2.Visibility = Visibility.Visible;
                Channel_3.Visibility = Visibility.Visible;
                Channel_4.Visibility = Visibility.Visible;
                Channel_5.Visibility = Visibility.Visible;
                Channel_6.Visibility = Visibility.Visible;
                Play_Button.Visibility = Visibility.Visible;
                Stop_Button.Visibility = Visibility.Visible;
            }
            else
            {
                On_Off_Button.Content = FindResource("Off");
                Channel_1.Visibility = Visibility.Hidden;
                Channel_2.Visibility = Visibility.Hidden;
                Channel_3.Visibility = Visibility.Hidden;
                Channel_4.Visibility = Visibility.Hidden;
                Channel_5.Visibility = Visibility.Hidden;
                Channel_6.Visibility = Visibility.Hidden;
                Play_Button.Visibility = Visibility.Hidden;
                Stop_Button.Visibility = Visibility.Hidden;
                Player.Stop();
                Playing_Text.Text = "";
                channel = 0;
            }
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            Player.Source = new Uri(station, UriKind.RelativeOrAbsolute);
            Player.Play();

                switch (channel)
            {
                case 0:
                    Playing_Text.Text = "Please select a station";
                    break;
                case 1:
                    Playing_Text.Text = "Now Playing: BBC Radio 1 - Pop";
                    break;
                case 2:
                    Playing_Text.Text = "Now Playing: BBC Radio 2 - Variety";
                    break;
                case 3:
                    Playing_Text.Text = "Now Playing: BBC Radio 3 - Classical & Opera";
                    break;
                case 4:
                    Playing_Text.Text = "Now Playing: BBC Radio 4FM - Talking";
                    break;
                case 5:
                    Playing_Text.Text = "Smooth HITS RADIO - Classic Hits";
                    break;
                case 6:
                    Playing_Text.Text = "80s New Wave Radio - New Wave & Alternative";
                    break;
            }
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            Playing_Text.Text = "";
            Player.Stop();
        }

        private void Channel_1_Click(object sender, RoutedEventArgs e)
        {
            station = "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1_mf_p"; // BBC 1
            channel = 1;
        }

        private void Channel_2_Click(object sender, RoutedEventArgs e)
        {
            station = "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio2_mf_p"; // BBC 2
            channel = 2;
        }

        private void Channel_3_Click(object sender, RoutedEventArgs e)
        {
            station = "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio3_mf_p"; // BBC 3
            channel = 3;
        }

        private void Channel_4_Click(object sender, RoutedEventArgs e)
        {
            station = "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio4fm_mf_p"; // BBC 4
            channel = 4;
        }

        private void Channel_5_Click(object sender, RoutedEventArgs e)
        {
            station = "http://n03.radiojar.com/xhh5qxh6rmzuv?rj-ttl=5&rj-tok=AAABdVEwLnMAR1_dwyOqVj0zzQ"; // Smooth HITS RADIO
            channel = 5;
        }

        private void Channel_6_Click(object sender, RoutedEventArgs e)
        {
            station = "http://192.99.37.181:8030/live"; // 80s New Wave Radio
            channel = 6;
        }

    }
}
