using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using ttfParse.Tables;

namespace ttfParse
{
    class ttf
    {
        public uint sfntVersion;
        public ushort numTables;
        public ushort searchRange;
        public ushort entrySelector;
        public ushort rangeShift;

        public Dictionary<string, TableEntity> tables;
        public TableMap tableMap = new TableMap();

        public ttf(BigEndianBinaryRaader reader)
        {
            tables = new Dictionary<string, TableEntity>();

            sfntVersion = reader.ReadUInt32();
            numTables = reader.ReadUInt16();
            searchRange = reader.ReadUInt16();
            entrySelector = reader.ReadUInt16();
            rangeShift = reader.ReadUInt16();

            for(ushort i = 0; i < numTables; i++)
            {

                string tag = reader.ReadTag();

                switch (tag)
                {
                    case "maxp":
                        tables.Add(tag, new Maxp(reader));
                        break;
                    case "name":
                        tables.Add(tag, new Name(reader));
                        break;

                    default:
                        reader.BaseStream.Position += 12;
                        break;
                }

            }

        }
   
    }
}
