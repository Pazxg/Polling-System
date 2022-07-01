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
    public class Kullanici: ModelBase
    {
        SqlDataProcess data;
        public Kullanici()
        {
            data = new SqlDataProcess();
        }

        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string AdSoyad { get; set; }
        public bool GirisYap()
        {

            DataTable dt = data.GetExecuteDataTable("Select * from Kullanici where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre",
                CommandType.Text,
                new SqlParameter("@KullaniciAdi", KullaniciAdi),
                new SqlParameter("@Sifre", Sifre));

            if (dt.Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;

            }


        }
        public List<Kullanici> TumKullanicilariGetir()
        {
            List<Kullanici> kullanicilar = new List<Kullanici>();
            DataTable dtkullanicilistesi = data.GetExecuteDataTable("Select * from Kullanici where Silindi=0", CommandType.Text);

            foreach (DataRow dataRow in dtkullanicilistesi.Rows)
            {
                kullanicilar.Add(new Kullanici
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    KullaniciAdi = dataRow["KullaniciAdi"].ToString(),
                    Sifre = dataRow["Sifre"].ToString(),
                    AdSoyad = dataRow["AdSoyad"].ToString()
                });
            }
            return kullanicilar;
        }
        public bool KullaniciEkle()
        {
            try
            {
                return data.SetExecuteNonQuery("Insert into Kullanici (KullaniciAdi, Sifre, AdSoyad) values(@kullaniciadi, @sifre, @adsoyad)",
                    CommandType.Text,
                    new SqlParameter("@kullaniciadi", KullaniciAdi),
                    new SqlParameter("@sifre", Sifre),
                    new SqlParameter("@adsoyad", AdSoyad)
                    );
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool KullaniciSil()
        {
            try
            {
                return data.SetExecuteNonQuery("Update Kullanici set Silindi=1 where Id=@id",
                    CommandType.Text,
                    new SqlParameter("@id", Id)
                    );
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Kullanici KullaniciDetayGetir()
        {
            Kullanici kullanici = new Kullanici();

            DataTable dtkullanici = data.GetExecuteDataTable("Select * from Kullanici where Silindi=0 and Id=@id",
                CommandType.Text,
                new SqlParameter("@id", Id));

            if (dtkullanici.Rows.Count > 0)
            {
                kullanici.AdSoyad = dtkullanici.Rows[0]["AdSoyad"].ToString();
                kullanici.KullaniciAdi = dtkullanici.Rows[0]["KullaniciAdi"].ToString();
            }
            return kullanici;
        }
        public bool KullaniciGuncelle()
        {
            try
            {
                return data.SetExecuteNonQuery("Update Kullanici set KullaniciAdi=@kullaniciadi, AdSoyad=@adsoyad where Id=@id",
                    CommandType.Text,
                    new SqlParameter("@kullaniciadi", KullaniciAdi),
                    new SqlParameter("@adsoyad", AdSoyad),
                    new SqlParameter("@id", Id)
                    );
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}