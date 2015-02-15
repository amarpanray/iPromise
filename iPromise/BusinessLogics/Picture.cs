using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPromise.BusinessLogics
{
    public class Picture:ILike
    {
        //This name never comes from user
        public string Filename { get; set; }
        
        public string Filepath { get; set; }
        public double Filesize { get; set; }
        public string filetype { get; set; }

        public double pictureLength { get; set; }
        public double pictureWidth { get; set; }

        public IList<Picture> PhotoAlbum { get; set; }

        public void SavePicture()
        { }
        public void EditPicture()
        { }
        public void DeletePicture()
        { }
        public void ResizePicture()
        { }
        public void RotatePicture()
        { }
        #region implementation of ILike
        public int _Like { get; set; }
        public int _Dislike { get; set; }


        public void Like()
        {
            _Like += 1;
        }

        public void Dislike()
        {
            _Dislike -= 1;
        }
        #endregion
    }
}