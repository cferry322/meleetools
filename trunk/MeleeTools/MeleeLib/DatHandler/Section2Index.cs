﻿using System;
using System.Collections;
using System.Collections.Generic;
using MeleeLib.System;

namespace MeleeLib.DatHandler
{
    public class Section2Index : Node<Header>, IEnumerable<Section2Header>
    {
        public Section2Index(Header parent)
        {
            _parent = parent;
        }
        private readonly Header _parent;



        public uint Count { get { return Parent.SectionType1Count; } }
        public IEnumerator<Section2Header> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Section2Header this[int i]
        {

            get
            {
                if (i > Count) throw new IndexOutOfRangeException();
                return new Section2Header(Parent, i);
            }
        }

        public override Header Parent
        {
            get { return _parent; }
        }

        public override File File
        {
            get { return Parent.File; }
        }

        public override ArraySlice<byte> RawData
        {
            get { return Parent.DataSection.Slice((int)Parent.Datasize + (int)Parent.OffsetCount * 4, (int)Count * 8); }
        }
    }
}
