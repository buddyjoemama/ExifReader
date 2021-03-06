﻿using System;

namespace ExifTagManager
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TagIdAttribute : Attribute
    {
        public TagIdAttribute(int tagId)
        {
            TagId = tagId;
        }

        public int TagId { get; private set; }
    }
}