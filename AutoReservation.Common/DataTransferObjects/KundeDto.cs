using AutoReservation.Common.DataTransferObjects.Core;
using System;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    public class KundeDto : DtoBase<KundeDto>
    {
        private DateTime geburtsdatum;
        public DateTime Geburtsdatum
        {
            get { return geburtsdatum; }
            set
            {
                if (geburtsdatum != value)
                {
                    geburtsdatum = value;
                    OnPropertyChanged(nameof(Geburtsdatum));
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

        private string nachname;
        public string Nachname
        {
            get { return nachname; }
            set
            {
                if (!nachname.Equals(value))
                {
                    nachname = value;
                    OnPropertyChanged(nameof(Nachname));
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

        private string vorname;
        public string Vorname
        {
            get { return vorname; }
            set
            {
                if (!vorname.Equals(value))
                {
                    vorname = value;
                    OnPropertyChanged(nameof(Vorname));
                }
            }
        }

       public override string Validate()
       {
           StringBuilder error = new StringBuilder();
           if (string.IsNullOrEmpty(Nachname))
           {
               error.AppendLine("- Nachname ist nicht gesetzt.");
           }
           if (string.IsNullOrEmpty(Vorname))
           {
               error.AppendLine("- Vorname ist nicht gesetzt.");
           }
           if (Geburtsdatum == DateTime.MinValue)
           {
               error.AppendLine("- Geburtsdatum ist nicht gesetzt.");
           }

           if (error.Length == 0) { return null; }

           return error.ToString();
       }

        //public override string ToString()
        //    => $"{Id}; {Nachname}; {Vorname}; {Geburtsdatum}";

    }
}
