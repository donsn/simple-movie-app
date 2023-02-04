using System;

namespace MovieMaster.Tools
{
    public static class SlugHelper
    {
        /// <summary>
        /// Converts a string to a slug
        /// </summary>
        public static string ToSlug(string value) {
            return value.ToLower().Replace(" ", "-");
        }
    }
}