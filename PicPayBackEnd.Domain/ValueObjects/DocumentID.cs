using PicPayBackEnd.Domain.Enums;
using PicPayBackEnd.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.ValueObjects
{
    public class DocumentID : ValueObject
    {
        public string Value { get; private set; }
        public DocumentType Type { get; private set; }

        private DocumentID(string value)
        {
            Value = value;
            Type = Utils.Utils.GetDocumentType(Value);
        }

        public static DocumentID Create(string value) => new DocumentID(value);
    }
}
