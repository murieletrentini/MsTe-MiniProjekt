using AutoReservation.Common.DataTransferObjects.Core;
using System;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{ 
    public class ReservationDto : DtoBase<ReservationDto>
    {
        private DateTime bis;
        public DateTime Bis
        {
            get { return bis; }
            set
            {
                if (bis != value)
                {
                    bis = value;
                    OnPropertyChanged(nameof(Bis));
                }
            }
        }

        private int reservationsNr;
        public int ReservationsNr
        {
            get { return reservationsNr; }
            set
            {
                if (reservationsNr != value)
                {
                    reservationsNr = value;
                    OnPropertyChanged(nameof(ReservationsNr));
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

        private DateTime von;
        public DateTime Von
        {
            get { return von; }
            set
            {
                if (von != value)
                {
                    von = value;
                    OnPropertyChanged(nameof(Von));
                }
            }
        }
     

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (Von == DateTime.MinValue)
            {
                error.AppendLine("- Von-Datum ist nicht gesetzt.");
            }
            if (Bis == DateTime.MinValue)
            {
                error.AppendLine("- Bis-Datum ist nicht gesetzt.");
            }
            if (Von > Bis)
            {
                error.AppendLine("- Von-Datum ist grösser als Bis-Datum.");
            }
            if (Auto == null)
            {
                error.AppendLine("- Auto ist nicht zugewiesen.");
            }
            else
            {
                string autoError = Auto.Validate();
                if (!string.IsNullOrEmpty(autoError))
                {
                    error.AppendLine(autoError);
                }
            }
            if (Kunde == null)
            {
                error.AppendLine("- Kunde ist nicht zugewiesen.");
            }
            else
            {
                string kundeError = Kunde.Validate();
                if (!string.IsNullOrEmpty(kundeError))
                {
                    error.AppendLine(kundeError);
                }
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override string ToString()
            => $"{ReservationsNr}; {Von}; {Bis}; {Auto}; {Kunde}";

    }
}   
