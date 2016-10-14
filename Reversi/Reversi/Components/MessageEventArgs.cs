using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi.Components
{
    class MessageEventArgs : EventArgs
    {
        public string Message { get; set; }
        public bool DisplayMessage { get; set; }
        public bool IsError { get; set; }
    }
}
