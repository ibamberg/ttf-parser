using System;
using System.Collections.Generic;
using System.Text;

namespace ttfParse
{
    class TableEntity
    {

        public uint checkSum;
        public uint offsetPos;
        public uint length;

        private long origPos;

        public TableEntity(BigEndianBinaryRaader reader)
        {
            checkSum = reader.ReadUInt32();
            offsetPos = reader.ReadUInt32();
            length = reader.ReadUInt32();
        }

        protected void startInit(BigEndianBinaryRaader reader)
        {
            long origPos = reader.BaseStream.Position;
            reader.BaseStream.Position = this.offsetPos;
        }

        protected void endItit(BigEndianBinaryRaader reader)
        {
            reader.BaseStream.Position = this.origPos;
        }
    }
}
