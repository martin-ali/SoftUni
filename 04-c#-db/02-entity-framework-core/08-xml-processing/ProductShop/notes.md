# XML Processing

## Information

- Case sensitive
- Clear rules defining the format
- Needs to be well formatted
- DTD(Document Type Definitions)
    - Defines the document structure
    - Validates that document is
        - Valid
        - Well formed
- Extensible
    - Schema
    - .xsd
- Unicode
- Takes more space
- Slower to parse
- CDATA
- BinaryFormatter
    - A binary serializer
- Copy XML -> Make new class -> Edit -> Paste special -> Paste XML/JSON as classes

## Contents

- Root element
- Header tag
    - Version
    - Encoding
- Elements
- Attributes
    - Meta-data inside tags
    - Not present in JSON
- Values

## Parsing

- XDocument
    - .Add(XElement)
    - .Parse(string)
    - .Load(filePath)
    - .Save(filePath)
    - XElement
- XAttribute
    - XName
        - public static implicit operator XName(string expandedName)
            - Overrides cast
- LINQ to XML
- XmlSerializer

## Attributes

- [XmlType("Name")]
- [XmlAttribute("Name")]
- [XmlElement]
    - Serialized
    - Public properties are serialized by default
- [XmlIgnore]
- [XmlArray]
- [XmlRoot]
