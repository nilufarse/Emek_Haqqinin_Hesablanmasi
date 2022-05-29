using System;
using System.Linq;

namespace emekHaqqi
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Deyisenler
            decimal netSalary = 0;
            decimal taxinAZN = 0;
            int tax = 0;
            int marriagePayment = 50;
            bool disabled = false;
            int childpayment = 0;
            decimal totalGrossMaas = 0;
            #endregion
            #region Sorgular
            Console.WriteLine("======================== Gelir hesablama proyekti ========================");
            Console.Write("Salam deyerli işçi . Xahiş edirik maaşınızı qeyd ediniz: ");
            int GrossMaas = int.Parse(Console.ReadLine());

            Console.WriteLine("Elil olub olmadığınızı qeyd ediniz : / He ya Yox");
            string disabledPerson = (Console.ReadLine().ToLower());
            if (disabledPerson == "he")
            {
                disabled = true;
            }
            else
            {
                disabled = false;
            }
            Console.Write("Aile veziyyetinizi qeyd ediniz : (E: evli, S: subay, D: dul): ");
            string status = (Console.ReadLine().ToLower());
            if (status != "s")
            {
                Console.WriteLine("Usağınız olub olmadığını qeyd edin : / He ya yox ");
                string childQuestion = Console.ReadLine();
                if (childQuestion != "yox")
                {

                    Console.Write("Neçe uşağınız olduğunu daxil ediniz : ");
                    int childCount = int.Parse(Console.ReadLine());

                    int startPayment = 35;

                    for (int i = 1; i <= childCount; i++)
                    {
                        if (i <= 3)
                        {
                            startPayment = startPayment - 5;
                        }
                        if (i > 3)
                        {
                            startPayment = 0;
                            childpayment = childpayment + 15;
                        }
                        childpayment = childpayment + startPayment;
                    }
                }
                else
                {
                    Console.WriteLine("Uşağınız olmadığı üçün elave ödeniş almırsınız . ");
                    Console.WriteLine("Usaq pulu : " + childpayment);
                }

                if (status == "d")
                {
                    marriagePayment = 0;
                    Console.WriteLine("Aile muavinati : " + marriagePayment);
                }
                else
                {
                    Console.WriteLine("Aile muavinati: " + marriagePayment);
                    Console.WriteLine("Usaq pulu : " + childpayment);
                }
            }

            else if (status == "s")
            {
                Console.WriteLine("Size aile müavinatı ödenilmir . ");
            }
            #endregion

            #region Hesablama
            Console.WriteLine("====================================================");

            totalGrossMaas = GrossMaas + childpayment + marriagePayment;

            if (disabled == true)
            {
                if (totalGrossMaas <= 1000)
                {
                    tax = 15;
                    tax = tax / 2;
                }
                else if (totalGrossMaas > 1000 && totalGrossMaas <= 2000)
                {
                    tax = 20;
                    tax = tax / 2;
                }
                else if (totalGrossMaas > 2000 && totalGrossMaas <= 3000)
                {
                    tax = 25;
                    tax = tax / 2;
                }
                else if (totalGrossMaas > 3000)
                {
                    tax = 30;
                    tax = tax / 2;
                }
            }
            else
            {
                if (totalGrossMaas <= 1000)
                {
                    tax = 15;
                }
                else if (totalGrossMaas > 1000 && totalGrossMaas <= 2000)
                {
                    tax = 20;
                }
                else if (totalGrossMaas > 2000 && totalGrossMaas <= 3000)
                {
                    tax = 25;
                }
                else if (totalGrossMaas > 3000)
                {
                    tax = 30;
                }
            }
            #endregion
            #region Ekrana Cap
            taxinAZN = Math.Round(((totalGrossMaas * tax / 100)), 2);
            netSalary = Math.Round((totalGrossMaas - taxinAZN), 2);
            Console.WriteLine("Vergi tetbiq olunmadan onceki maasiniz : " + totalGrossMaas + " AZN ");
            Console.WriteLine("elillik dereceniz üçün xalis maaşınız : " + netSalary + "AZN");
            Console.WriteLine("Maaşınıza tetbiq olunan vergi faizi : " + tax + "%");
            Console.WriteLine("Maaşınızdan çıxılan vergi : " + taxinAZN + "AZN");
            #endregion
            #region Odenis
            int[] banknot = { 200, 100, 50, 20, 10, 5, 1 };
            Console.WriteLine("Odenisinizi bu şekilde alacaqsiniz : ");
            Console.WriteLine("====================================================");
            for (int i = 0; i < banknot.Length; i++)
            {
                decimal qaliq = Math.Truncate((netSalary / banknot[i]));
                netSalary = netSalary - (qaliq * banknot[i]);
                if (qaliq == 0)
                {
                    Console.Write("\n");
                }
                else
                {
                    Console.WriteLine(qaliq + " Eded " + banknot[i] + " AZN verilecek .");
                }
            }

            #endregion
        }
    }
}
