using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;

namespace DopplerLib
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        #region Properties
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if(firstName != value)
                {
                    firstName = value;
                }
            }
        }
        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                if(secondName != value)
                {
                    secondName = value;
                }
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                if(status != value)
                {
                    status = value;
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
        public bool Online
        {
            get
            {
                return online;
            }
            set
            {
                if(online != value)
                {
                    online = value;
                }
            }
        }
        #endregion
        #region Fields
        private string firstName { get; set; }
        private string secondName { get; set; }
        private string status { get; set; }
        private File photo { get; set; }
        private bool online { get; set; }
        #endregion
    }
}
