using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        public decimal Price { get; set; }

        public int ProjectionId { get; set; }
    }
}