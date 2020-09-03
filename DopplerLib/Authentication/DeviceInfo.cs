using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DopplerLib.Authentication
{
    public class DeviceInfo
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
        public string DeviceId
        {
            get
            {
                return deviceId;
            }
            set
            {
                if(deviceId != value)
                {
                    deviceId = value;
                }
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if(description != value)
                {
                    description = value;
                }
            }
        }
        public bool AccessGranted
        {
            get
            {
                return accessGranted;
            }
            set
            {
                if(accessGranted != value)
                {
                    accessGranted = value;
                }
            }
        }
        #endregion
        #region Fields
        private bool accessGranted { get; set; }
        private string description { get; set; }
        private string deviceId { get; set; }
        private Contact contact { get; set; }
        #endregion
    }
}
