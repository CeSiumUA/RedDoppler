using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;

namespace DopplerLib.Messaging
{
    public class MessageViewer
    {
        [Key]
        public Guid Id { get; set; }
        #region Properties
        public Contact Contact
        {
            get
            {
                return contact;
            }
            set
            {
                if(value != contact)
                {
                    contact = value;
                }
            }
        }
        public Message Message
        {
            get
            {
                return message;
            }
            set
            {
                if(value != message)
                {
                    message = value;
                }
            }
        }
        public bool Seen
        {
            get
            {
                return seen;
            }
            set
            {
                if(seen != value)
                {
                    seen = value;
                }
            }
        }
        public DateTime DateSeen
        {
            get
            {
                return dateSeen;
            }
            set
            {
                if(dateSeen != value)
                {
                    dateSeen = value;
                }
            }
        }
        #endregion
        #region Fields
        private Contact contact { get; set; }
        private Message message { get; set; }
        private bool seen { get; set; }
        private DateTime dateSeen { get; set; }
        #endregion
    }
}
