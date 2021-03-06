﻿//  Dapplo - building blocks for desktop applications
//  Copyright (C) 2016-2018 Dapplo
// 
//  For more information see: http://dapplo.net/
//  Dapplo repositories are hosted on GitHub: https://github.com/dapplo
// 
//  This file is part of Dapplo.Dopy
// 
//  Dapplo.Dopy is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  Dapplo.Dopy is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have a copy of the GNU Lesser General Public License
//  along with Dapplo.Dopy. If not, see <http://www.gnu.org/licenses/lgpl.txt>.

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace Dapplo.Dopy.Shared.Entities
{
    /// <summary>
    /// Clip is the entity for the clipboard contents in the database
    /// </summary>
    public class Clip : EntityBase<int>, IDisposable
    {
        /// <summary>
        /// The ID for the session
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        /// Test if this clip was modified by Dopy
        /// </summary>
        public bool IsModifiedByDopy { get; set; }

        /// <summary>
        /// The icon for the owner of the clipboard
        /// </summary>
        public BitmapSource OwnerIcon { get; set; }

        /// <summary>
        /// Timestamp when the clip was created
        /// </summary>
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Name of the process which created the clip, e.g. Chrome.exe
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// Name of the product which created the clip, e.g. Google Chrome
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The original handle of the window
        /// </summary>
        public IntPtr OriginalWindowHandle { get; set; }

        /// <summary>
        /// The original sequence number
        /// </summary>
        public uint SequenceNumber { get; set; }

        /// <summary>
        /// Title of the window which created the clip
        /// </summary>
        public string WindowTitle { get; set; }

        /// <summary>
        /// The actualy Text of the clipboard, if there was any
        /// </summary>
        public string ClipboardText { get; set; }

        /// <summary>
        /// Formats originally stored in the clip
        /// </summary>
        public IList<string> OriginalFormats { get; set; } = new List<string>();

        /// <summary>
        /// The actual formats stored
        /// </summary>
        public IList<string> Formats { get; set; } = new List<string>();

        /// <summary>
        /// The filenames on the clipboard
        /// </summary>
        public IList<string> Filenames { get; set; } = new List<string>();

        /// <summary>
        /// The actual clipboard contents
        /// </summary>
        public IDictionary<string, MemoryStream> Contents { get; } = new Dictionary<string, MemoryStream>();

        /// <inheritdoc />
        public void Dispose()
        {
            foreach (var contentsValue in Contents.Values)
            {
                contentsValue?.Dispose();
            }
            Contents.Clear();
            Filenames.Clear();
            Formats.Clear();
            OriginalFormats.Clear();
        }
    }
}
