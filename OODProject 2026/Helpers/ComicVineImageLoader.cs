using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OODProject_2026.Helpers
{
    public static class ComicVineImageLoader
    {
        public static readonly DependencyProperty ImageUrlProperty =
            DependencyProperty.RegisterAttached(
                "ImageUrl",
                typeof(string),
                typeof(ComicVineImageLoader),
                new PropertyMetadata(null, OnImageUrlChanged));

        public static string GetImageUrl(DependencyObject obj)
        {
            return (string)obj.GetValue(ImageUrlProperty);
        }

        public static void SetImageUrl(DependencyObject obj, string value)
        {
            obj.SetValue(ImageUrlProperty, value);
        }

        private static async void OnImageUrlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var image = d as Image;
            if (image == null)
                return;

            image.Source = null;

            var url = e.NewValue as string;
            if (string.IsNullOrWhiteSpace(url))
                return;

            url = url.Trim();
            if (string.IsNullOrWhiteSpace(url))
                return;

            try
            {
                var bitmap = await DownloadBitmapAsync(url);

                if (bitmap == null)
                    return;

                if (GetImageUrl(image) == url)
                {
                    image.Source = bitmap;
                }
            }
            catch
            {
                image.Source = null;
            }
        }

        private static async Task<BitmapImage> DownloadBitmapAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            try
            {
                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Tls12 |
                    SecurityProtocolType.Tls11 |
                    SecurityProtocolType.Tls;

                var request = WebRequest.CreateHttp(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0";
                request.AllowAutoRedirect = true;
                request.Timeout = 10000;
                request.ReadWriteTimeout = 10000;

                using (var response = (HttpWebResponse)(await request.GetResponseAsync()))
                {
                    if (response == null)
                        return null;

                    var contentType = response.ContentType ?? string.Empty;
                    if (!contentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
                        return null;

                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream == null)
                            return null;

                        using (var memoryStream = new MemoryStream())
                        {
                            await responseStream.CopyToAsync(memoryStream);

                            if (memoryStream.Length == 0)
                                return null;

                            memoryStream.Position = 0;

                            var bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.StreamSource = memoryStream;
                            bitmap.EndInit();
                            bitmap.Freeze();

                            return bitmap;
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}