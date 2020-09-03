using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DopplerLib.Social
{
    public class Conversation
    {
        [Key]
        public Guid Id { get; set; }
        #region Properties
        public string ConversationName
        {
            get
            {
                return conversationName;
            }
            set
            {
                if(conversationName != value)
                {
                    conversationName = value;
                }
            }
        }
        public File Photo
        {
            get
            {
                return photo;
            }
            set
            {
                if(photo != value)
                {
                    photo = value;
                }
            }
        }
        #endregion
        #region Fields
        private string conversationName { get; set; }
        private File photo { get; set; }
        #endregion
    }
}
