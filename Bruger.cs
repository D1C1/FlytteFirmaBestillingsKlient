using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlytteFirmaBestillingsKlient
{
    class Bruger
    {
        private string _navn;
        private string _Email;
        private int _tlfNr;

        public Bruger()
        {

        }

        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }
        public int TlfNr
        {
            get { return _tlfNr; }
            set { _tlfNr = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
}
