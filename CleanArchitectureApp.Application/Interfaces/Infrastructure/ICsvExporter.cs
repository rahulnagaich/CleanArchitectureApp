using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Interfaces.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportToCsv<T>(List<T> records);
    }
}
