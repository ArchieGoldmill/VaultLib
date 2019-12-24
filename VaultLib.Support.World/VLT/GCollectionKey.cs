﻿// This file is part of VaultLib by heyitsleo.
// 
// Created: 10/04/2019 @ 7:28 PM.

using System.IO;
using VaultLib.Core;
using VaultLib.Core.Data;
using VaultLib.Core.Hashing;
using VaultLib.Core.Types;
using VaultLib.Core.Types.Abstractions;
using VaultLib.Core.Utils;

namespace VaultLib.Support.World.VLT
{
    [VLTTypeInfo(nameof(GCollectionKey))]
    public class GCollectionKey : BaseRefSpec
    {
        public override void Read(Vault vault, BinaryReader br)
        {
            CollectionKey = HashManager.ResolveVLT(br.ReadUInt32());
        }

        public override void Write(Vault vault, BinaryWriter bw)
        {
            bw.Write(VLT32Hasher.Hash(CollectionKey));
        }

        public override string ClassKey
        {
            get => "gameplay";
            set { }
        }
        public override string CollectionKey { get; set; }
        public override bool CanChangeClass => false;

        public override string ToString()
        {
            return $"gameplay -> {CollectionKey}";
        }

        public GCollectionKey(VltClass @class, VltClassField field, VltCollection collection) : base(@class, field, collection)
        {
        }

        public GCollectionKey(VltClass @class, VltClassField field) : base(@class, field)
        {
        }
    }
}