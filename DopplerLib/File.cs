using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DopplerLib
{
    public class File
    {
        [Key]
        public Guid Id { get; set; }
        #region Properties
        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                if(value != filePath)
                {
                    filePath = value;
                }
            }
        }
        public FileType FileType
        {
            get
            {
                return fileType;
            }
            set
            {
                if(fileType != value)
                {
                    fileType = value;
                }
            }
        }
        #endregion
        #region Fields
        private string filePath { get; set; }
        private FileType fileType { get; set; }
        #endregion
    }
    public enum FileType : int
    {
        Photo = 0,
        Video,
        Icon,
        Audio,
        AudioMessage,
        VideoMessage,
        Document,
        Other
    }
}
