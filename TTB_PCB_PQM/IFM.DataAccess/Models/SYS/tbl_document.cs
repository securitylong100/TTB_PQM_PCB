using System;

namespace IFM.DataAccess.Models.SYS
{
    public class tbl_document : DbModel
    {
        private string _doc_cd;
        public string doc_cd
        {
            get => _doc_cd;
            set
            {
                _doc_cd = value;
                doc_summary = $"{_doc_cd}.pdf";
            }
        }

        public string doc_path { get; set; }
        public string doc_summary { get; set; }
        public string doc_files { get; set; }
        public int doc_type { get; set; }
        public string item_cd { get; set; }
        public int item_state { get; set; }

        public DocumentTypes DocTypes
        {
            get => (DocumentTypes)doc_type;
            set => doc_type = (int)value;
        }

        public tbl_document()
        {
            doc_type = 0;
            item_state = 0;
            item_cd = string.Empty;
            doc_path = string.Empty;
            doc_files = string.Empty;
            doc_cd = $"DOC-{DateTime.Today:yyyyMMdd-HHmmss}";
        }
    }

    public enum DocumentTypes
    {
        Order = 0,
        Quote = 1,
        Invoice = 2,
        MPO = 3,
        Item = 4
    }
}
