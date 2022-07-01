using MvcWepApp2.DAL;
using MvcWepApp2.Models.Abstrack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcWepApp2.Models
{
    public class DersProgrami: ModelBase
    {
        SqlDataProcess data;
        public DersProgrami()
        {
            data = new SqlDataProcess();
        }

        public int SinifId { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public string DersAdi { get; set; }
        public string OgretmenKodu { get; set; }
        public string SinifAdi { get; set; }
        public List<DersProgrami> ListeGetir()
        {

           


            DataTable dtDersprogrami = data.GetExecuteDataTable("DersProgrami_Getir", CommandType.StoredProcedure,
            new SqlParameter("@OgretmenCode",OgretmenKodu));


            List<DersProgrami> dersprogrami = new List<DersProgrami>();

            foreach (DataRow dataRow in dtDersprogrami.Rows)
            {
                dersprogrami.Add(new DersProgrami
                {
                    Id= Convert.ToInt32(dataRow["Id"]),
                    SinifId =Convert.ToInt32(dataRow["SinifId"]),
                    Baslangic =Convert.ToDateTime(dataRow["Baslangic"]),
                    Bitis = Convert.ToDateTime(dataRow["Bitis"]),
                    DersAdi = dataRow["DersAdi"].ToString(),
                    SinifAdi = dataRow["SinifAdi"].ToString(),
                   

                });
            }
            return dersprogrami;
        }

        public bool Ekle()
        {
            try
            {
                return data.SetExecuteNonQuery("Insert into DersProgrami (Baslangic,Bitis,DersAdi) values(@baslangic, @bitis,@dersAdi)",
                    CommandType.Text,
                    new SqlParameter("@baslangic", Baslangic),
                    new SqlParameter("@bitis", Bitis),
                    new SqlParameter("@dersAdi", DersAdi)

                    );
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
