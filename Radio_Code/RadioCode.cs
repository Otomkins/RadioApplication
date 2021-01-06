using System;
using System.Collections.Generic;
using System.Text;

namespace Radio_Code
{
    public class RadioCode
    {
        readonly RadioService _rs = new RadioService();

        public string SelectStation(int station)
        {
            _rs.RadioStation = station;
            return _rs.StationConnectionRequest();
        }

        public string TogglePower()
        {
            return _rs.TogglePower();
        }

        public List<string> RetrieveStationList() => _rs.RetrieveStationsList();

        public string RetrieveCurrentStation() => _rs.RetrieveCurrentStationName();
    }
}