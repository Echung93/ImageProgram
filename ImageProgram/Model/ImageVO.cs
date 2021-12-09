using System;

namespace ImageProgram
{
    public class ImageVO
    {
        private string title;
        private string link;
        private string thumbnail;
        private string sizeheight;
        private string sizewidth;

        public ImageVO()
        {

        }
        public ImageVO(string title, string link, string thumbnail, string sizeheight, string sizewidth)
        {
            this.title = title;
            this.link = link;
            this.thumbnail = thumbnail;
            this.sizeheight = sizeheight;
            this.sizewidth = sizewidth;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        public string Thumbnail
        {
            get { return thumbnail; }
            set { thumbnail = value; }
        }

        public string Sizeheight
        {
            get { return sizeheight; }
            set { sizeheight = value; }
        }

        public string Sizewidth
        {
            get { return sizewidth; }
            set { sizewidth = value; }
        }
    }
}
