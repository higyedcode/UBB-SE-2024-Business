// <copyright file="IDataEncryptionService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Iss.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDataEncryptionService
    {
        Dictionary<string, string> Encrypt(string data);

        string Decrypt(string data, string key);
    }
}
