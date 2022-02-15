using Phoneshop.WinForms.Objects;
using System.Collections.Generic;
using System.IO;

namespace Phoneshop.Domain.Interfaces
{
    public interface IXmlService
    {
        List<Phone> Read(TextReader xml);
    }
}
