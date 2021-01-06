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
using Radio_Code;

namespace Radio_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly RadioCode _rc = new RadioCode();

        public MainWindow()
        {
            InitializeComponent();
        }

        private string _stationConnection = "";
        private int _radioStation = 0;

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
                _radioStation = 0;
            }
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            Player.Source = new Uri(_stationConnection, UriKind.RelativeOrAbsolute);
            Player.Play();

            switch (_radioStation)
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

        private void Channel_1_Click(object sender, RoutedEventArgs e) => SelectRadioStation(1);

        private void Channel_2_Click(object sender, RoutedEventArgs e) => SelectRadioStation(2);

        private void Channel_3_Click(object sender, RoutedEventArgs e) => SelectRadioStation(3);

        private void Channel_4_Click(object sender, RoutedEventArgs e) => SelectRadioStation(4);

        private void Channel_5_Click(object sender, RoutedEventArgs e) => SelectRadioStation(5);

        private void Channel_6_Click(object sender, RoutedEventArgs e) => SelectRadioStation(6);

        public void SelectRadioStation(int station)
        {
            var connectionRequest = _rc.SelectStation(station);
            if (connectionRequest == "Invalid station")
            {

            }
            else if (connectionRequest == "The radio is not turned on")
            {

            }
            else
                _stationConnection = connectionRequest;
        }
    }
}
