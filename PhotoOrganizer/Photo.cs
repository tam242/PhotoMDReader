using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace PhotoOrganizer
{
    public class Photo
    {
        public int id { get; set; }
        public string path { get; set; }
        public string location { get; set; }
        public DateTime dateTaken { get; set; }
        public string people { get; set; }
        public string imageName { get; set; }


        //Get date from image
        private static Regex r = new Regex(":");
        public static DateTime GetDateTakenFromImage(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (Image targetImg = Image.FromStream(fs, false, false))
            {
                if (targetImg.PropertyIdList.Any(x => x == 36867))
                {
                    PropertyItem propItem = targetImg.GetPropertyItem(36867);
                    string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                    return DateTime.Parse(dateTaken);
                }
                else
                {
                    return DateTime.Parse("1801.01.01. 00:01");
                }
            }
        }

        //Get latitude properties from image and call ExifGpsToFloat with them.
        public static string GetLatitude(string path)
        {
            //Without loading the image
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (Image targetImg = Image.FromStream(fs, false, false))
            {
                if (targetImg.PropertyIdList.Any(x => x == 1) && targetImg.PropertyIdList.Any(x => x == 2))
                {
                    //Property Item 0x0001 - PropertyTagGpsLatitudeRef
                    PropertyItem propItemRef = targetImg.GetPropertyItem(1);
                    //Property Item 0x0002 - PropertyTagGpsLatitude
                    PropertyItem propItemLat = targetImg.GetPropertyItem(2);
                    return ExifGpsToFloat(propItemRef, propItemLat).ToString();
                }
                else
                {
                    return "unknown";
                }
            }
        }

        //Get longitude properties from image and call ExifGpsToFloat with them.
        public static string GetLongitude(string path)
        {
            //Without loading the image
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (Image targetImg = Image.FromStream(fs, false, false))
            {
                if (targetImg.PropertyIdList.Any(x => x == 3) && targetImg.PropertyIdList.Any(x => x == 4))
                {
                    //Property Item 0x0003 - PropertyTagGpsLongitudeRef
                    PropertyItem propItemRef = targetImg.GetPropertyItem(3);
                    //Property Item 0x0004 - PropertyTagGpsLongitude
                    PropertyItem propItemLong = targetImg.GetPropertyItem(4);
                    return ExifGpsToFloat(propItemRef, propItemLong).ToString();
                }
                else
                {
                    return "unknown";
                }             
            }
        }

        //Converts latitude and longitude from degrees, minutes, seconds to decimal (float)
        private static float ExifGpsToFloat(PropertyItem propItemRef, PropertyItem propItem)
        {
            uint degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
            uint degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
            float degrees = degreesNumerator / (float)degreesDenominator;

            uint minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
            uint minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
            float minutes = minutesNumerator / (float)minutesDenominator;

            uint secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
            uint secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
            float seconds = secondsNumerator / (float)secondsDenominator;

            float coorditate = degrees + (minutes / 60f) + (seconds / 3600f);
            string gpsRef = System.Text.Encoding.ASCII.GetString(new byte[1] { propItemRef.Value[0] }); //N, E, S, or W
            if (gpsRef == "S" || gpsRef == "W")
                coorditate = 0 - coorditate;
            return coorditate;
        }

    }

}
