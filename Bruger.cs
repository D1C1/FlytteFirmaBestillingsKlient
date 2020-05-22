using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlytteFirmaBestillingsKlient
{
    public class Bruger
    {
        private string _navn;
        private string _Email;
        private int _tlfNr;
        private int _brugerId;


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
        
        public int BrugerId
        {
            get { return _brugerId; }
            set { _brugerId = value; }
        }

        /// <summary>
        /// beskrivelse af brugerdetaljer
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Navn {Navn}";
        }
    }
}
