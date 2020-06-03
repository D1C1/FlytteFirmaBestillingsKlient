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
        int _antalVaerelser;
        int _parkeringsAfstandmeter;
        bool _isElevator;

        public Adresse()
        {
            Adresselinje = "tewst";
        }

        public string Adresselinje { get => _adresselinje; set => _adresselinje = value; }
        public int Postnummer { get => _postnummer; set => _postnummer = value; }
        public string By { get => _by; set => _by = value; }
        public int AntalVaerelser { get => _antalVaerelser; set => _antalVaerelser = value; }
        public int ParkeringsAfstandmeter { get => _parkeringsAfstandmeter; set => _parkeringsAfstandmeter = value; }
        public bool IsElevator { get => _isElevator; set => _isElevator = value; }
        public string Boligarealm2 { get => _boligarealm2; set => _boligarealm2 = value; }

        /// <summary>
        /// Detaljer for adresse
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string returnstring = $"{Adresselinje}\r\nPostnummer: {Postnummer} {By}\r\nAntal værelser {AntalVaerelser}\r\n" +
                $"Parkerings afstand {ParkeringsAfstandmeter} meter\r\nBolig areal {Boligarealm2}m2\r\n";
            if (IsElevator)
            {
                returnstring += "der er elevator i bygningen\r\n ";
            }
            else
            {
                returnstring += "ingen elevator i bygningen\r\n ";
            }
            return returnstring;
        }
    }
}
