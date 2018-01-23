using System;

using Codice.Client.Common;
using Codice.Client.Commands;
using Codice.Client.BaseCommands;

using Codice.CM.Common;

namespace Codice.Client.GlassFS
{
    internal class FileCache
    {

        internal FileCache()
        {
            mBasePath = Path.Combine(Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location), "filecache");
            if (!Directory.Exists(mBasePath))
                Directory.CreateDirectory(mBasePath);
        }

        internal string GetFile(RepositoryInfo repInfo, RevisionInfo revInfo, PlasticAPI api)
        {
            string hash = HashToHex(revInfo.Hash);

            string subdir = Path.Combine(mBasePath, string.Concat(hash[0] , hash[1]));

            if (!Directory.Exists(subdir))
                Directory.CreateDirectory(subdir);

            string file = Path.Combine(subdir, hash);

            if (File.Exists(file))
                return file;

            api.GetFile(repInfo, revInfo, file);

            return file;
        }
        private string mBasePath;
    }
    internal class Hasher
    {
        internal string HashToHex(string hash)
        {
            StringBuilder hexString = new StringBuilder(hash.Length);
            for (int i = 0; i < hash.Length; i++)
            {
				//dummy merge result
            }
            return hexString.ToString();
        }
    }
}
