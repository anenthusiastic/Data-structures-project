using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_2A_KarıncaSürüsü
{
    class Program
    {
        static char[] isimler = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V' };
        static void Main(string[] args)
        {
            int[] çukurlar = { 10, 15, 20 };
            int[] tuzaklar = { 6, 12, 17 };
            A_şıkkı();
            Console.ReadLine();
            B_şıkkı(3,çukurlar,tuzaklar);
            Console.ReadLine();
            E_şıkkı(3, çukurlar, tuzaklar);
            Console.ReadKey();

        }
        static void A_şıkkı()
        {
            Karınca[] ants = new Karınca[14];
            ants[0] = new Karınca('E', 1);
            ants[1] = new Karınca('D', 1);
            ants[2] = new Karınca('C', 1);
            ants[3] = new Karınca('B', 1);
            ants[4] = new Karınca('A', 1);

            KarıncaStack çukur1 = new KarıncaStack(3);
            KarıncaStack çukur2 = new KarıncaStack(2);
            KarıncaStack tuzak = new KarıncaStack(1);
            KarıncaStack çukur3 = new KarıncaStack(4);
            int karıncasayac = 5;
            int arka = 0;
            int sayac = 0;
            int ölenler = 0;
            Console.WriteLine("Karıncalar Harekete Başladı..");
            while(arka<13)
            {
                int ön = arka + karıncasayac - 1;

                while (ön >= arka && ön < ants.Length - 1)
                {
                    if (ants[ön] != null)
                    {
                        ants[ön + 1] = ants[ön];
                        if (ön + 1 == 13)
                        {
                            Console.WriteLine(ants[ön + 1].toString() + " varış noktasına ulaştı");
                            sayac++;
                            karıncasayac--;
                        }
                        if (ön + 1 == 6)
                        {
                            if (!çukur1.isFull())
                            {
                                çukur1.push(ants[ön + 1]);
                                Console.WriteLine(ants[ön + 1].toString() + " 1. çukura düştü.");
                                karıncasayac--;
                            }
                        }
                        if (ön + 1 == 8)
                        {
                            if (!çukur2.isFull())
                            {
                                çukur2.push(ants[ön + 1]);
                                Console.WriteLine(ants[ön + 1].toString() + " 2. çukura düştü.");
                                karıncasayac--;
                            }
                        }
                        if (ön + 1 == 10)
                        {
                            if (!tuzak.isFull())
                            {
                                tuzak.push(ants[ön + 1]);
                                Console.WriteLine(ants[ön + 1].toString() + " tuzağa düştü ve öldü.");
                                ants[ön + 1] = null;
                                karıncasayac--;
                                ölenler++;
                            }
                        }
                        if (ön + 1 == 12)
                        {
                            if (!çukur3.isFull())
                            {
                                çukur3.push(ants[ön + 1]);
                                Console.WriteLine(ants[ön + 1].toString() + " 3. çukura düştü.");
                                karıncasayac--;
                            }
                        }
                    }
                    
                    ön--;
                }
                ants[arka++] = null;
                if (ants[6] == null && !çukur1.isEmpty())
                {
                    ants[6] = çukur1.pop();
                    Console.WriteLine(ants[6].toString() + " 1. çukurdan çıktı.");
                    karıncasayac++;
                    arka--;
                }
                if (ants[8] == null && !çukur2.isEmpty())
                {
                    ants[8] = çukur2.pop();
                    Console.WriteLine(ants[8].toString() + " 2. çukurdan çıktı.");
                    karıncasayac++;
                    arka--;
                }
                if (ants[12] == null && !çukur3.isEmpty())
                {
                    ants[12] = çukur3.pop();
                    Console.WriteLine(ants[12].toString() + " 3. çukurdan çıktı.");
                    karıncasayac++;
                    arka--;
                }
            }
            Console.WriteLine("Toplam " + sayac + " karınca varışa ulaştı...");
        }

        static void B_şıkkı(int karıncasayısı,int[] çukurlar,int [] tuzaklar)
        {
            int köprüuzunluğu = Math.Max(çukurlar[çukurlar.Length - 1], tuzaklar[tuzaklar.Length - 1])+2;
            List<Karınca> köprü = new List<Karınca>(köprüuzunluğu);
            List<Karınca> ants = new List<Karınca>(karıncasayısı);
            for(int i = 0;i<karıncasayısı;i++)
            {
                Karınca karınca = new Karınca(isimler[i], 3);
                ants.Add(karınca);
            }
            for(int i =0; i < köprüuzunluğu; i++)
            {
                köprü.Add(null);
            }
            int[] çukurboyutları = new int[çukurlar.Length];
            Console.WriteLine("Çukurların boyutlarını index sırasıyla  giriniz.Her girdiden sonra enter'a basınız :");

            for(int i = 0; i <çukurlar.Length ; i++)
            {
                çukurboyutları[i] = Convert.ToInt16(Console.ReadLine());
            }

            KarıncaStack[] çukurdizi = new KarıncaStack[çukurlar.Length];
            for(int i = 0; i < çukurlar.Length; i++)
            {
                KarıncaStack çukur = new KarıncaStack(çukurboyutları[i]);
                çukurdizi[i] = çukur;
            }

            KarıncaStack [] tuzakdizi = new KarıncaStack[tuzaklar.Length];
            for(int i = 0; i < tuzaklar.Length; i++)
            {
                KarıncaStack tuzak = new KarıncaStack(1);
                tuzakdizi[i] = tuzak;
            }

            
            int karıncasayac = 0;
            int arka = 0;
            int ölenkarıncalar = 0;
            int gecenkarıncalar = 0;
            int ekle = 0;




            while (arka<köprüuzunluğu-1)
            {
                
                if (ekle < karıncasayısı)
                {
                    arka = 0;
                    köprü[0] = ants[ekle++];
                    karıncasayac++;
                }
                int ön = arka + karıncasayac - 1;

                while(ön>=arka && ön < köprüuzunluğu - 1)
                {
                    if(köprü[ön] != null)
                    {
                        köprü[ön + 1] = köprü[ön];
                        if (ön + 1 == köprüuzunluğu-1)
                        {
                            Console.WriteLine(köprü[ön + 1].toString() + " varış noktasına ulaştı");
                            gecenkarıncalar++;
                            karıncasayac--;
                        }
                        if (çukurlar.Contains(ön + 1))
                        {
                            if (!çukurdizi[Array.IndexOf(çukurlar, ön+1)].isFull())
                            {
                                int no = Array.IndexOf(çukurlar, ön + 1) + 1;
                                çukurdizi[Array.IndexOf(çukurlar, ön + 1)].push(köprü[ön + 1]);
                                karıncasayac--;
                                Console.WriteLine(köprü[ön + 1].toString() + " " + no + ". çukura düştü");
                                    
                            }
                            
                        }
                        else if (tuzaklar.Contains(ön + 1))
                        {
                            if (tuzakdizi[Array.IndexOf(tuzaklar, ön + 1)].isEmpty())
                            {
                                int no = Array.IndexOf(tuzaklar, ön + 1) + 1;
                                tuzakdizi[Array.IndexOf(tuzaklar, ön + 1)].push(köprü[ön + 1]);
                                Console.Write(köprü[ön + 1].toString() + " " + no + ". tuzağa düştü ve ");
                                köprü[ön + 1].Can--;
                                if (köprü[ön + 1].Can == 0)
                                {
                                    köprü[ön + 1] = null;
                                    ölenkarıncalar++;
                                    
                                    Console.Write("öldü");
                                }
                                else{ Console.Write( köprü[ön + 1].Can + " canı kaldı"); }
                                    
                                karıncasayac--;
                                Console.WriteLine();
                                
                            }
                        }
                    }
                    ön--;
                }
                köprü[arka] = null;
                if (çukurlar.Contains(arka))
                {
                    if (!çukurdizi[Array.IndexOf(çukurlar, arka)].isEmpty())
                    {
                        int no = Array.IndexOf(çukurlar, arka) + 1;
                        köprü[arka] = çukurdizi[Array.IndexOf(çukurlar, arka)].pop();
                        karıncasayac++;
                        Console.WriteLine(köprü[arka].toString() + " " + no + ". çukurdan çıktı");
                    }
                    else
                    {
                        arka++;
                    }
                }
                else if (tuzaklar.Contains(arka))
                {
                    if (tuzakdizi[Array.IndexOf(tuzaklar, arka)].isFull() && tuzakdizi[Array.IndexOf(tuzaklar, arka)].Kdizi[0].Can > 0)
                    {
                        int no = Array.IndexOf(tuzaklar, arka) + 1;
                        köprü[arka] = tuzakdizi[Array.IndexOf(tuzaklar, arka)].pop();
                        karıncasayac++;
                        Console.WriteLine(köprü[arka].toString() + " " + no + ". tuzaktan kurtuldu");
                    }
                    else
                    {
                        arka++;
                    }

                }
                else
                {
                    arka++;
                }
            }
            Console.WriteLine("Toplam " + karıncasayısı +" karıncadan "+gecenkarıncalar+ " tanesi varışa ulaştı.");
            Console.WriteLine(ölenkarıncalar + " tane karınca öldü.");
        }

        static void E_şıkkı(int karıncasayısı, int[] çukurlar, int[] tuzaklar)
        {
            int köprüuzunluğu = Math.Max(çukurlar[çukurlar.Length - 1], tuzaklar[tuzaklar.Length - 1]) + 2;
            ArrayList[] köprü = new ArrayList[köprüuzunluğu];
            for(int i = 0; i < köprüuzunluğu; i++)
            {
                köprü[i] = new ArrayList();
            }

            List<Karınca> ants = new List<Karınca>(karıncasayısı);
            for (int i = 0; i< karıncasayısı; i++)
            {
                Karınca karınca = new Karınca(isimler[i], 3);
                ants.Add(karınca);
            }
            List<Karınca> arı = new List<Karınca> { new Karınca('W',4), new Karınca('X', 4), new Karınca('Y', 4), new Karınca('Z', 4) };

            List<Karınca> yaban =new List<Karınca> { new Karınca('K', 5), new Karınca('L', 5), new Karınca('M', 5) };

            int[] çukurboyutları = new int[çukurlar.Length];
            Console.WriteLine("Çukurların boyutlarını index sırasıyla  giriniz.Her girdiden sonra enter'a basınız :");

            for (int i = 0; i < çukurlar.Length; i++)
            {
                çukurboyutları[i] = Convert.ToInt16(Console.ReadLine());
            }

            KarıncaStack[] çukurdizi = new KarıncaStack[çukurlar.Length];
            for (int i = 0; i < çukurlar.Length; i++)
            {
                KarıncaStack çukur = new KarıncaStack(çukurboyutları[i]);
                çukurdizi[i] = çukur;
            }

            KarıncaStack[] tuzakdizi = new KarıncaStack[tuzaklar.Length];
            for (int i = 0; i < tuzaklar.Length; i++)
            {
                KarıncaStack tuzak = new KarıncaStack(1);
                tuzakdizi[i] = tuzak;
            }

            int karıncasayac = 0; ;
            int arka = 0;
            int ölenkarıncalar = 0;
            int gecenkarıncalar = 0;
            int eklekarınca = 0;

            int arısayac = 0 ;
            int arkaarı = köprüuzunluğu - 1;
            int ölenarı = 0;
            int gecenarılar = 0;
            int eklearı = 0;

            int yabansayac = 0;
            int ölenyaban = 0;
            int gecenyaban = 0;
            int ekleyaban = 0;
            int canlısayac = karıncasayısı + 7;

            Karınca sağyaban1 = yaban[0];
            Karınca solyaban = yaban[1];
            Karınca sağyaban2 = yaban[2];
            Console.WriteLine("Yaban arılarının ekleneceği indexi giriniz :");
            int yabanindex = Convert.ToInt16(Console.ReadLine());
            int sağyaban1index = yabanindex;
            int sağyaban2index = yabanindex;
            int solyabanindex = yabanindex ;
            bool sağyaban1düştü = false;
            bool sağyaban2düştü = false;
            bool solyabandüştü = false;
            int sayac = 0;
            ArrayList geçenler = new ArrayList();
            while (gecenarılar+gecenkarıncalar+gecenyaban+ölenarı+ölenkarıncalar+ölenyaban < canlısayac )//ölenler ve geçenlerin toplamı canlısayısına eşit olduğunda program biter
            {
                //hayvanların köprüye katılmaları
                if (eklekarınca < karıncasayısı)
                {
                    arka = 0;
                    köprü[0].Add(ants[eklekarınca++]);
                    karıncasayac++;
                }

                if (eklearı < 4)
                {
                    arkaarı = köprüuzunluğu - 1;
                    köprü[köprüuzunluğu - 1].Add(arı[eklearı++]);
                    arısayac++;
                }
                if (ekleyaban <3)
                {
                    if(ekleyaban == 0)
                    {
                        köprü[sağyaban1index].Add(sağyaban1);
                    }
                    else if(ekleyaban == 1)
                    {
                        köprü[solyabanindex].Add(solyaban);
                    }
                    else { köprü[sağyaban2index].Add(sağyaban2); }
                    yabansayac++;
                    ekleyaban++;
                }
                //karıncaların adımlaması
                int önkarınca = arka + karıncasayac - 1;
                int yeniön = önkarınca + 1;
                 
                while(önkarınca >= arka && önkarınca < köprüuzunluğu - 1 && karıncasayac>0)
                {
                    
                    if (köprü[önkarınca].Count == 1)
                    {
                        köprü[önkarınca + 1].Add(köprü[önkarınca][0]);
                        köprü[önkarınca].RemoveAt(0);

                        if (önkarınca+1 == köprüuzunluğu - 1)
                        {
                            Console.WriteLine(((Karınca)köprü[önkarınca + 1][0]).toString() + " varış noktasına ulaştı");
                            gecenkarıncalar++;
                            karıncasayac--;

                            geçenler.Add(köprü[önkarınca + 1][0]);
                            köprü[önkarınca + 1].RemoveAt(0);
                        }
                    }
                    önkarınca--;
                }

                //birbirlerini öldürme
                for (int i = 0; i < köprüuzunluğu; i++)
                {
                    if (köprü[i].Count == 2)
                    {
                        int zayıf = Math.Min(((Karınca)köprü[i][0]).Can, ((Karınca)köprü[i][1]).Can);
                        ((Karınca)köprü[i][0]).Can -= zayıf;
                        ((Karınca)köprü[i][1]).Can -= zayıf;

                        if (((Karınca)köprü[i][0]).Can == 0 && ((Karınca)köprü[i][1]).Can == 0)
                        {

                            Console.WriteLine(((Karınca)köprü[i][0]).toString() + " ve " + ((Karınca)köprü[i][1]).toString() + " birbirlerini öldürdüler");

                            if (((Karınca)köprü[i][0]).Isim == 'W' || ((Karınca)köprü[i][0]).Isim == 'X' || ((Karınca)köprü[i][0]).Isim == 'Y' || ((Karınca)köprü[i][0]).Isim == 'Z')
                            {
                                arısayac--;
                                ölenarı++;
                                if (ölenarı + gecenarılar == 4)
                                {
                                    arkaarı = köprüuzunluğu - 1;
                                }
                            }
                            else if (((Karınca)köprü[i][0]).Isim == 'K' || ((Karınca)köprü[i][0]).Isim == 'L' || ((Karınca)köprü[i][0]).Isim == 'M')
                            {
                                yabansayac--;
                                ölenyaban++;
                                if (((Karınca)köprü[i][0]).Isim == 'K')
                                {
                                    sağyaban1index = köprüuzunluğu - 1;
                                }
                                if (((Karınca)köprü[i][0]).Isim == 'L')
                                {
                                    solyabanindex = 0;
                                }
                                if (((Karınca)köprü[i][0]).Isim == 'M')
                                {
                                    sağyaban2index = köprüuzunluğu - 1;
                                }
                            }
                            else
                            {
                                karıncasayac--;
                                ölenkarıncalar++;
                                if (ölenkarıncalar + gecenkarıncalar == karıncasayısı)
                                {
                                    arka = 0;
                                }
                            }

                            if (((Karınca)köprü[i][1]).Isim == 'W' || ((Karınca)köprü[i][1]).Isim == 'X' || ((Karınca)köprü[i][1]).Isim == 'Y' || ((Karınca)köprü[i][1]).Isim == 'Z')
                            {
                                arısayac--;
                                ölenarı++;
                                if (ölenarı + gecenarılar == 4)
                                {
                                    arkaarı = köprüuzunluğu - 1;
                                }
                            }
                            else if (((Karınca)köprü[i][1]).Isim == 'K' || ((Karınca)köprü[i][1]).Isim == 'L' || ((Karınca)köprü[i][1]).Isim == 'M')
                            {
                                yabansayac--;
                                ölenyaban++;
                                if (((Karınca)köprü[i][1]).Isim == 'K')
                                {
                                    sağyaban1index = köprüuzunluğu - 1;
                                }
                                if (((Karınca)köprü[i][1]).Isim == 'L')
                                {
                                    solyabanindex = 0;
                                }
                                if (((Karınca)köprü[i][1]).Isim == 'M')
                                {
                                    sağyaban2index = köprüuzunluğu - 1;
                                }

                            }
                            else
                            {
                                karıncasayac--;
                                ölenkarıncalar++;
                                if (ölenkarıncalar + gecenkarıncalar == karıncasayısı)
                                {
                                    arka = 0;
                                }
                            }
                            köprü[i].Clear();
                        }

                        else if (((Karınca)köprü[i][1]).Can == 0)
                        {
                            Console.WriteLine(((Karınca)köprü[i][1]).toString() + " , " + ((Karınca)köprü[i][0]).toString() + " tarafından öldürüldü");

                            if (((Karınca)köprü[i][1]).Isim == 'W' || ((Karınca)köprü[i][1]).Isim == 'X' || ((Karınca)köprü[i][1]).Isim == 'Y' || ((Karınca)köprü[i][1]).Isim == 'Z')
                            {
                                arısayac--;
                                ölenarı++;
                                if (ölenarı + gecenarılar == 4)
                                {
                                    arkaarı = köprüuzunluğu - 1;
                                }
                            }
                            else if (((Karınca)köprü[i][1]).Isim == 'K' || ((Karınca)köprü[i][1]).Isim == 'L' || ((Karınca)köprü[i][1]).Isim == 'M')
                            {
                                yabansayac--;
                                ölenyaban++;
                                if (((Karınca)köprü[i][1]).Isim == 'K')
                                {
                                    sağyaban1index = köprüuzunluğu - 1;
                                }
                                if (((Karınca)köprü[i][1]).Isim == 'L')
                                {
                                    solyabanindex = 0;
                                }
                                if (((Karınca)köprü[i][1]).Isim == 'M')
                                {
                                    sağyaban2index = köprüuzunluğu - 1;
                                }

                            }
                            else
                            {
                                karıncasayac--;
                                ölenkarıncalar++;
                                if (ölenkarıncalar + gecenkarıncalar == karıncasayısı)
                                {
                                    arka = 0;
                                }
                            }
                            köprü[i].RemoveAt(1);
                        }

                        else
                        {

                            Console.WriteLine(((Karınca)köprü[i][0]).toString() + " , " + ((Karınca)köprü[i][1]).toString() + " tarafından öldürüldü");

                            if (((Karınca)köprü[i][0]).Isim == 'W' || ((Karınca)köprü[i][0]).Isim == 'X' || ((Karınca)köprü[i][0]).Isim == 'Y' || ((Karınca)köprü[i][0]).Isim == 'Z')
                            {
                                arısayac--;
                                ölenarı++;
                                if (ölenarı + gecenarılar == 4)
                                {
                                    arkaarı = köprüuzunluğu - 1;
                                }
                            }
                            else if (((Karınca)köprü[i][0]).Isim == 'K' || ((Karınca)köprü[i][0]).Isim == 'L' || ((Karınca)köprü[i][0]).Isim == 'M')
                            {
                                yabansayac--;
                                ölenyaban++;
                                if (((Karınca)köprü[i][0]).Isim == 'K')
                                {
                                    sağyaban1index = köprüuzunluğu - 1;
                                }
                                if (((Karınca)köprü[i][0]).Isim == 'L')
                                {
                                    solyabanindex = 0;
                                }
                                if (((Karınca)köprü[i][0]).Isim == 'M')
                                {
                                    sağyaban2index = köprüuzunluğu - 1;
                                }
                            }
                            else
                            {
                                karıncasayac--;
                                ölenkarıncalar++;
                            }
                            köprü[i].RemoveAt(0);
                        }

                    }
                }
                //arıların adımlaması
                int önarı = arkaarı - arısayac + 1;
                int yeniönarı = önarı - 1;

                while (önarı<=arkaarı && önarı > 0 && arısayac>0)
                {
                    if(köprü[önarı].Count == 1)
                    {
                        köprü[önarı - 1].Add(köprü[önarı][0]);
                        köprü[önarı].RemoveAt(0);
                        
                        
                        if(önarı -1==0)
                        {
                            Console.WriteLine(((Karınca)köprü[önarı - 1][0]).toString() + " varış noktasına ulaştı");
                            gecenarılar++;
                            arısayac--;

                            geçenler.Add(köprü[önarı - 1][0]);
                            köprü[0].RemoveAt(0);
                        }
                    }
                    önarı++;
                }
                //birbirlerini öldürme
                for (int i = 0; i < köprüuzunluğu; i++)
                {
                    if (köprü[i].Count == 2)
                    {
                        int zayıf = Math.Min(((Karınca)köprü[i][0]).Can, ((Karınca)köprü[i][1]).Can);
                        ((Karınca)köprü[i][0]).Can -= zayıf;
                        ((Karınca)köprü[i][1]).Can -= zayıf;

                        if (((Karınca)köprü[i][0]).Can == 0 && ((Karınca)köprü[i][1]).Can == 0)
                        {

                            Console.WriteLine(((Karınca)köprü[i][0]).toString() + " ve " + ((Karınca)köprü[i][1]).toString() + " birbirlerini öldürdüler");

                            if (((Karınca)köprü[i][0]).Isim == 'W' || ((Karınca)köprü[i][0]).Isim == 'X' || ((Karınca)köprü[i][0]).Isim == 'Y' || ((Karınca)köprü[i][0]).Isim == 'Z')
                            {
                                arısayac--;
                                ölenarı++;
                                if (ölenarı + gecenarılar == 4)
                                {
                                    arkaarı = köprüuzunluğu - 1;
                                }
                            }
                            else if (((Karınca)köprü[i][0]).Isim == 'K' || ((Karınca)köprü[i][0]).Isim == 'L' || ((Karınca)köprü[i][0]).Isim == 'M')
                            {
                                yabansayac--;
                                ölenyaban++;
                                if (((Karınca)köprü[i][0]).Isim == 'K')
                                {
                                    sağyaban1index = köprüuzunluğu - 1;
                                }
                                if (((Karınca)köprü[i][0]).Isim == 'L')
                                {
                                    solyabanindex = 0;
                                }
                                if (((Karınca)köprü[i][0]).Isim == 'M')
                                {
                                    sağyaban2index = köprüuzunluğu - 1;
                                }
                            }
                            else
                            {
                                karıncasayac--;
                                ölenkarıncalar++;
                                if (ölenkarıncalar + gecenkarıncalar == karıncasayısı)
                                {
                                    arka = 0;
                                }
                            }

                            if (((Karınca)köprü[i][1]).Isim == 'W' || ((Karınca)köprü[i][1]).Isim == 'X' || ((Karınca)köprü[i][1]).Isim == 'Y' || ((Karınca)köprü[i][1]).Isim == 'Z')
                            {
                                arısayac--;
                                ölenarı++;
                                if (ölenarı + gecenarılar == 4)
                                {
                                    arkaarı = köprüuzunluğu - 1;
                                }
                            }
                            else if (((Karınca)köprü[i][1]).Isim == 'K' || ((Karınca)köprü[i][1]).Isim == 'L' || ((Karınca)köprü[i][1]).Isim == 'M')
                            {
                                yabansayac--;
                                ölenyaban++;
                                if (((Karınca)köprü[i][1]).Isim == 'K')
                                {
                                    sağyaban1index = köprüuzunluğu - 1;
                                }
                                if (((Karınca)köprü[i][1]).Isim == 'L')
                                {
                                    solyabanindex = 0;
                                }
                                if (((Karınca)köprü[i][1]).Isim == 'M')
                                {
                                    sağyaban2index = köprüuzunluğu - 1;
                                }

                            }
                            else
                            {
                                karıncasayac--;
                                ölenkarıncalar++;
                                if (ölenkarıncalar + gecenkarıncalar == karıncasayısı)
                                {
                                    arka = 0;
                                }
                            }
                            köprü[i].Clear();
                        }

                        else if (((Karınca)köprü[i][1]).Can == 0)
                        {
                            Console.WriteLine(((Karınca)köprü[i][1]).toString() + " , " + ((Karınca)köprü[i][0]).toString() + " tarafından öldürüldü");

                            if (((Karınca)köprü[i][1]).Isim == 'W' || ((Karınca)köprü[i][1]).Isim == 'X' || ((Karınca)köprü[i][1]).Isim == 'Y' || ((Karınca)köprü[i][1]).Isim == 'Z')
                            {
                                arısayac--;
                                ölenarı++;
                                if (ölenarı + gecenarılar == 4)
                                {
                                    arkaarı = köprüuzunluğu - 1;
                                }
                            }
                            else if (((Karınca)köprü[i][1]).Isim == 'K' || ((Karınca)köprü[i][1]).Isim == 'L' || ((Karınca)köprü[i][1]).Isim == 'M')
                            {
                                yabansayac--;
                                ölenyaban++;
                                if(((Karınca)köprü[i][1]).Isim == 'K')
                                {
                                    sağyaban1index = köprüuzunluğu - 1;
                                }
                                if(((Karınca)köprü[i][1]).Isim == 'L')
                                {
                                    solyabanindex = 0;
                                }
                                if(((Karınca)köprü[i][1]).Isim == 'M')
                                {
                                    sağyaban2index = köprüuzunluğu - 1;
                                }

                            }
                            else
                            {
                                karıncasayac--;
                                ölenkarıncalar++;
                                if (ölenkarıncalar + gecenkarıncalar == karıncasayısı)
                                {
                                    arka = 0;
                                }
                            }
                            köprü[i].RemoveAt(1);
                        }

                        else
                        {

                            Console.WriteLine(((Karınca)köprü[i][0]).toString() + " , " + ((Karınca)köprü[i][1]).toString() + " tarafından öldürüldü");

                            if (((Karınca)köprü[i][0]).Isim == 'W' || ((Karınca)köprü[i][0]).Isim == 'X' || ((Karınca)köprü[i][0]).Isim == 'Y' || ((Karınca)köprü[i][0]).Isim == 'Z')
                            {
                                arısayac--;
                                ölenarı++;
                                if (ölenarı + gecenarılar == 4)
                                {
                                    arkaarı = köprüuzunluğu - 1;
                                }
                            }
                            else if (((Karınca)köprü[i][0]).Isim == 'K' || ((Karınca)köprü[i][0]).Isim == 'L' || ((Karınca)köprü[i][0]).Isim == 'M')
                            {
                                yabansayac--;
                                ölenyaban++;
                                if (((Karınca)köprü[i][0]).Isim == 'K')
                                {
                                    sağyaban1index = köprüuzunluğu - 1;
                                }
                                if (((Karınca)köprü[i][0]).Isim == 'L')
                                {
                                    solyabanindex = 0;
                                }
                                if (((Karınca)köprü[i][0]).Isim == 'M')
                                {
                                    sağyaban2index = köprüuzunluğu - 1;
                                }
                            }
                            else
                            {
                                karıncasayac--;
                                ölenkarıncalar++;
                                if (ölenkarıncalar + gecenkarıncalar == karıncasayısı)
                                {
                                    arka = 0;
                                }
                            }
                            köprü[i].RemoveAt(0);
                        }

                    }
                }

                //yabanarılarının tuzak ve çukurlardan çıkması
                if (çukurlar.Contains(sağyaban1index) && sağyaban1düştü && köprü[sağyaban1index].Count == 0 && köprü[sağyaban1index - 1].Count == 0)
                {
                    if (!çukurdizi[Array.IndexOf(çukurlar, sağyaban1index)].isEmpty())
                    {
                        int no = Array.IndexOf(çukurlar, sağyaban1index) + 1;
                        Karınca yabanarısı = çukurdizi[Array.IndexOf(çukurlar, sağyaban1index)].pop();
                        if(yabanarısı.Isim == 'K' || yabanarısı.Isim == 'M')
                        {
                            köprü[sağyaban1index].Add(yabanarısı);
                            yabansayac++;
                            Console.WriteLine(yabanarısı.toString() + " " + no + ". çukurdan çıktı");
                            if (yabanarısı.Isim == 'K') sağyaban1düştü = false;
                            if (yabanarısı.Isim == 'M') sağyaban2düştü = false;

                        }
                        else{çukurdizi[Array.IndexOf(çukurlar, sağyaban1index)].push(yabanarısı);}
                    }
                }

                if (çukurlar.Contains(sağyaban2index) && sağyaban2düştü && köprü[sağyaban2index].Count == 0 && köprü[sağyaban2index - 1].Count == 0)
                {
                    if (!çukurdizi[Array.IndexOf(çukurlar, sağyaban2index)].isEmpty())
                    {
                        int no = Array.IndexOf(çukurlar, sağyaban2index) + 1;
                        Karınca yabanarısı = çukurdizi[Array.IndexOf(çukurlar, sağyaban2index)].pop();
                        if (yabanarısı.Isim == 'K' || yabanarısı.Isim == 'M')
                        {
                            köprü[sağyaban2index].Add(yabanarısı);
                            yabansayac++;
                            Console.WriteLine(yabanarısı.toString() + " " + no + ". çukurdan çıktı");
                            if (yabanarısı.Isim == 'K') sağyaban1düştü = false;
                            if (yabanarısı.Isim == 'M') sağyaban2düştü = false;
                        }
                        else { çukurdizi[Array.IndexOf(çukurlar, sağyaban2index)].push(yabanarısı); }
                    }


                }

                if (çukurlar.Contains(solyabanindex) && solyabandüştü && köprü[solyabanindex].Count == 0 )
                {
                    if (!çukurdizi[Array.IndexOf(çukurlar, solyabanindex)].isEmpty())
                    {
                        int no = Array.IndexOf(çukurlar, solyabanindex) + 1;
                        Karınca yabanarısı = çukurdizi[Array.IndexOf(çukurlar, solyabanindex)].pop();
                        if(yabanarısı.Isim == 'L')
                        {
                            köprü[solyabanindex].Add(yabanarısı);
                            yabansayac++;
                            Console.WriteLine(yabanarısı.toString() + " " + no + ". çukurdan çıktı");
                            solyabandüştü = false;
                        }
                        else
                        {
                            çukurdizi[Array.IndexOf(çukurlar, solyabanindex)].push(yabanarısı);
                        }
                    }


                }

                if (tuzaklar.Contains(sağyaban1index) && sağyaban1düştü && köprü[sağyaban1index].Count == 0 && köprü[sağyaban1index - 1].Count == 0)
                {
                    if (tuzakdizi[Array.IndexOf(tuzaklar, sağyaban1index)].isFull() && sağyaban1.Can > 0)
                    {
                        int no = Array.IndexOf(tuzaklar, sağyaban1index) + 1;
                        Karınca yabanarısı = tuzakdizi[Array.IndexOf(tuzaklar, sağyaban1index)].pop();
                        if (yabanarısı.Isim == 'K' || yabanarısı.Isim == 'M')
                        {
                            köprü[sağyaban1index].Add(yabanarısı);
                            yabansayac++;
                            Console.WriteLine(yabanarısı.toString() + " " + no + ". tuzaktan kurtuldu");
                            if (yabanarısı.Isim == 'K') sağyaban1düştü = false;
                            if (yabanarısı.Isim == 'M') sağyaban2düştü = false;

                        }
                        else { tuzakdizi[Array.IndexOf(tuzaklar, sağyaban1index)].push(yabanarısı); }
                           
                    }
                }

                if (tuzaklar.Contains(sağyaban2index) && sağyaban2düştü && köprü[sağyaban2index].Count == 0 && köprü[sağyaban2index - 1].Count == 0)
                {
                    if (tuzakdizi[Array.IndexOf(tuzaklar, sağyaban2index)].isFull() && sağyaban2.Can > 0)
                    {
                        int no = Array.IndexOf(tuzaklar, sağyaban2index) + 1;
                        Karınca yabanarısı = tuzakdizi[Array.IndexOf(tuzaklar, sağyaban2index)].pop();
                        if (yabanarısı.Isim == 'K' || yabanarısı.Isim == 'M')
                        {
                            köprü[sağyaban2index].Add(yabanarısı);
                            yabansayac++;
                            Console.WriteLine(yabanarısı.toString() + " " + no + ". tuzaktan kurtuldu");
                            if (yabanarısı.Isim == 'K') sağyaban1düştü = false;
                            if (yabanarısı.Isim == 'M') sağyaban2düştü = false;

                        }
                        else { tuzakdizi[Array.IndexOf(tuzaklar, sağyaban2index)].push(yabanarısı); }    
                    }
                }

                if (tuzaklar.Contains(solyabanindex) && solyabandüştü && köprü[solyabanindex].Count == 0 && köprü[solyabanindex - 1].Count == 0)
                {
                    if (tuzakdizi[Array.IndexOf(tuzaklar, solyabanindex)].isFull() && solyaban.Can > 0)
                    {
                        int no = Array.IndexOf(tuzaklar, solyabanindex) + 1;
                        Karınca yabanarısı = tuzakdizi[Array.IndexOf(tuzaklar, solyabanindex)].pop();
                        if(yabanarısı.Isim == 'L')
                        {
                            köprü[solyabanindex].Add(yabanarısı);
                            yabansayac++;
                            Console.WriteLine(yabanarısı.toString() + " " + no + ". tuzaktan kurtuldu");
                            solyabandüştü = false;

                        }
                        else { tuzakdizi[Array.IndexOf(tuzaklar, solyabanindex)].push(yabanarısı); }
                    }
                }

                //yabanarılarının adımlaması
                
                if (ekleyaban>=1 && sağyaban1index < köprüuzunluğu - 1 && !sağyaban1düştü && sağyaban1.Can > 0)
                    {
                        köprü[sağyaban1index + 1].Add(sağyaban1);
                        köprü[sağyaban1index++].Remove(sağyaban1);
                        if (sağyaban1index == köprüuzunluğu - 1)
                        {
                            Console.WriteLine(sağyaban1.toString() + " varışa ulaştı");
                            yabansayac--;
                            gecenyaban++;
                            köprü[sağyaban1index].Remove(sağyaban1);
                            geçenler.Add(sağyaban1);
                        }
                    }    


                if (ekleyaban>=3 && sağyaban2index < köprüuzunluğu - 1 && !sağyaban2düştü && sağyaban2.Can > 0)
                {
                        köprü[sağyaban2index + 1].Add(sağyaban2);
                        köprü[sağyaban2index++].Remove(sağyaban2);

                        if (sağyaban2index == köprüuzunluğu - 1)
                        {
                            Console.WriteLine(sağyaban2.toString() + " varışa ulaştı");
                            yabansayac--;
                            gecenyaban++;
                            köprü[sağyaban2index].Remove(sağyaban2);
                            geçenler.Add(sağyaban2);
                        }
                }

                if (ekleyaban>=2 && solyabanindex > 0 && !solyabandüştü && solyaban.Can != 0)
                {
                        köprü[solyabanindex - 1].Add(solyaban);
                        köprü[solyabanindex--].Remove(solyaban);
                        if (solyabanindex == 0)
                        {
                            Console.WriteLine(solyaban.toString() + " varışa ulaştı");
                            yabansayac--;
                            gecenyaban++;
                            köprü[solyabanindex].Remove(solyaban);
                            geçenler.Add(solyaban);
                        }
                }


                

                //birbirlerini öldürme durumları
                for (int i = 0; i < köprüuzunluğu; i++)
                {
                    if (köprü[i].Count == 2)
                    {
                        int zayıf = Math.Min(((Karınca)köprü[i][0]).Can, ((Karınca)köprü[i][1]).Can);
                        ((Karınca)köprü[i][0]).Can -= zayıf;
                        ((Karınca)köprü[i][1]).Can -= zayıf;

                        if (((Karınca)köprü[i][0]).Can == 0 && ((Karınca)köprü[i][1]).Can == 0)
                        {

                            Console.WriteLine(((Karınca)köprü[i][0]).toString() + " ve " + ((Karınca)köprü[i][1]).toString() + " birbirlerini öldürdüler");
                            
                            if (((Karınca)köprü[i][0]).Isim == 'W' || ((Karınca)köprü[i][0]).Isim == 'X' || ((Karınca)köprü[i][0]).Isim == 'Y' || ((Karınca)köprü[i][0]).Isim == 'Z')
                            {
                                arısayac--;
                                ölenarı++;
                                if (ölenarı + gecenarılar == 4)
                                {
                                    arkaarı = köprüuzunluğu - 1;
                                }
                            }
                            else if (((Karınca)köprü[i][0]).Isim == 'K' || ((Karınca)köprü[i][0]).Isim == 'L' || ((Karınca)köprü[i][0]).Isim == 'M')
                            {
                                yabansayac--;
                                ölenyaban++;
                                if (((Karınca)köprü[i][0]).Isim == 'K')
                                {
                                    sağyaban1index = köprüuzunluğu - 1;
                                }
                                if (((Karınca)köprü[i][0]).Isim == 'L')
                                {
                                    solyabanindex = 0;
                                }
                                if (((Karınca)köprü[i][0]).Isim == 'M')
                                {
                                    sağyaban2index = köprüuzunluğu - 1;
                                }
                            }
                            else
                            {
                                karıncasayac--;
                                ölenkarıncalar++;
                                if (ölenkarıncalar + gecenkarıncalar == karıncasayısı)
                                {
                                    arka = 0;
                                }
                            }

                            if (((Karınca)köprü[i][1]).Isim == 'W' || ((Karınca)köprü[i][1]).Isim == 'X' || ((Karınca)köprü[i][1]).Isim == 'Y' || ((Karınca)köprü[i][1]).Isim == 'Z')
                            {
                                arısayac--;
                                ölenarı++;
                                if (ölenarı + gecenarılar == 4)
                                {
                                    arkaarı = köprüuzunluğu - 1;
                                }
                            }
                            else if (((Karınca)köprü[i][1]).Isim == 'K' || ((Karınca)köprü[i][1]).Isim == 'L' || ((Karınca)köprü[i][1]).Isim == 'M')
                            {
                                yabansayac--;
                                ölenyaban++;
                                if (((Karınca)köprü[i][1]).Isim == 'K')
                                {
                                    sağyaban1index = köprüuzunluğu - 1;
                                }
                                if (((Karınca)köprü[i][1]).Isim == 'L')
                                {
                                    solyabanindex = 0;
                                }
                                if (((Karınca)köprü[i][1]).Isim == 'M')
                                {
                                    sağyaban2index = köprüuzunluğu - 1;
                                }

                            }
                            else
                            {
                                karıncasayac--;
                                ölenkarıncalar++;
                                if (ölenkarıncalar + gecenkarıncalar == karıncasayısı)
                                {
                                    arka = 0;
                                }
                            }
                            köprü[i].Clear();
                        }

                        else if (((Karınca)köprü[i][1]).Can == 0)
                        { 
                            Console.WriteLine(((Karınca)köprü[i][1]).toString() + " , " + ((Karınca)köprü[i][0]).toString() + " tarafından öldürüldü");
                            
                            if (((Karınca)köprü[i][1]).Isim == 'W' || ((Karınca)köprü[i][1]).Isim == 'X' || ((Karınca)köprü[i][1]).Isim == 'Y' || ((Karınca)köprü[i][1]).Isim == 'Z')
                            {
                                arısayac--;
                                ölenarı++;
                                if (ölenarı + gecenarılar == 4)
                                {
                                    arkaarı = köprüuzunluğu - 1;
                                }
                            }
                            else if (((Karınca)köprü[i][1]).Isim == 'K' || ((Karınca)köprü[i][1]).Isim == 'L' || ((Karınca)köprü[i][1]).Isim == 'M')
                            {
                                yabansayac--;
                                ölenyaban++;
                                if (((Karınca)köprü[i][1]).Isim == 'K')
                                {
                                    sağyaban1index = köprüuzunluğu - 1;
                                }
                                if (((Karınca)köprü[i][1]).Isim == 'L')
                                {
                                    solyabanindex = 0;
                                }
                                if (((Karınca)köprü[i][1]).Isim == 'M')
                                {
                                    sağyaban2index = köprüuzunluğu - 1;
                                }

                            }
                            else
                            {
                                karıncasayac--;
                                ölenkarıncalar++;
                                if (ölenkarıncalar + gecenkarıncalar == karıncasayısı)
                                {
                                    arka = 0;
                                }
                            }
                            köprü[i].RemoveAt(1);
                        }

                        else
                        {

                            Console.WriteLine(((Karınca)köprü[i][0]).toString() + " , " + ((Karınca)köprü[i][1]).toString() + " tarafından öldürüldü");

                            if (((Karınca)köprü[i][0]).Isim == 'W' || ((Karınca)köprü[i][0]).Isim == 'X' || ((Karınca)köprü[i][0]).Isim == 'Y' || ((Karınca)köprü[i][0]).Isim == 'Z')
                            {
                                arısayac--;
                                ölenarı++;
                                if (ölenarı + gecenarılar == 4)
                                {
                                    arkaarı = köprüuzunluğu - 1;
                                }
                            }
                            else if (((Karınca)köprü[i][0]).Isim == 'K' || ((Karınca)köprü[i][0]).Isim == 'L' || ((Karınca)köprü[i][0]).Isim == 'M')
                            {
                                yabansayac--;
                                ölenyaban++;
                                if (((Karınca)köprü[i][0]).Isim == 'K')
                                {
                                    sağyaban1index = köprüuzunluğu - 1;
                                }
                                if (((Karınca)köprü[i][0]).Isim == 'L')
                                {
                                    solyabanindex = 0;
                                }
                                if (((Karınca)köprü[i][0]).Isim == 'M')
                                {
                                    sağyaban2index = köprüuzunluğu - 1;
                                }
                            }
                            else
                            {
                                karıncasayac--;
                                ölenkarıncalar++;
                                if (ölenkarıncalar + gecenkarıncalar == karıncasayısı)
                                {
                                    arka = 0;
                                }
                            }
                            köprü[i].RemoveAt(0);
                        }

                    }
                }
                //karıncaların çukur ve tuzaklara düşmesi
                yeniön = karıncasayac + arka;
                if (çukurlar.Contains(yeniön) && köprü[yeniön].Count!=0 && !(((Karınca)köprü[yeniön][0]).Isim == 'K' || ((Karınca)köprü[yeniön][0]).Isim == 'L' || ((Karınca)köprü[yeniön][0]).Isim == 'M' || ((Karınca)köprü[yeniön][0]).Isim == 'W' || ((Karınca)köprü[yeniön][0]).Isim == 'Y' || ((Karınca)köprü[yeniön][0]).Isim == 'Z'))
                {
                    if (!çukurdizi[Array.IndexOf(çukurlar, yeniön)].isFull())
                    {
                        int no = Array.IndexOf(çukurlar, yeniön) + 1;
                        çukurdizi[Array.IndexOf(çukurlar, yeniön)].push((Karınca)köprü[yeniön][0]);
                        
                        karıncasayac--;
                        Console.WriteLine(((Karınca)köprü[yeniön][0]).toString() + " " + no + ". çukura düştü");
                        köprü[yeniön].RemoveAt(0);
                    }

                }
                else if (tuzaklar.Contains(yeniön) && köprü[yeniön].Count != 0)
                {
                    if (tuzakdizi[Array.IndexOf(tuzaklar, yeniön)].isEmpty())
                    {
                        int no = Array.IndexOf(tuzaklar, yeniön) + 1;
                        tuzakdizi[Array.IndexOf(tuzaklar, yeniön)].push((Karınca)köprü[yeniön][0]);
                        
                        Console.Write(((Karınca)köprü[yeniön][0]).toString() + " " + no + ". tuzağa düştü ve ");
                        ((Karınca)köprü[yeniön][0]).Can--;
                        if (((Karınca)köprü[yeniön][0]).Can == 0)
                        {
                            
                            ölenkarıncalar++;
                            if (ölenkarıncalar + gecenkarıncalar == karıncasayısı)
                            {
                                arka = 0;
                            }
                            Console.Write("öldü");
                        }
                        else { Console.Write(((Karınca)köprü[yeniön][0]).Can + " canı kaldı"); }
                        köprü[yeniön].RemoveAt(0);
                        karıncasayac--;
                        
                        Console.WriteLine();

                    }
                }

                //arıların çukur ve tuzaklara düşmesi
                yeniönarı = arkaarı - arısayac;
                
                if (çukurlar.Contains(yeniönarı) && köprü[yeniönarı].Count !=0 && (((Karınca)köprü[yeniönarı][0]).Isim =='W' || ((Karınca)köprü[yeniönarı][0]).Isim == 'X' || ((Karınca)köprü[yeniönarı][0]).Isim == 'Y' || ((Karınca)köprü[yeniönarı][0]).Isim == 'Z'))
                {
                    if (!çukurdizi[Array.IndexOf(çukurlar, yeniönarı)].isFull())
                    {
                        int no = Array.IndexOf(çukurlar, yeniönarı) + 1;
                        çukurdizi[Array.IndexOf(çukurlar, yeniönarı)].push((Karınca)köprü[yeniönarı][0]);
                        arısayac--;
                        Console.WriteLine(((Karınca)köprü[yeniönarı][0]).toString() + " " + no + ". çukura düştü");
                        köprü[yeniönarı].RemoveAt(0);
                    }
                }
                else if (tuzaklar.Contains(yeniönarı) && köprü[yeniönarı].Count != 0)
                {
                    if (tuzakdizi[Array.IndexOf(tuzaklar, yeniönarı)].isEmpty())
                    {
                        int no = Array.IndexOf(tuzaklar, yeniönarı) + 1;
                        tuzakdizi[Array.IndexOf(tuzaklar, yeniönarı)].push((Karınca)köprü[yeniönarı][0]);
                        Console.Write(((Karınca)köprü[yeniönarı][0]).toString() + " " + no + ". tuzağa düştü ve ");
                        ((Karınca)köprü[yeniönarı][0]).Can--;
                        if (((Karınca)köprü[yeniönarı][0]).Can == 0)
                        {
                            
                            ölenarı++;
                            if (ölenarı + gecenarılar == 4)
                            {
                                arkaarı = köprüuzunluğu - 1;
                            }
                            Console.Write("öldü");
                        }
                        else { Console.Write(((Karınca)köprü[yeniönarı][0]).Can + " canı kaldı"); }

                        arısayac--;
                        köprü[yeniönarı].RemoveAt(0);
                        Console.WriteLine();

                    }
                }

                //yabanarılarının çukur ve tuzaklara düşmesi
                if (çukurlar.Contains(sağyaban1index) && !sağyaban1düştü)
                {

                    if (!çukurdizi[Array.IndexOf(çukurlar, sağyaban1index)].isFull())
                    {
                        int no = Array.IndexOf(çukurlar, sağyaban1index) + 1;
                        çukurdizi[Array.IndexOf(çukurlar, sağyaban1index)].push(sağyaban1);
                        Console.WriteLine(sağyaban1.toString() + " " + no + ". çukura düştü");
                        yabansayac--;
                        köprü[sağyaban1index].Remove(sağyaban1);
                        sağyaban1düştü = true;
                    }
                }

                else if (tuzaklar.Contains(sağyaban1index) && !sağyaban1düştü)
                {
                    if (tuzakdizi[Array.IndexOf(tuzaklar, sağyaban1index)].isEmpty())
                    {
                        int no = Array.IndexOf(tuzaklar, sağyaban1index) + 1;
                        tuzakdizi[Array.IndexOf(tuzaklar, sağyaban1index)].push(sağyaban1);
                        
                        Console.Write(sağyaban1.toString() + " " + no + ". tuzağa düştü ve ");
                        sağyaban1.Can--;
                        if (sağyaban1.Can == 0)
                        {
                            
                            ölenyaban++;
                            köprü[sağyaban1index].Remove(sağyaban1);
                            sağyaban1index = köprüuzunluğu - 1;
                            Console.Write("öldü");
                        }
                        else
                        {
                            Console.Write(sağyaban1.Can + " canı kaldı");
                            köprü[sağyaban1index].Remove(sağyaban1);
                        }

                        yabansayac--;
                        sağyaban1düştü = true;
                        Console.WriteLine();

                    }
                }

                if (çukurlar.Contains(sağyaban2index) && !sağyaban2düştü)
                {

                    if (!çukurdizi[Array.IndexOf(çukurlar, sağyaban2index)].isFull())
                    {
                        int no = Array.IndexOf(çukurlar, sağyaban2index) + 1;
                        çukurdizi[Array.IndexOf(çukurlar, sağyaban2index)].push(sağyaban2);
                        Console.WriteLine(sağyaban2.toString() + " " + no + ". çukura düştü");
                        yabansayac--;
                        köprü[sağyaban2index].Remove(sağyaban2);
                        sağyaban2düştü = true;
                    }
                }
                else if (tuzaklar.Contains(sağyaban2index) && !sağyaban2düştü)
                {
                    if (tuzakdizi[Array.IndexOf(tuzaklar, sağyaban2index)].isEmpty())
                    {
                        int no = Array.IndexOf(tuzaklar, sağyaban2index) + 1;
                        tuzakdizi[Array.IndexOf(tuzaklar, sağyaban2index)].push(sağyaban2);
                        
                        Console.Write(sağyaban2.toString() + " " + no + ". tuzağa düştü ve ");
                        sağyaban2.Can--;
                        if (sağyaban2.Can == 0)
                        {

                            ölenyaban++;
                            köprü[sağyaban2index].Remove(sağyaban2);
                            sağyaban2index = köprüuzunluğu - 1;
                            Console.Write("öldü");
                        }
                        else
                        {
                            Console.Write(sağyaban2.Can + " canı kaldı");
                            köprü[sağyaban2index].Remove(sağyaban2);
                        }

                        yabansayac--;
                        sağyaban2düştü = true;
                        Console.WriteLine();

                    }
                }
                if (çukurlar.Contains(solyabanindex) &&  !solyabandüştü)
                {

                    if (!çukurdizi[Array.IndexOf(çukurlar, solyabanindex)].isFull())
                    {
                        int no = Array.IndexOf(çukurlar, solyabanindex) + 1;
                        çukurdizi[Array.IndexOf(çukurlar, solyabanindex)].push(solyaban);
                        Console.WriteLine(solyaban.toString() + " " + no + ". çukura düştü");
                        yabansayac--;
                        köprü[solyabanindex].Remove(solyaban);
                        solyabandüştü = true;
                    }
                }
                else if (tuzaklar.Contains(solyabanindex) && !solyabandüştü)
                {
                    if (tuzakdizi[Array.IndexOf(tuzaklar, solyabanindex)].isEmpty())
                    {
                        int no = Array.IndexOf(tuzaklar, solyabanindex) + 1;
                        tuzakdizi[Array.IndexOf(tuzaklar, solyabanindex)].push(solyaban);
                        
                        Console.Write(solyaban.toString() + " " + no + ". tuzağa düştü ve ");
                        solyaban.Can--;
                        if (solyaban.Can == 0)
                        {

                            ölenyaban++;
                            köprü[solyabanindex].Remove(solyaban);
                            solyabanindex = 0;
                            Console.Write("öldü");
                        }
                        else
                        {
                            Console.Write(solyaban.Can + " canı kaldı");
                            köprü[solyabanindex].Remove(solyaban);
                        }

                        yabansayac--;
                        solyabandüştü = true;
                        Console.WriteLine();

                    }
                }

                //karıncaların çukur ve tuzaklardan çıkması

                if (çukurlar.Contains(arka) && köprü[arka].Count ==0 )
                {
                    if (!çukurdizi[Array.IndexOf(çukurlar, arka)].isEmpty())
                    {
                        int no = Array.IndexOf(çukurlar, arka) + 1;
                        Karınca hayvan = çukurdizi[Array.IndexOf(çukurlar, arka)].pop();
                        if (hayvan.Isim == 'W' || hayvan.Isim == 'X' || hayvan.Isim == 'Y' || hayvan.Isim == 'Z' || hayvan.Isim == 'K' || hayvan.Isim == 'L' || hayvan.Isim == 'M')
                        {
                            çukurdizi[Array.IndexOf(çukurlar, arka)].push(hayvan);
                            arka++;
                            if (çukurlar.Contains(arka - 1) && karıncasayac == 0)
                            {
                                arka--;
                            }
                        }
                        else
                        {
                            köprü[arka].Add( hayvan);
                            karıncasayac++;
                            Console.WriteLine(((Karınca)köprü[arka][0]).toString() + " " + no + ". çukurdan çıktı");

                        }
                    }
                    else
                    {
                        arka++;
                    }
                }

                else if (tuzaklar.Contains(arka) && köprü[arka].Count == 0)
                {
                    if (tuzakdizi[Array.IndexOf(tuzaklar, arka)].isFull() && tuzakdizi[Array.IndexOf(tuzaklar, arka)].Kdizi[0].Can > 0)
                    {
                        int no = Array.IndexOf(tuzaklar, arka) + 1;
                        Karınca hayvan = tuzakdizi[Array.IndexOf(tuzaklar, arka)].pop();
                        if (hayvan.Isim == 'W' || hayvan.Isim == 'X' || hayvan.Isim == 'Y' || hayvan.Isim == 'Z' || hayvan.Isim == 'K' || hayvan.Isim == 'L' || hayvan.Isim == 'M')
                        {
                            tuzakdizi[Array.IndexOf(tuzaklar, arka)].push(hayvan);
                            arka++;
                        }
                        else
                        {
                            köprü[arka].Add(hayvan);
                            karıncasayac++;
                            Console.WriteLine(((Karınca)köprü[arka][0]).toString() + " " + no + ". tuzaktan kurtuldu");

                        }
                        
                    }
                    else{arka++;}
                }

                else
                {
                    arka++;
                    if (tuzaklar.Contains(arka - 1) && karıncasayac == 0)
                    {
                        arka--;
                    }
                    else if (çukurlar.Contains(arka - 1) && karıncasayac == 0)
                    {
                        arka--;
                    }
                }
                //arıların çukur ve tuzaklardan çıkması
                if (çukurlar.Contains(arkaarı) && köprü[arkaarı].Count == 0)
                {
                    if (!çukurdizi[Array.IndexOf(çukurlar, arkaarı)].isEmpty())
                    {
                        int no = Array.IndexOf(çukurlar, arkaarı) + 1;
                        Karınca hayvan = çukurdizi[Array.IndexOf(çukurlar, arkaarı)].pop();
                        if(hayvan.Isim == 'W' || hayvan.Isim == 'X' || hayvan.Isim == 'Y' || hayvan.Isim == 'Z')
                        {
                            köprü[arkaarı].Add(hayvan);
                            arısayac++;
                            Console.WriteLine(((Karınca)köprü[arkaarı][0]).toString() + " " + no + ". çukurdan çıktı");
                        }
                        else
                        {
                            çukurdizi[Array.IndexOf(çukurlar, arkaarı)].push(hayvan);
                            arkaarı--;
                            if (çukurlar.Contains(arkaarı + 1) && arısayac == 0)
                            {
                                arkaarı++;
                            }
                        }

                        
                    }
                    else
                    {
                        arkaarı--;
                    }
                }
                else if (tuzaklar.Contains(arkaarı) && köprü[arkaarı].Count == 0)
                {
                    if (tuzakdizi[Array.IndexOf(tuzaklar, arkaarı)].isFull() && tuzakdizi[Array.IndexOf(tuzaklar, arkaarı)].Kdizi[0].Can > 0)
                    {
                        int no = Array.IndexOf(tuzaklar, arkaarı) + 1;
                        Karınca hayvan = tuzakdizi[Array.IndexOf(tuzaklar, arkaarı)].pop();
                        if (hayvan.Isim == 'W' || hayvan.Isim == 'X' || hayvan.Isim == 'Y' || hayvan.Isim == 'Z')
                        {
                            köprü[arkaarı].Add(hayvan);
                            arısayac++;
                            Console.WriteLine(((Karınca)köprü[arkaarı][0]).toString() + " " + no + ". tuzaktan kurtuldu");
                        }
                        else { tuzakdizi[Array.IndexOf(tuzaklar, arkaarı)].push(hayvan); arkaarı--; }
                    }
                    else
                    {
                        arkaarı--;
                    }

                }
                else
                {
                    arkaarı--;
                    if(tuzaklar.Contains(arkaarı+1) && arısayac == 0)
                    {
                        arkaarı++;
                    }
                    else if(çukurlar.Contains(arkaarı+1) && arısayac == 0)
                    {
                        arkaarı++;
                    }
                }

                if (ölenkarıncalar + gecenkarıncalar == karıncasayısı)
                {
                    arka = 0;
                }
                if (ölenarı + gecenarılar == 4)
                {
                    arkaarı = köprüuzunluğu-1 ;
                }
                sayac++;
            }
            Console.WriteLine(gecenkarıncalar + " tane karınca ," + gecenarılar + " tane arı ," + gecenyaban + " tane yabanarısı karşıya geçti");
            Console.WriteLine(ölenkarıncalar + " tane karınca ," + ölenarı + " tane arı ," + ölenyaban + " tane yabanarısı öldüler");
            Console.WriteLine();
            Console.WriteLine("Karşıya Geçenlerin Sıralı Listesi");
            for(int i= 0; i < geçenler.Count; i++)
            {
                int no = i + 1;
                Console.WriteLine(no + ")\t" + ((Karınca)geçenler[i]).toString());
            }
            
        }
    }

    class Karınca
    {
        char isim;
        int can;

        public Karınca(char isim,int can)
        {
            this.Isim = isim;
            this.Can = can;
        }

        public string toString()
        {
            if(this.isim == 'W' || this.isim == 'X' || this.isim == 'Y' || this.isim == 'Z')
            {
                return "Arı " + this.isim;
            }
            if(this.isim == 'K' || this.isim == 'L'|| this.isim == 'M')
            {
                return "Yaban Arısı " + this.isim;
            }
            return "Karınca " + this.isim;
        }
        public char Isim { get => isim; set => isim = value; }
        public int Can { get => can; set => can = value; }
    }

    class KarıncaStack
    {
        Karınca[] kdizi;
        int count;

        internal Karınca[] Kdizi { get => kdizi; set => kdizi = value; }

        public KarıncaStack(int length)
        {
            Kdizi = new Karınca[length];
            count = 0;
        }

        public void push(Karınca karınca)
        {
            Kdizi[count++] = karınca;
        }

        public Karınca pop()
        {
            if(count != 0)
            {
                Karınca temp = Kdizi[--count];
                return temp;
            }
            return null;
        }

        public bool isEmpty()
        {
            return count == 0;
        }

        public bool isFull()
        {
            return count == Kdizi.Length;
        }
    }
}
