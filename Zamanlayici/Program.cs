using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamanlayici.Gorevler;

namespace Zamanlayici
{
    class Program
    {
        static void Main(string[] args)
        {
            int müşteriNumarası = 15000000;

            ÇalıştırmaMotoru.KomutÇalıştır("MuhasebeModulu", "MaaşYatır", new object[] { müşteriNumarası });

            ÇalıştırmaMotoru.KomutÇalıştır("MuhasebeModulu", "YıllıkÜcretTahsilEt", new object[] { müşteriNumarası });

            ÇalıştırmaMotoru.BekleyenİşlemleriGerçekleştir();
            
        }

        public class ÇalıştırmaMotoru
        {

            public static object[] KomutÇalıştır(string modülSınıfAdı, string methodAdı, object[] inputs)
            {
                Veritabanıİşlemleri db = new Veritabanıİşlemleri();
                if(db.Ertelenenİşlem(methodAdı).Equals(true))
                {
                    db.BekleyenİşlemEkle(inputs,methodAdı);
                }
                else
                {
                    if (modülSınıfAdı.Equals("MuhasebeModulu"))
                    {
                        MuhasebeModülü modül = new MuhasebeModülü();
                        modül.MethodÇağır(methodAdı, Convert.ToInt32(inputs[0]));
                    }
                }
                return inputs;
            }

            public static void BekleyenİşlemleriGerçekleştir()
            {
                Tetikleyici tetikle = new Tetikleyici();
                tetikle.GoreviTetikle();
            }
        }

        public class MuhasebeModülü
        {
            private void MaaşYatır(int müşteriNumarası)
            {
                // gerekli işlemler gerçekleştirilir.
                Console.WriteLine(string.Format("{0} numaralı müşterinin maaşı yatırıldı.", müşteriNumarası));
            }

            private void YıllıkÜcretTahsilEt(int müşteriNumarası)
            {
                // gerekli işlemler gerçekleştirilir.
                Console.WriteLine("{0} numaralı müşteriden yıllık kart ücreti tahsil edildi.", müşteriNumarası);
            }

            private void OtomatikÖdemeleriGerçekleştir(int müşteriNumarası)
            {
                // gerekli işlemler gerçekleştirilir.
                Console.WriteLine("{0} numaralı müşterinin otomatik ödemeleri gerçekleştirildi.", müşteriNumarası);
            }

            public void MethodÇağır(string methodAdı, int inputs)
            {
                if(methodAdı.Equals("MaaşYatır"))
                    MaaşYatır(inputs);
                else if (methodAdı.Equals("YıllıkÜcretTahsilEt"))
                    YıllıkÜcretTahsilEt(inputs);
            }
        }

        public class Veritabanıİşlemleri
        {
            public bool Ertelenenİşlem(string methodAdı)
            {
                bool ertelenen = false;

                //Maaş yatırma ve yıllık ücret tahsil etme işlemleri için parametre tablosundan işlemin
                //ertelenip ertelenmeyeceğini belirten değer çekilir. Ertelenme durumunda true döner.

                return ertelenen;
            }

            public object[] Bekleyenİşlemler()
            {
                object[] müşteriNo = null;
                //Bekleyen işlemler için müşteri numaralarını döner.
                return müşteriNo;
            }

            public void BekleyenİşlemEkle(object müşteriNumarası,string methodAdı)
            {
                //Bekleyen işleme kayıt eklenir.
            }
        }
    }
}
