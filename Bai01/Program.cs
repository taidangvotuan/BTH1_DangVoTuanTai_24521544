using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bai01
{
    internal class Program
    {
        // Hàm tạo mảng 1 chiều ngẫu nhiên
        static int[] TaoMangNgauNhien(int n, int min, int max)
        {
            Random rand = new Random();
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
                arr[i] = rand.Next(min, max + 1);

            return arr;
        }

        // Hàm chia mod cho số nguyên
        static int mod(int a, int b)
        {
            int r = a % b;
            return r < 0 ? r + b : r;
        }

        // Hàm tính tổng các số lẻ trong mảng
        static int TinhTongCacSoLeTrongMang(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
                if (mod(arr[i], 2) != 0)
                    sum += arr[i];
            return sum;
        }

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

        // Hàm đếm số lượng số nguyên tố trong mảng
        static int DemSoNguyenToTrongMang(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
                if (KiemTraSoNguyenTo(arr[i]))
                    count++;
            return count;
        }

        // Hàm kiểm tra số chính phương của 1 số nguyên dương
        static bool KiemTraSoChinhPhuong(int n)
        {
            if (n == (int)Math.Sqrt(n) * (int)Math.Sqrt(n))
                return true;
            else
                return false;
        }

        // Hàm tìm số chính phương nhỏ nhất trong mảng
        static int TimSoChinhPhuongNhoNhat(int[] arr)
        {
            int min = 0, dem = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (KiemTraSoChinhPhuong(arr[i]) == true)
                {
                    dem++;
                    if (min == 0)
                        min = arr[i];
                }
            }
            Console.OutputEncoding = Encoding.UTF8;
            if (dem == 0)
            {
                Console.WriteLine("Mảng không có số chính phương nào");
                return -1;
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (KiemTraSoChinhPhuong(arr.Length) == true)
                    {
                        if (min > arr.Length)
                            min = arr.Length;
                    }
                }
            }
            return min;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;     // Để in chữ Tiếng Việt không bị lỗi
            int SoPhanTu;
            do
            {
                Console.Write("Nhập số phần tử của mảng: ");
                SoPhanTu = int.Parse(Console.ReadLine());

                if (SoPhanTu <= 0)
                    Console.WriteLine("Số lượng phần tử phải lớn hơn 0. Vui lòng nhập lại.");
            }
            while (SoPhanTu <= 0);

            int GTDau, GTCuoi;
            do
            {
                Console.Write("Nhập giá trị đầu: ");
                GTDau = int.Parse(Console.ReadLine());

                Console.Write("Nhập giá trị cuối: ");
                GTCuoi = int.Parse(Console.ReadLine());

                if (GTCuoi < GTDau)
                    Console.WriteLine("Giá trị cuối phải lớn hơn hoặc bằng giá trị đầu. Vui lòng nhập lại.");
            }
            while (GTCuoi < GTDau);

            int[] arr = TaoMangNgauNhien(SoPhanTu, GTDau, GTCuoi);

            Console.Write("\nMảng được tạo: ");
            Console.WriteLine("[" + string.Join(", ", arr) + "]");     // In ra các phần tử của mảng

            // Bài 1a
            int Tong = TinhTongCacSoLeTrongMang(arr);
            Console.Write($"Tổng các số lẻ trong mảng là: {Tong}\n");

            // Bài 1b
            int SoLuongNguyenTo = DemSoNguyenToTrongMang(arr);
            Console.Write($"Số các số nguyên tố trong mảng là: {SoLuongNguyenTo}\n");

            // Bài 1c
            int SoChinhPhuongNhoNhat = TimSoChinhPhuongNhoNhat(arr);
            Console.Write($"Số chính phương nhỏ nhất trong mảng là: {SoChinhPhuongNhoNhat}");
        }
    }
}
