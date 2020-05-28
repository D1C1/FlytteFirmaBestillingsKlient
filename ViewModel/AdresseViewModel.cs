using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlytteFirmaBestillingsKlient
{
    public class AdresseViewModel
    {
        public AdresseViewModel()
        {
            AdresseFra = new Adresse();
            AdresseTil = new Adresse();
            //testdata
            AdresseFra.Adresselinje = "testadresse 1 ";
            AdresseTil.Adresselinje = "testadresse 2 ";
            //testdata
        }

        public Adresse AdresseFra { get; set; }
        public Adresse AdresseTil { get; set; }

    }
}
