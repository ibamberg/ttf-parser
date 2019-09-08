using System;
using System.Collections.Generic;
using System.Text;

namespace ttfParse
{
    class Maxp : TableEntity
    {
        string tag = "maxp";

        //Version 0.5
        uint version;
        ushort numGlyphs;

        //Version 1.0
        ushort maxPoints;
        ushort maxContours;
        ushort maxCompositePoints;
        ushort maxCompositeContours;
        ushort maxZones;
        ushort maxTwilightPoints;
        ushort maxStorage;
        ushort maxFunctionDefs;
        ushort maxInstructionDefs;
        ushort maxStackElements;
        ushort maxSizeOfInstructions;
        ushort maxComponentElements;
        ushort maxComponentDepth;

        public Maxp(BigEndianBinaryRaader reader) : base(reader)
        {
            long origPos = reader.BaseStream.Position;
            reader.BaseStream.Position = offsetPos;

            version = reader.ReadUInt32();
            numGlyphs = reader.ReadUInt16();

            if (version == 0x00010000)
            {
                maxPoints = reader.ReadUInt16();
                maxContours = reader.ReadUInt16();
                maxCompositePoints = reader.ReadUInt16();
                maxCompositeContours = reader.ReadUInt16();
                maxZones = reader.ReadUInt16();
                maxTwilightPoints = reader.ReadUInt16();
                maxStorage = reader.ReadUInt16();
                maxFunctionDefs = reader.ReadUInt16();
                maxInstructionDefs = reader.ReadUInt16();
                maxStackElements = reader.ReadUInt16();
                maxSizeOfInstructions = reader.ReadUInt16();
                maxComponentElements = reader.ReadUInt16();
                maxComponentDepth = reader.ReadUInt16();
            }

            reader.BaseStream.Position = origPos;
        }

    }
}
