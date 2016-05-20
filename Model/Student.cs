using System.Xml.Serialization;

namespace Models {
    [XmlRoot]
    public class Student {
        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute]
        public string FirstName { get; set; }

        [XmlAttribute]
        public string LastName { get; set; }

        [XmlAttribute]
        public int Age { get; set; }

        [XmlAttribute]
        public string EmailAddress { get; set; }
    }
}