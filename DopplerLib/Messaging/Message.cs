using DopplerLib.Social;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DopplerLib.Messaging
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        #region Properties
        public ConversationMember Owner
        {
            get
            {
                return owner;
            }
            set
            {
                if(owner != value)
                {
                    owner = value;
                }
            }
        }
        public MessageContent Content
        {
            get
            {
                return content;
            }
            set
            {
                if(value != content)
                {
                    content = value;
                }
            }
        }
        #endregion
        #region Fields
        private ConversationMember owner { get; set; }
        private MessageContent content { get; set; }
        #endregion
    }
}
