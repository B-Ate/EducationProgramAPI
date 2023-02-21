using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace educationprogramAPI.DataAccessLayer.DataModel
{
    [DataContract]
    public class Education
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        public Guid ProgramId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Link { get; set; }
    }
}