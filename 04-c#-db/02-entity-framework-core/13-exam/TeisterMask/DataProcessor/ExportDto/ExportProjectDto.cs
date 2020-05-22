using System.Collections.Generic;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectDto
    {
        [XmlAttribute]
        public int TasksCount { get; set; }

        public string ProjectName { get; set; }

        public string HasEndDate { get; set; }

        [XmlArray]
        public List<ExportTaskDto> Tasks { get; set; }
    }
}