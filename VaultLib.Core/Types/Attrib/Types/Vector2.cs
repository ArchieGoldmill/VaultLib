﻿// This file is part of VaultLib by heyitsleo.
// 
// Created: 09/28/2019 @ 3:52 PM.

using System.Globalization;
using System.IO;
using VaultLib.Core.Data;

namespace VaultLib.Core.Types.Attrib.Types
{
    [VLTTypeInfo("Attrib::Types::Vector2")]
    public class Vector2 : VLTBaseType
    {
        public Vector2(VltClass @class, VltClassField field, VltCollection collection) : base(@class, field, collection)
        {
        }

        public Vector2(VltClass @class, VltClassField field) : base(@class, field)
        {
        }

        public float X { get; set; }
        public float Y { get; set; }

        public override void Read(Vault vault, BinaryReader br)
        {
            X = br.ReadSingle();
            Y = br.ReadSingle();
        }

        public override void Write(Vault vault, BinaryWriter bw)
        {
            bw.Write(X);
            bw.Write(Y);
        }

        public override string ToString()
        {
            return $"({X.ToString(CultureInfo.InvariantCulture)}, {Y.ToString(CultureInfo.InvariantCulture)})";
        }
    }
}