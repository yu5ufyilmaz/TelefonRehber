using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehber
{
    
        
             class Directory
        {
            List<ListInformations> telephone_list = new List<ListInformations>();

            public void Sorular()
            {
                int num;
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) ");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine(" (3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine(" (5) Rehberde Arama Yapmak﻿");
                num = Convert.ToInt32(Console.ReadLine());
                if (num == 1)
                {
                    KayıtEtme();
                }
                else if (num == 2)
                {
                    Sil();
                }
                else if (num == 3)
                {
                    Güncelleme();
                }
                else if (num == 4)
                {
                    RehberListele();
                }
                else if (num == 5)
                {
                    Ara();
                }
                else
                {
                    throw new Exception("Sadece 1,2,3,4,5 yazabilirsiniz.");
                }

            }
            public void KayıtEtme()
            {
                ListInformations user = new ListInformations();
                Console.WriteLine(" Lütfen isim giriniz     :");
                string name = Console.ReadLine();
                Console.WriteLine("Lütfen soyisim giriniz          :      ");
                string surname = Console.ReadLine();
                Console.WriteLine("Lütfen telefon numarası giriniz :      ");
                long tel = Convert.ToInt64(Console.ReadLine());

                user.Name = name;
                user.Surname = surname;
                user.Tel = tel;
                telephone_list.Add(user);
                Sorular();
            }

            public void Sil()
            {
                Console.WriteLine(" Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                string info = Console.ReadLine();
                int count = 0;
                foreach (var i in telephone_list)
                {
                    if (info == i.Name || info.ToLower() == i.Name.ToLower() || info.ToUpper() == i.Name.ToUpper() || info == i.Surname || info.ToLower() == i.Surname.ToLower() || info.ToUpper() == i.Name.ToUpper())
                    {
                        Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)", i.Name + " " + i.Surname);
                        string think = Console.ReadLine();
                        if (think == "y")
                        {
                            int ia = telephone_list.IndexOf(i);
                            telephone_list.RemoveAt(ia);
                            Sorular();
                        }
                        if (think == "n")
                        {
                        Sorular();
                    }
                        count++;
                    }
                }
                if (count > 0)
                {
                    Console.WriteLine(" Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine(" * Silmeyi sonlandırmak için : (1)");
                    Console.WriteLine("  * Yeniden denemek için      : (2)");
                    int ans = Convert.ToInt32(Console.ReadLine());
                    if (ans == 1)
                    {
                    Sorular();
                }
                    else if (ans == 2)
                    {
                        Sil();
                    }
                    else { throw new Exception("1 ya da 2ye basın"); }
                }
            }
            public void Güncelleme()
            {
                Console.WriteLine("Numarasını güncellemek istediğiniz kişinin ismini ya da soyismini giriniz:");
                string name_or_surname = Console.ReadLine();
                int count = 0;
                foreach (var i in telephone_list)
                {
                    if (name_or_surname == i.Name || name_or_surname.ToLower() == i.Name.ToLower() || name_or_surname.ToUpper() == i.Name.ToUpper() || name_or_surname == i.Surname || name_or_surname.ToLower() == i.Surname.ToLower() ||
                        name_or_surname.ToUpper() == i.Name.ToUpper())
                    {
                        Console.WriteLine("Telefon numarası : " + i.Tel);
                        Console.WriteLine("Yeni numarayı giriniz");
                        long tel = Convert.ToInt64(Console.ReadLine());
                        i.Tel = tel;
                        count++;
                    Sorular();
                }
                }
                if (count == 0)
                {
                    Console.WriteLine(" Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("   * Güncellemeyi sonlandırmak için    : (1)");
                    Console.WriteLine("  * Yeniden denemek için              : (2)");
                    int ans = Convert.ToInt32(Console.ReadLine());
                    if (ans == 1)
                    {
                    Sorular();
                }
                    else if (ans == 2)
                    {
                       Güncelleme();
                    }
                    else { throw new Exception("1 ya da 2 yazın"); }
                }
            }
            public void RehberListele()
            {
                Console.WriteLine("Telefon Rehberi");
                Console.WriteLine("**********************************************");
                foreach (var i in telephone_list)
                {
                    Console.WriteLine("İsim: {0}", i.Name);
                    Console.WriteLine("Soyisim: {0}", i.Surname);
                    Console.WriteLine("Telefon Numarası: {0}", i.Tel);
                    Console.WriteLine("-");
                }
            Sorular();
        }
            public void Ara()
            {
                Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                Console.WriteLine("**********************************************");
                Console.WriteLine(" İsim veya soyisime göre arama yapmak için: (1)");
                Console.WriteLine(" Telefon numarasına göre arama yapmak için: (2)");
                int one_or_two = Convert.ToInt32(Console.ReadLine());
                int countLetter = 0;
                int countNum = 0;
                if (one_or_two == 1)
                {
                    Console.WriteLine("Aramak istediğiniz numara için ad veya soyad giriniz:");
                    string info = Console.ReadLine();
                    foreach (var i in telephone_list)
                    {
                        if (info == i.Name || info.ToLower() == i.Name.ToLower() || info.ToUpper() == i.Name.ToUpper() || info == i.Surname || info.ToLower() == i.Surname.ToLower() || info.ToUpper() == i.Name.ToUpper())
                        {
                            Console.WriteLine(" Arama Sonuçlarınız:");
                            Console.WriteLine("**********************************************");
                            Console.WriteLine("İsim: {0}", i.Name);
                            Console.WriteLine("Soyisim: {0}", i.Surname);
                            Console.WriteLine("Telefon numarası: {0}", i.Tel);
                            Console.WriteLine("-");
                            countLetter++;
                        Sorular();
                    }

                    }
                }
                else if (one_or_two == 2)
                {
                    Console.WriteLine("Aramak istediğiniz numara için ad veya soyad giriniz:");
                    long num = Convert.ToInt64(Console.ReadLine());
                    foreach (var i in telephone_list)
                    {
                        if (num == i.Tel)
                        {
                            Console.WriteLine(" Arama Sonuçlarınız:");
                            Console.WriteLine("**********************************************");
                            Console.WriteLine("İsim: {0}", i.Name);
                            Console.WriteLine("Soyisim: {0}", i.Surname);
                            Console.WriteLine("Telefon Numarası: {0}", i.Tel);
                            Console.WriteLine("-");
                        Sorular();
                    }
                    }

                }

                if (countLetter == 0)
                {
                    Console.WriteLine("Aradığınız kayıt bulunamadı.");
                }
                if (countNum == 0)
                {
                    Console.WriteLine("Aradığınız kayıt bulunamadı.");
                }
            }
        }
    }


        
    

