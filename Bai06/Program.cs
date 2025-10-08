using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bai06
{
    internal class Program
    {
        // Hàm tạo ma trận ngẫu nhiên
        static int[,] TaoMaTranNgauNhien(int SoHang, int SoCot, int min, int max)
        {
            Random rand = new Random();
            int[,] arr = new int[SoHang, SoCot];
            for (int i = 0; i < SoHang; i++)
            {
                for (int j = 0; j < SoCot; j++)
                    arr[i, j] = rand.Next(min, max + 1);
            }
            return arr;
        }

        // Hàm xuất ma trận
        static void XuatMaTran(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(arr[i, j] + "\t");
                Console.WriteLine();
            }
        }

        // Hàm tìm phần tử lớn nhất trong ma trận
        static int TimPhanTuLonNhat(int[,] arr)
        {
            int max = arr[0, 0];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] > max)
                        max = arr[i, j];
            }
            return max; 
        }

        // Hàm tìm phần tử nhỏ nhất trong ma trận
        static int TimPhanTuNhoNhat(int[,] arr)
        {
            int min = arr[0, 0];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] < min)
                        min = arr[i, j];
            }
            return min;
        }

        // Hàm tìm dòng có tổng lớn nhất trong ma trận
        static int TimDongCoTongLonNhat(int[,] arr)
        {
            int TongDongLonNhat = int.MinValue;
            int DongLonNhat = 0;                        // Gán chỉ số dòng lớn nhất = 0
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int TongDong = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                    TongDong += arr[i, j];
                if (TongDong > TongDongLonNhat)
                {
                    TongDongLonNhat = TongDong;
                    DongLonNhat = i;
                }
            }
            return DongLonNhat;
        }

        // Hàm kiểm tra số nguyên tố của 1 số nguyên
        static bool KiemTraSoNguyenTo(int n)
        {
            if (n < 2) 
                return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        // Hàm tính tổng các số không phải là số nguyên tố của 1 ma trận
        static int TinhTongKhongPhaiSoNguyenTo(int[,] arr)
        {
            int TongKoPhaiNgTo = 0;                       // Gán chỉ số dòng lớn nhất = 0
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (!KiemTraSoNguyenTo(arr[i, j]))
                        TongKoPhaiNgTo += arr[i, j];
            }  
            return TongKoPhaiNgTo;
        }

        // Hàm xóa dòng thứ k trong ma trận
        static int[,] XoaDongThuK(int[,] arr, int k, int SoHang, int SoCot)
        {
            int[,] MangSauKhiXoa = new int[SoHang - 1, SoCot];
            int DongMoi = 0;

            for (int i = 0; i < SoHang; i++)
            {
                if (i == k) continue; // Bỏ qua dòng k
                for (int j = 0; j < SoCot; j++)
                    MangSauKhiXoa[DongMoi, j] = arr[i, j];
                DongMoi++;
            }
            return MangSauKhiXoa;
        }

        // Hàm xóa cột có phần tử lớn nhất trong ma trận
        static int[,] XoaCotCoPhanTuLonNhat(int[,] arr, int SoHang, int SoCot)
        {
            int ViTriLonNhat = 0;
            for (int i = 0; i < SoHang; i++)
            {
                for (int j = 0; j < SoCot; j++)
                    if (arr[i, j] == TimPhanTuLonNhat(arr))
                        ViTriLonNhat = j;
            }

            int[,] MangSauKhiXoa = new int[SoHang, SoCot - 1];
            for (int i = 0; i < SoHang; i++)
            {
                int CotMoi = 0;
                for (int j = 0; j < SoCot; j++)
                {
                    if (j == ViTriLonNhat) continue; // Bỏ qua cột có vị trí lớn nhât
                    MangSauKhiXoa[i, CotMoi] = arr[i, j];
                    CotMoi++;
                }
            }
            return MangSauKhiXoa;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;     // Để in chữ Tiếng Việt không bị lỗi
            int SoHang, SoCot;
            do
            {
                Console.Write("Nhập số hàng: ");
                SoHang = int.Parse(Console.ReadLine());

                if (SoHang <= 0)
                    Console.WriteLine("Số hàng phải lớn hơn 0. Vui lòng nhập lại.");
            }
            while (SoHang <= 0);

            do
            {
                Console.Write("Nhập số cột: ");
                SoCot = int.Parse(Console.ReadLine());

                if (SoCot <= 0)
                    Console.WriteLine("Số cột phải lớn hơn 0. Vui lòng nhập lại.");
            }
            while (SoCot <= 0);

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

            int[,] arr = TaoMaTranNgauNhien(SoHang, SoCot , GTDau, GTCuoi);

            // Câu 6a
            Console.Write("\nMa trận được tạo: \n");
            XuatMaTran(arr);     // In ra các phần tử của mảng

            // Câu 6b
            Console.Write($"Phần tử lớn nhất là: {TimPhanTuLonNhat(arr)}\n");
            Console.Write($"Phần tử nhỏ nhất là: {TimPhanTuNhoNhat(arr)}\n");

            // Câu 6c
            Console.Write($"Dòng có tổng lớn nhất là: {TimDongCoTongLonNhat(arr)}\n");

            // Câu 6d
            Console.Write($"Tổng các số không phải là số nguyên tố là: {TinhTongKhongPhaiSoNguyenTo(arr)}\n");

            // Câu 6e
            int k;
            do
            {
                Console.Write("Nhập hàng cần xóa: ");
                k = int.Parse(Console.ReadLine());

                if (k < 0 || k >= SoHang)
                    Console.WriteLine($"Số chỉ của hàng trong khoảng từ 0 đến {SoHang - 1}. Vui lòng nhập lại.");
            }
            while (k < 0 || k >= SoHang);
            Console.Write($"Ma trận sau khi xóa dòng thứ {k} là: \n");
            XuatMaTran(XoaDongThuK(arr, k, SoHang, SoCot));

            // Câu 6f
            Console.Write($"Ma trận sau khi xóa cột chứa phần tử lớn nhất {TimPhanTuLonNhat(arr)} trong ma trận là: \n");
            XuatMaTran(XoaCotCoPhanTuLonNhat(arr, SoHang, SoCot));
        }
    }
}
