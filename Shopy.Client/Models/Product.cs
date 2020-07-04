﻿using Shopy.Client.Common;
using Shopy.Client.Helpers;
using System;
using System.Collections.Generic;

namespace Shopy.Client.Models
{
    public class Product
    {
        public Guid Uid { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public Brand Brand { get; set; }

        public IEnumerable<Size> Sizes { get; set; }

        public IEnumerable<CategoryLookup> Categories { get; set; }

        public string Image1Url => ImageHelper.GetImageUrl(Uid, SettingsHelper.Image1Name);

        public string Image2Url => ImageHelper.GetImageUrl(Uid, SettingsHelper.Image2Name);

        public string Image3Url => ImageHelper.GetImageUrl(Uid, SettingsHelper.Image3Name);
    }
}