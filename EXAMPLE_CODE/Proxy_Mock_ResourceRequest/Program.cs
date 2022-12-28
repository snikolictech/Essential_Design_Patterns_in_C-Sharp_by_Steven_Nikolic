using System;

namespace ProxyImageResource
{
    class Program
    {
        static void Main()
        {
            Subject proxy = new ImageProxy();
            proxy.Request();

            Console.WriteLine(proxy.URL);
        }
    }

    interface Subject
    {
        void Request();
        string URL { get; set; }
    }

    class ImageResource : Subject
    {
        public string URL { get; set; }

        public void Request()
        {
            var random = new Random();

            if (random.Next(2) < 1)
                URL = null;
            else
                URL = "Some Image URL";
        }
    }

    class ImageProxy : Subject
    {
        public string URL { get; set; }
        private ImageResource imageRes;

        public void Request()
        {
            if (imageRes == null)
                imageRes = new ImageResource();

            imageRes.Request();

            if (imageRes.URL == null)
                URL = "Dummy Image URL";
            else
                URL = imageRes.URL;
        }
    }
}
