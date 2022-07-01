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
    public class Ogretmen: ModelBase
    {
        SqlDataProcess data;
        public Ogretmen()
        {
            data=new SqlDataProcess();
        }
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Code { get; set; }
        public string Sifre { get; set; }
        public Sinif _Sinif { get; set; }

        public List<Ogretmen> ListeGetir()
        {
            List<Ogretmen> ogretmenler = new List<Ogretmen>();


            DataTable dtOgretmenler = data.GetExecuteDataTable("Ogretmen_ListeGetir", CommandType.StoredProcedure);


            foreach (DataRow dataRow in dtOgretmenler.Rows)
            {
                ogretmenler.Add(new Ogretmen
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    Adi = dataRow["Adi"].ToString(),
                    Soyadi = dataRow["Soyadi"].ToString(),
                    Code = dataRow["Code"].ToString(),
                    _Sinif = new Sinif
                    {
                        Adi = dataRow["SinifAdi"].ToString(),
                        Kodu = dataRow["SinifKodu"].ToString()
                    }

                });
            }
            return ogretmenler;
        }
        public bool Ekle()
        {
            try
            {
                data.SetExecuteNonQuery("Insert into Ogretmen (Adi, Soyadi, Code, SinifId) values(@ad, @soyad, @code, @sinifid)",
                    CommandType.Text,
                    new SqlParameter("@ad",Adi),
                    new SqlParameter("@soyad",Soyadi),
                    new SqlParameter("@code",Code),
                    new SqlParameter("@sinifid",_Sinif.Id)
                    );

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Sil()
        {
            try
            {
                return data.SetExecuteNonQuery("Delete from Ogretmen where Id=@id", CommandType.Text,
                    new SqlParameter("@id", Id));
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Ogretmen OgretmenGetirId()
        {
            DataTable dt = data.GetExecuteDataTable("Ogretmen_Getir", CommandType.StoredProcedure, new SqlParameter("@id", Id));
            Ogretmen _ogretmen = new Ogretmen();
            if (dt.Rows.Count > 0)
            {
                _ogretmen.Id = dt.Rows[0].Field<int>("Id");
                _ogretmen.Adi = dt.Rows[0].Field<string>("Adi");
                _ogretmen.Soyadi = dt.Rows[0].Field<string>("Soyadi");
                _ogretmen.Code = dt.Rows[0].Field<string>("Code");
                _ogretmen._Sinif = new Sinif { Adi = dt.Rows[0].Field<string>("SinifAdi") };
            }

            return _ogretmen;

        }
        public bool Duzenle()
        {
            return data.SetExecuteNonQuery("Update Ogretmen set SinifId=@sinifid where Id=@id",
                CommandType.Text,
                new SqlParameter("@sinifid", _Sinif.Id),
                new SqlParameter("@id", Id)
                );

        }
        public bool GirisYap()
        {

            DataTable dt = data.GetExecuteDataTable("Select * from Ogretmen where Code=@code and Sifre=@sifre",
                CommandType.Text,
                new SqlParameter("@code", Code),
                new SqlParameter("@sifre", Sifre));

            if (dt.Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;

            }


        }
    }
}