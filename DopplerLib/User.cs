using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DopplerLib
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        #region Properties
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if(userName != value)
                {
                    userName = value;
                }
            }
        }
        public string PasswordHash
        {
            get
            {
                return passwordHash;
            }
            set
            {
                if(passwordHash != value)
                {
                    passwordHash = value;
                }
            }
        }
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
        #endregion
        #region Fields
        private string userName { get; set; }
        private string passwordHash { get; set; }
        private Contact contact { get; set; }
        #endregion
    }
}
