using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;

namespace PhotoHelper
{
    public class Photo
    {
        public static byte[] FileToByteArray(string fileName)
        {
            byte[] ba = null;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            ba = br.ReadBytes((int)numBytes);
            return ba;
        }

        public static void ByteArrayToFile(byte[] ba, string filename)
        {
            if (ba != null)
                File.WriteAllBytes(filename, ba);
        }
    }
}