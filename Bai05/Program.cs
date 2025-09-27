using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Bai05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;     // Để in chữ Tiếng Việt không bị lỗi
            byte Ngay, Thang;
            short Nam;
            do
            {
                Console.Write("Nhập ngày: ");
                Ngay = byte.Parse(Console.ReadLine());
                if (Ngay <= 0 || Ngay > 31)
                    Console.WriteLine("Ngày phải nằm trong khoảng từ 1 đến 31. Vui lòng nhập lại.");
            }
            while (Ngay <= 0 || Ngay > 31);

            do
            {
                Console.Write("Nhập tháng: ");
                Thang = byte.Parse(Console.ReadLine());
                if (Thang <= 0 || Thang > 12)
                    Console.WriteLine("Tháng phải nằm trong khoảng từ 1 đến 12. Vui lòng nhập lại.");
            }
            while (Thang <= 0 || Thang > 12);

            do
            {
                Console.Write("Nhập năm: ");
                Nam = short.Parse(Console.ReadLine());
                if (Nam <= 0)
                    Console.WriteLine("Năm phải lớn hơn 0. Vui lòng nhập lại.");
            }
            while (Nam <= 0);

            DateTime date = new DateTime(Nam, Thang, Ngay);

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine($"Ngày {Ngay}/{Thang}/{Nam} là ngày Thứ hai");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine($"Ngày {Ngay}/{Thang}/{Nam} là ngày Thứ ba");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine($"Ngày {Ngay}/{Thang}/{Nam} là ngày Thứ tư");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine($"Ngày {Ngay}/{Thang}/{Nam} là ngày Thứ năm");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine($"Ngày {Ngay}/{Thang}/{Nam} là ngày Thứ sáu");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine($"Ngày {Ngay}/{Thang}/{Nam} là ngày Thứ bảy");
                    break;
                case DayOfWeek.Sunday:
                    Console.WriteLine($"Ngày {Ngay}/{Thang}/{Nam} là ngày Chủ nhật");
                    break;
            }
        }
    }
}
