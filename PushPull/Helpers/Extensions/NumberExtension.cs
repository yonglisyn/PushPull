namespace PushPull.Helpers.Extensions
{
    public static class NumberExtension
    {
        public static string ToKFormat(this decimal number)
        {
            if (number >= 10000)
            {
                return (number / 1000).ToString("0.#") + "K";
            }
            return number.ToString("#,0");
        }
    }
}