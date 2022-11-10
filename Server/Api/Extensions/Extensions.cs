namespace Api.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Checks if the file is a valid extension.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="allowedExtension"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool ValidateFileExtension(this IFormFile file, params string[] allowedExtension)
        {
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (allowedExtension is null)
            {
                throw new ArgumentNullException(nameof(allowedExtension));
            }

            var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
            if (!allowedExtension.Contains(fileExt))
            {
                return false;
            }

            return true;
        }
    }

}
