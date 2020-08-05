﻿/*
 * Created by Alexander Sosnovskiy. May 3, 2016
 */
using System.IO;
using UnityEngine;


namespace Caxapexac.Common.Sharp.Runtime.Data
{
    /// <summary>
    /// Disk storage work with file system.
    /// DONT work in WebPlayer/webgl
    /// </summary>
    public static class SimpleIo
    {
        private readonly static string _absolutePath = Application.persistentDataPath + "/";

        public static bool Exists(string relativePath)
        {
            var path = Path.Combine(_absolutePath, relativePath);

            return File.Exists(path);
        }

        public static void Remove(string relativePath)
        {
            var path = Path.Combine(_absolutePath, relativePath);

            if (File.Exists(path))
                File.Delete(path);
        }

        public static void Write(string relativePath, byte[] data)
        {
            var path = Path.Combine(_absolutePath, relativePath);

            if (File.Exists(path))
                File.Delete(path);

            File.WriteAllBytes(path, data);
        }

        public static byte[] Read(string relativePath)
        {
            var path = Path.Combine(_absolutePath, relativePath);

            if (File.Exists(path))
                return File.ReadAllBytes(path);

            return null;
        }

        public static void WriteText(string relativePath, string data)
        {
            var path = Path.Combine(_absolutePath, relativePath);

            if (File.Exists(path))
                File.Delete(path);

            File.WriteAllText(path, data);
        }

        public static string ReadText(string relativePath)
        {
            var path = Path.Combine(_absolutePath, relativePath);

            if (File.Exists(path))
                return File.ReadAllText(path);

            return string.Empty;
        }
    }
}