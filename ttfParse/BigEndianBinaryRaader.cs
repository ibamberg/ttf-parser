using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ttfParse
{
    class BigEndianBinaryRaader : BinaryReader
    {
        public BigEndianBinaryRaader (Stream s) : base(s) { }


        public override int ReadInt32()
        {
            byte[] buf = base.ReadBytes(4);

            return buf[0] << 24 | buf[1] << 16 | buf[2] << 8 | buf[3];
        }

        public override uint ReadUInt32()
        {
            byte[] buf = base.ReadBytes(4);

            return (uint)(buf[0] << 24 | buf[1] << 16 | buf[2] << 8 | buf[3]);
        }

        public override short ReadInt16()
        {
            byte[] buf = base.ReadBytes(2);

            return (short)(buf[0] << 8 | buf[1]);
        }

        public override ushort ReadUInt16()
        {
            byte[] buf = base.ReadBytes(2);

            return (ushort)(buf[0] << 8 | buf[1]);
        }

        public string ReadTag()
        {
            byte[] buf = base.ReadBytes(4);

            return Encoding.ASCII.GetString(buf);
        }

        public string ReadString(ushort length)
        {
            byte[] buf = base.ReadBytes(length);

            return Encoding.ASCII.GetString(buf);
        }

        public byte[] ReadBytes(ushort length)
        {
            return base.ReadBytes(length);
        }

    }
}
