namespace Cinema.DataProcessor.ImportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public decimal Balance { get; set; }

        [XmlArray]
        public List<ImportTicketDto> Tickets { get; set; } = new List<ImportTicketDto>();
    }
}