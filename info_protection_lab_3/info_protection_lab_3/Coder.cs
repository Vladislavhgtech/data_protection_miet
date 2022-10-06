using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_protection_lab_3
{
    public class Coder
    {
        enum RgbQuad
        {
            Blue,
            Green,
            Red,
            Alpha
        };

        private const int HeadBytes = 54;

        private const string DecodeOut = @"decode.txt";
        private const string EncodeOut = @"encode.bmp";
        private const string TextOut = @"text.txt";

        public void Encode(string imgPath)
        {
            byte[] imgBytes = File.ReadAllBytes(imgPath);
            byte[] textBytes = File.ReadAllBytes(TextOut);

            List<byte> textLst = new List<byte>(textBytes);
            textLst.Add(0xFF);

            for (int idx = HeadBytes, i = 0; idx < HeadBytes + textLst.Count * 4; idx += 4, i++)
            {
                imgBytes[idx + (int)RgbQuad.Blue] &= (0xFC);
                imgBytes[idx + (int)RgbQuad.Blue] |= (byte)((textLst[i] >> 6));
                imgBytes[idx + (int)RgbQuad.Green] &= (0xFC);
                imgBytes[idx + (int)RgbQuad.Green] |= (byte)((textLst[i] >> 4) & 0x3);
                imgBytes[idx + (int)RgbQuad.Red] &= (0xFC);
                imgBytes[idx + (int)RgbQuad.Red] |= (byte)((textLst[i] >> 2) & 0x3);
                imgBytes[idx + (int)RgbQuad.Alpha] &= (0xFC);
                imgBytes[idx + (int)RgbQuad.Alpha] |= (byte)((textLst[i]) & 0x3);
            }

            FileStream fs = new FileStream(EncodeOut, FileMode.OpenOrCreate);
            fs.Write(imgBytes, 0, imgBytes.Length);
            fs.Close();
        }

        
        public void Decode(string encodePath = EncodeOut, string decodePath = DecodeOut)
        {
            byte[] encodeBytes = File.ReadAllBytes(encodePath);

            List<byte> decodeBytes = new List<byte>();
            for (int i = HeadBytes; i < encodeBytes.Length; i += 4)
            {
                byte decodeByte = (byte)(((encodeBytes[i + (int)RgbQuad.Blue] & 0x03) << 6) |
                                 ((encodeBytes[i + (int)RgbQuad.Green] & 0x03) << 4) |
                                 ((encodeBytes[i + (int)RgbQuad.Red] & 0x03) << 2) |
                                 ((encodeBytes[i + (int)RgbQuad.Alpha] & 0x03)));

                if (decodeByte == 0xFF) break;
                decodeBytes.Add(decodeByte);
            }

            FileStream fs = new FileStream(decodePath, FileMode.OpenOrCreate);
            fs.Write(decodeBytes.ToArray(), 0, decodeBytes.Count);
            fs.Close();
        }
    }
}
