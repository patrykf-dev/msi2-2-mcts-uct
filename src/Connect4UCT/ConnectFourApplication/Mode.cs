using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourApplication
{
    public enum Mode {PlayerVsPlayer, PlayerVsComputer, ComputerVsPlayer, ComputerVsComputer };

    public class ModeConverter
    {
        private Dictionary<Mode, string> _modes = new Dictionary<Mode, string>();
        private ModeConverter()
        {
            _modes.Add(Mode.PlayerVsPlayer, "Player vs player");
            _modes.Add(Mode.PlayerVsComputer, "Player vs computer");
            _modes.Add(Mode.ComputerVsPlayer, "Computer vs player");
            _modes.Add(Mode.ComputerVsComputer, "Computer vs Computer");
        }

        public Mode GetMode(string value)
        {
            return _modes.FirstOrDefault(x => x.Value == value).Key;
        }

        public string GetString(Mode mode)
        {
            return _modes[mode];
        }          
        
        public List<string> GetAllStrings()
        {
            return _modes.Values.ToList();
        }

        private static ModeConverter _converter = null;
        public static ModeConverter GetModeConverter()
        {
            if (_converter == null)
                _converter = new ModeConverter();
            return _converter;
        }
    }


}
