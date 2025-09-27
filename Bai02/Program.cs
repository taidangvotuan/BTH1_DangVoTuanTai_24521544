using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bai02
{
    internal class Program
    {
        // Hàm kiểm tra số nguyên tố của 1 số nguyên dương
        static bool KiemTraSoNguyenTo(int n)
        {
            if (n < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        // Hàm tính tổng các số nguyên tố nhỏ hơn số nguyên dương n
        static int TinhTongCacSoNguyenToNhoHonN(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                if (KiemTraSoNguyenTo(i))
                    sum += i;
            return sum;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // Để in chữ Tiếng Việt không bị lỗi
            int n;
            do
            {
                Console.Write("Nhập số nguyên dương n: ");
                n = int.Parse(Console.ReadLine());

                if (n <= 0)
                    Console.WriteLine("Số nguyên n phải lớn hơn 0. Vui lòng nhập lại.");
            }
            while (n <= 0);

            int TongNguyenTo = TinhTongCacSoNguyenToNhoHonN(n);
            Console.Write($"Tổng các số nguyên tố nhỏ hơn số nguyên n là: {TongNguyenTo}");
        }
    }
}
