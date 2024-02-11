﻿// This file is part of VaultLib by heyitsleo.
// 
// Created: 09/24/2019 @ 3:56 PM.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using VLT32Hasher = VaultLib.Core.Hashing.VLT32Hasher;
using VLT64Hasher = VaultLib.Core.Hashing.VLT64Hasher;

namespace VaultLib.Core.Hashing
{
    public static class HashManager
    {
        private static readonly Dictionary<uint, string> VltHashDictionary = new Dictionary<uint, string>();
        private static readonly Dictionary<ulong, string> Vlt64HashDictionary = new Dictionary<ulong, string>();
        private static string HashFile;

        public static void LoadDictionary(string file)
        {
            HashFile = file;
            foreach (var line in File.ReadLines(file)) AddVLT(line);
        }

        public static void AddVLT(string str)
        {
            if (!str.ToLowerInvariant().StartsWith("0x"))
            {
                VltHashDictionary[VLT32Hasher.Hash(str)] = str;
                Vlt64HashDictionary[VLT64Hasher.Hash(str)] = str;
            }
        }

        public static string ResolveVLT(uint hash)
        {
            return VltHashDictionary.TryGetValue(hash, out var s) ? s : $"0x{hash:X8}";
        }

        public static string ResolveVLT(ulong hash)
        {
            return Vlt64HashDictionary.TryGetValue(hash, out var s) ? s : $"0x{hash:X16}";
        }

        public static void Save()
        {
            if (!string.IsNullOrEmpty(HashFile))
                File.WriteAllLines(HashFile, VltHashDictionary.Select(x => x.Value));
        }
    }
}