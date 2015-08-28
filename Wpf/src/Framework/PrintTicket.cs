using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Printing.Interop
{ }

namespace System.Printing
{
    public //  sealed 
        abstract class PrintTicket : INotifyPropertyChanged
    {
        public PrintTicket() { }
        public PrintTicket(Stream xmlStream) { }

        //public Collation? Collation { get; set; }
        public int? CopyCount { get; set; }
        //public DeviceFontSubstitution? DeviceFontSubstitution { get; set; }
        //public Duplexing? Duplexing { get; set; }
        //public InputBin? InputBin { get; set; }
        //public OutputColor? OutputColor { get; set; }
        //public OutputQuality? OutputQuality { get; set; }
        //public PageBorderless? PageBorderless { get; set; }
        //public PageMediaSize PageMediaSize { get; set; }
        //public PageMediaType? PageMediaType { get; set; }
        //public PageOrder? PageOrder { get; set; }
        //public PageOrientation? PageOrientation { get; set; }
        //public PageResolution PageResolution { get; set; }
        
        public int? PageScalingFactor { get; set; }
        public int? PagesPerSheet { get; set; }

        //public PagesPerSheetDirection? PagesPerSheetDirection { get; set; }
        //public PhotoPrintingIntent? PhotoPrintingIntent { get; set; }
        //public Stapling? Stapling { get; set; }
        //public TrueTypeFontMode? TrueTypeFontMode { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract PrintTicket Clone();
        public abstract MemoryStream GetXmlStream();
        public abstract void SaveTo(Stream outStream);
    }
}
