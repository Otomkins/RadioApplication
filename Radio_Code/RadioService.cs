using System;
using System.Collections.Generic;
using System.Text;

namespace Radio_Code
{
    public class RadioService
    {
        private int _radioStation = 0;
        private bool _powerOn = true;

        public int RadioStation
        {
            get => _radioStation;
            set
            {
                if (_powerOn == true)
                {
                    if (value > 0 && value < 6) _radioStation = value;
                    else _radioStation = 7;
                }
            }
        }

        List<string> _radioStationsList = new List<string>()
        {
            "BBC 1",
            "BBC 2",
            "BBC 3",
            "BBC 4",
            "Smooth HITS RADIO",
            "80's New Wave Radio"
        };

        List<string> _radioStationsConnectionList = new List<string>()
        {
            "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1_mf_p", // BBC 1
            "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio2_mf_p", // BBC 2
            "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio3_mf_p", // BBC 3
            "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio4fm_mf_p", // BBC 4
            "http://n03.radiojar.com/xhh5qxh6rmzuv?rj-ttl=5&rj-tok=AAABdVEwLnMAR1_dwyOqVj0zzQ", // Smooth HITS RADIO
            "http://192.99.37.181:8030/live" // 80s New Wave Radio
        };

        private string RetrieveRadioStationConnection() => _radioStationsConnectionList[_radioStation - 1];

        public string TogglePower()
        {
            if(_powerOn == true)
            {
                _radioStation = 0;
                _powerOn = false;
                return "Turning off";
            }
            else
            {
                _radioStation = 1;
                _powerOn = true;
                return "Turning on";
            }
        }

        public string StationConnectionRequest()
        {
            if (_powerOn == true)
            {
                if (_radioStation == 7) return "Invalid station";
                return RetrieveRadioStationConnection();
            }
            else
                return "The radio is not turned on";
        }

        public List<string> RetrieveStationsList() => _radioStationsList;

        public string RetrieveCurrentStationName()
        {
            if (_powerOn == true)
            {
                if (_radioStation == 7) return "Invalid station";
                return _radioStationsList[_radioStation - 1];
            }
            else
                return "The radio is not turned on";
        }
    }
}
