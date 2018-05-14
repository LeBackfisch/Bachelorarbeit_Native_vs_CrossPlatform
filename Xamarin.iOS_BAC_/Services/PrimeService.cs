using System.Threading.Tasks;

namespace Xamarin.iOS_BAC_.Services
{
    public class PrimeService
    {
        public long GetPrime()
        {
			return FindPrimeNumber(100000).Result;
        }

        private static async Task<long> FindPrimeNumber(int n)
        {
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }
    }
}
