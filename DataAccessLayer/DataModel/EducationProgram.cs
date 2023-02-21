using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace educationprogramAPI.DataAccessLayer.DataModel
{
    [DataContract]
    public class EducationProgram
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        [ForeignKey("ProgramId")]
        public List<Education> Educations { get; set; }
    }
}