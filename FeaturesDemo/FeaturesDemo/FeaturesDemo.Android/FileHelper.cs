using System;
using System.IO;
using Xamarin.Forms;
using FeaturesDemo.Droid;
using FeaturesDemo.Interfaces;

[assembly: Dependency(typeof(FileHelper))]
namespace FeaturesDemo.Droid
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}