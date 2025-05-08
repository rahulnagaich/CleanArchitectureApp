using CleanArchitectureApp.Application.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace CleanArchitectureApp.Infrastructure.Export
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportToCsv<T>(List<T> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream, leaveOpen: true))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(records);
            }

            memoryStream.Position = 0; // Reset stream before returning
            return memoryStream.ToArray();
        }
    }
}
