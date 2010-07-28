﻿using MeleeLib.Utility;

namespace MeleeLib.DatHandler {
    public class FtHeader : IData, IFilePiece {
        public const int Size = 0x60;
        public uint AttributesStart { get { return RawData.GetUInt32(0x00); } }
        public uint AttributesEnd { get { return RawData.GetUInt32(0x04); } }
        public uint Unknown1 { get { return RawData.GetUInt32(0x08); } }
        public uint SubactionStart { get { return RawData.GetUInt32(0x0C); } }
        public uint Unknown2 { get { return RawData.GetUInt32(0x10); } }
        public uint SubactionEnd { get { return RawData.GetUInt32(0x14); } }
        public ArraySlice<byte> Values { get { return RawData.Slice(0x18, 18); } }
        private FtHeader() {}
        public FtHeader(File file, ArraySlice<byte> rawData) { File = file; }
        public File File { get; private set; }
        public ArraySlice<byte> RawData {
            get { return File.DataSection.Slice((int)File.SectionType1Index[0].DataOffset, Size); }
        }

    }
}