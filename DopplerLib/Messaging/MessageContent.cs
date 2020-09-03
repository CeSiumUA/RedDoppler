using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DopplerLib.Messaging
{
    public class MessageContent
    {
        [Key]
        public Guid Id { get; set; }
        #region Properties
        public File File
        {
            get
            {
                return file;
            }
            set
            {
                if(file != value)
                {
                    file = value;
                }
            }
        }
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if(text != value)
                {
                    text = value;
                }
            }
        }
        #endregion
        #region Fields
        private File file { get; set; }
        private string text { get; set; }
        #endregion
    }
}
