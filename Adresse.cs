using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlytteFirmaBestillingsKlient
{
    public class Adresse
    {
        string _adresselinje;
        int _postnummer;
        string _by;
        string _boligarealm2;
        int _antalVærelser;
        int _parkeringsAfstandmeter;
        bool _isElevator;

        public Adresse()
        {

        }

        public string Adresselinje { get => _adresselinje; set => _adresselinje = value; }
        public int Postnummer { get => _postnummer; set => _postnummer = value; }
        public string By { get => _by; set => _by = value; }
        public int AntalVærelser { get => _antalVærelser; set => _antalVærelser = value; }
        public int ParkeringsAfstandmeter { get => _parkeringsAfstandmeter; set => _parkeringsAfstandmeter = value; }
        public bool IsElevator { get => _isElevator; set => _isElevator = value; }
    }
}
