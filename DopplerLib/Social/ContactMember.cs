using System;
using System.ComponentModel.DataAnnotations;

namespace DopplerLib.Social
{
    public class ContactMember
    {
        [Key]
        public Guid Id { get; set; }
        public Contact ContactOwner { get; set; }
        public Contact ContactReference { get; set; }
    }
}