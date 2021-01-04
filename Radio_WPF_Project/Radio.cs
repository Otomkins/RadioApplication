using System;
using System.Collections.Generic;
using System.Text;

namespace Radio_WPF_Project
{
    public class Radio
    {
        private int _channel = 1;
        private bool _on = false;

        public int Channel
        {
            get
            {
                return _channel;
            }
            set
            {
                if(_on == true)
                {
                    if (value > 0 && value < 5)
                        _channel = value;
                    else
                        _channel = 2;
                }
                else
                {
                        _channel = 1;
                }

            }
        }

        public string Play()
        {
            string _channelMessage = "";

            if (_on == true)
            {
                if (Channel < 0 || Channel > 5)
                    Channel = 2;

                switch (Channel)
                {
                    case 1:
                        _channelMessage = "Playing channel 1";
                        break;
                    case 2:
                        _channelMessage = "Playing channel 2";
                        break;
                    case 3:
                        _channelMessage = "Playing channel 3";
                        break;
                    case 4:
                        _channelMessage = "Playing channel 4";
                        break;
                    case 5:
                        _channelMessage = "Playing channel 5";
                        break;
                    case 6:
                        _channelMessage = "Playing channel 6";
                        break;
                }
                return _channelMessage;

            }
            else
            {
                Channel = 1;
                return "Radio is off";
            }

        }

        public void TurnOff()
        {
            _on = false;
        }

        public void TurnOn()
        {
            _on = true;
        }
    }
}
