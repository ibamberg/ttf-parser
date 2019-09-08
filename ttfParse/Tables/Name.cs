using System;
using System.Collections.Generic;
using System.Text;

namespace ttfParse.Tables
{
    class Name : TableEntity
    {
        string tag = "name";

        ushort format;
        ushort count;
        ushort stringOffset;

        List<NameRecord> nameRecords = new List<NameRecord>();

        public Ids ids = new Ids();

        public Name (BigEndianBinaryRaader reader) : base(reader)
        {

            base.startInit(reader);

            format = reader.ReadUInt16();
            count = reader.ReadUInt16();
            stringOffset = reader.ReadUInt16();

            for(ushort i = 0; i < count; i++)
            {
                NameRecord nameRecord = new NameRecord {
                    platformID = reader.ReadUInt16(),
                    encodingID = reader.ReadUInt16(),
                    languageID = reader.ReadUInt16(),
                    nameID = reader.ReadUInt16(),
                    length = reader.ReadUInt16(),
                    offset = reader.ReadUInt16(),
                };

                nameRecords.Add(nameRecord);

                long origPos = reader.BaseStream.Position;
                reader.BaseStream.Position = stringOffset + nameRecord.offset + base.offsetPos;

                Encoding encoding = (nameRecord.encodingID == 1 || nameRecord.encodingID == 3) ? Encoding.BigEndianUnicode : Encoding.UTF8;

                string recStr = encoding.GetString(reader.ReadBytes(nameRecord.length), 0, nameRecord.length);

                switch ((NameIdKind)nameRecord.nameID)
                {
                    case NameIdKind.CopyRightNotice:
                        this.ids.CopyRightNotice = recStr;
                        break;
                    case NameIdKind.FontFamilyName:
                        this.ids.FontFamilyName = recStr;
                        break;
                    case NameIdKind.FontSubfamilyName:
                        this.ids.FontSubfamilyName = recStr;
                        break;
                    case NameIdKind.UniqueFontIden:
                        this.ids.UniqueFontIden = recStr;
                        break;
                    case NameIdKind.FullFontName:
                        this.ids.FullFontName = recStr;
                        break;
                    case NameIdKind.VersionString:
                        this.ids.VersionString = recStr;
                        break;
                    case NameIdKind.PostScriptName:
                        this.ids.PostScriptName = recStr;
                        break;
                    case NameIdKind.Trademark:
                        this.ids.Trademark = recStr;
                        break;
                    case NameIdKind.ManufacturerName:
                        this.ids.ManufacturerName = recStr;
                        break;
                    case NameIdKind.Designer:
                        this.ids.Designer = recStr;
                        break;
                    case NameIdKind.Description:
                        this.ids.Description = recStr;
                        break;
                    case NameIdKind.UrlVendor:
                        this.ids.UrlVendor = recStr;
                        break;
                    case NameIdKind.UrlDesigner:
                        this.ids.UrlDesigner = recStr;
                        break;
                    case NameIdKind.LicenseDescription:
                        this.ids.LicenseDescription = recStr;
                        break;
                    case NameIdKind.LicenseInfoUrl:
                        this.ids.LicenseInfoUrl = recStr;
                        break;
                    case NameIdKind.Reserved:
                        this.ids.Reserved = recStr;
                        break;
                    case NameIdKind.TypographicFamilyName:
                        this.ids.TypographicFamilyName = recStr;
                        break;
                    case NameIdKind.TypographyicSubfamilyName:
                        this.ids.TypographyicSubfamilyName = recStr;
                        break;
                    case NameIdKind.CompatibleFull:
                        this.ids.CompatibleFull = recStr;
                        break;
                    case NameIdKind.SampleText:
                        this.ids.SampleText = recStr;
                        break;
                    case NameIdKind.PostScriptCID_FindfontName:
                        this.ids.PostScriptCID_FindfontName = recStr;
                        break;
                    case NameIdKind.WWSFamilyName:
                        this.ids.WWSFamilyName = recStr;
                        break;
                    case NameIdKind.WWSSubfamilyName:
                        this.ids.WWSSubfamilyName = recStr;
                        break;
                    case NameIdKind.LightBackgroundPalette:
                        this.ids.LightBackgroundPalette = recStr;
                        break;
                    case NameIdKind.DarkBackgroundPalette:
                        this.ids.DarkBackgroundPalette = recStr;
                        break;
                    case NameIdKind.VariationsPostScriptNamePrefix:
                        this.ids.VariationsPostScriptNamePrefix = recStr;
                        break;
                }

                reader.BaseStream.Position = origPos;
            }

            base.endItit(reader);
        }


        enum NameIdKind
        {
            CopyRightNotice,
            FontFamilyName,
            FontSubfamilyName,
            UniqueFontIden,
            FullFontName,
            VersionString,
            PostScriptName,
            Trademark,
            ManufacturerName,
            Designer,
            Description,
            UrlVendor,
            UrlDesigner,
            LicenseDescription,
            LicenseInfoUrl,
            Reserved,
            TypographicFamilyName,
            TypographyicSubfamilyName,
            CompatibleFull,
            SampleText,
            PostScriptCID_FindfontName,
                
            WWSFamilyName,
            WWSSubfamilyName,
           
            LightBackgroundPalette,
            DarkBackgroundPalette,

            VariationsPostScriptNamePrefix,

        }

        public struct Ids
        {
            public string CopyRightNotice;
            public string FontFamilyName;
            public string FontSubfamilyName;
            public string UniqueFontIden;
            public string FullFontName;
            public string VersionString;
            public string PostScriptName;
            public string Trademark;
            public string ManufacturerName;
            public string Designer;
            public string Description;
            public string UrlVendor;
            public string UrlDesigner;
            public string LicenseDescription;
            public string LicenseInfoUrl;
            public string Reserved;
            public string TypographicFamilyName;
            public string TypographyicSubfamilyName;
            public string CompatibleFull;
            public string SampleText;
            public string PostScriptCID_FindfontName;

            public string WWSFamilyName;
            public string WWSSubfamilyName;

            public string LightBackgroundPalette;
            public string DarkBackgroundPalette;

            public string VariationsPostScriptNamePrefix;
        }


        struct NameRecord
        {
            public ushort platformID;
            public ushort encodingID;
            public ushort languageID;
            public ushort nameID;
            public ushort length;
            public ushort offset;
        }

    }
}
