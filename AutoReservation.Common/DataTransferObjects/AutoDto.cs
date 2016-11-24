using AutoReservation.Common.DataTransferObjects.Core;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    public class AutoDto : DtoBase<AutoDto>
    {
        private int basistarif;
        public int Basistarif
        {
            get { return basistarif; }
            set
            {
                if (basistarif != value)
                {
                    basistarif = value;
                    OnPropertyChanged(nameof(Basistarif));
                }
            }
        }


        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private string marke;
        public string Marke
        {
            get { return marke; }
            set
            {
                if (!marke.Equals(value))
                {
                    marke = value;
                    OnPropertyChanged(nameof(Marke));
                }
            }
        }

        private byte[] rowVersion;
        public byte[] RowVersion
        {
            get { return rowVersion; }
            set
            {
                if (rowVersion != value)
                {
                    rowVersion = value;
                    OnPropertyChanged(nameof(RowVersion));
                }
            }
        }

        private int tagestarif;
        public int Tagestarif
        {
            get { return tagestarif; }
            set
            {
                if (tagestarif != value)
                {
                    tagestarif = value;
                    OnPropertyChanged(nameof(Tagestarif));
                }
            }
        }

        private AutoKlasse autoklasse;
        public AutoKlasse AutoKlasse
        {
            get { return autoklasse; }
            set
            {
                if (autoklasse != value)
                {
                    autoklasse = value;
                    OnPropertyChanged(nameof(AutoKlasse));
                }
            }
        }

            public override string Validate()
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrEmpty(marke))
                {
                    error.AppendLine("- Marke ist nicht gesetzt.");
                }
                if (tagestarif <= 0)
                {
                    error.AppendLine("- Tagestarif muss grösser als 0 sein.");
                }
                if (AutoKlasse == AutoKlasse.Luxusklasse && basistarif <= 0)
                {
                    error.AppendLine("- Basistarif eines Luxusautos muss grösser als 0 sein.");
                }

                if (error.Length == 0) { return null; }

                return error.ToString();
            }

            public override string ToString()
                => $"{Id}; {Marke}; {Tagestarif}; {Basistarif}; {AutoKlasse}";

        }
}
