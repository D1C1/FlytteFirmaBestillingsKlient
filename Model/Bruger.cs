using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlytteFirmaBestillingsKlient
{
    public class Bruger
    {
        private string _forNavn;
        private string _efterNavn;
        private string _Email;
        private int _tlfNr;
        private int _brugerId;


        public Bruger()
        {

        }



        public string ForNavn
        {
            get { return _forNavn; }
            set { _forNavn = value; }
        }
        public string Efternavn
        {
            get { return _efterNavn; }
            set { _efterNavn = value; }
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
            return $"Fornavn: {ForNavn} Efternavn: {Efternavn} ";
        }
    }
}
