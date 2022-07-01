using MvcWepApp2.DAL;
using MvcWepApp2.Models.Abstrack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace MvcWepApp2.Models
{
    public class Ogrenci: ModelBase
    {
        SqlDataProcess data;
        public Ogrenci()
        {
            data = new SqlDataProcess();
        }

       
        public string Adi { get; set; }
        public string Soyad { get; set; }
        public string No { get; set; }
        public Sinif _Sinif { get; set; }
        public int SinifId { get; set; }


        public List<Ogrenci> OgrencileriGetir()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();


            DataTable dtogrenciler = data.GetExecuteDataTable("Ogrenci_ListeGetir", CommandType.StoredProcedure);


            foreach (DataRow dataRow in dtogrenciler.Rows)
            {
                ogrenciler.Add(new Ogrenci
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    Adi = dataRow["OgrenciAdi"].ToString(),
                    Soyad = dataRow["OgrenciSoyadi"].ToString(),
                    No = dataRow["OgrenciNo"].ToString(),
                    _Sinif = new Sinif
                    {
                        Adi = dataRow["SinifAdi"].ToString(),
                        Kodu = dataRow["SinifKodu"].ToString()
                    }

                });
            }
            return ogrenciler;
        }
        public List<Ogrenci> OgrencileriGetirSinifId()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();


            DataTable dtogrenciler = data.GetExecuteDataTable("Ogrenci_ListeGetirSinifId", CommandType.StoredProcedure, new SqlParameter("@SinifId", SinifId)
                );


            foreach (DataRow dataRow in dtogrenciler.Rows)
            {
                ogrenciler.Add(new Ogrenci
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    Adi = dataRow["OgrenciAdi"].ToString(),
                    Soyad = dataRow["OgrenciSoyadi"].ToString(),
                    No = dataRow["OgrenciNo"].ToString(),
                   
                });
            }
            return ogrenciler;
        }
        public Ogrenci OgrenciGetirId()
        {
            DataTable dt = data.GetExecuteDataTable("Ogrenci_Getir", CommandType.StoredProcedure, new SqlParameter("@id", Id));
            Ogrenci _ogrenci = new Ogrenci();
            if (dt.Rows.Count > 0)
            {
                _ogrenci.Id = dt.Rows[0].Field<int>("Id");
                _ogrenci.Adi = dt.Rows[0].Field<string>("OgrenciAdi");
                _ogrenci.Soyad = dt.Rows[0].Field<string>("OgrenciSoyadi");
                _ogrenci.No = dt.Rows[0].Field<string>("OgrenciNo");
                _ogrenci._Sinif = new Sinif { Adi = dt.Rows[0].Field<string>("SinifAdi") };
            }
            
            return _ogrenci;

        }
        public bool Ekle()
        {
            try
            {
                return data.SetExecuteNonQuery("Insert into Ogrenci (OgrenciAdi,OgrenciSoyadi,OgrenciNo,SinifId) values(@ogrenciAdi, @ogrenciSoyadi, @ogrenciNo, @sinifId)",
                    CommandType.Text,
                    new SqlParameter("@ogrenciAdi", Adi),
                    new SqlParameter("@ogrenciSoyadi", Soyad),
                    new SqlParameter("@ogrenciNo", No),
                    new SqlParameter("@sinifId", _Sinif.Id)

                    );
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
                return data.SetExecuteNonQuery("Delete from Ogrenci where Id=@id", CommandType.Text,
                    new SqlParameter("@id", Id));
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Duzenle()
        {
            return data.SetExecuteNonQuery("Update Ogrenci set SinifId=@sinifid where Id=@id",
                CommandType.Text,
                new SqlParameter("@sinifid",_Sinif.Id),
                new SqlParameter("@id",Id)
                );

        }
    }
}
