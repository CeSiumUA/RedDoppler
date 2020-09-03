using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DopplerLib.Social
{
    public class ConversationMember
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
                if(contact != value)
                {
                    contact = value;
                }
            }
        }
        public Conversation Conversation
        {
            get
            {
                return conversation;
            }
            set
            {
                if(conversation != value)
                {
                    conversation = value;
                }
            }
        }
        public MemberStatus MemberStatus
        {
            get
            {
                return memberStatus;
            }
            set
            {
                if(memberStatus != value)
                {
                    memberStatus = value;
                }
            }
        }
        #endregion
        #region Fields
        private Contact contact { get; set; }
        private Conversation conversation { get; set; }
        private MemberStatus memberStatus { get; set; }
        #endregion
    }
    public enum MemberStatus : int
    {
        Owner = 0,
        Admin,
        Regular,
        Banned
    }
}
