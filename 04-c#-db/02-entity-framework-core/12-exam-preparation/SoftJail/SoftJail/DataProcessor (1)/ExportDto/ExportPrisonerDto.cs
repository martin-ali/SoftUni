namespace SoftJail.DataProcessor.ExportDto
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class ExportPrisonerDto
    {
        public int Id { get; set; }

        [XmlElement("Name")]
        public string FullName { get; set; }

        public string IncarcerationDate { get; set; }

        [XmlArray]
        public List<ExportMailDto> EncryptedMessages { get; set; }
    }
}