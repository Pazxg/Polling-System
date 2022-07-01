﻿using MvcWepApp2.DAL;
using MvcWepApp2.Models.Abstrack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MvcWepApp2.Models
{

    public class Sinif: ModelBase
    {
        SqlDataProcess data;

        public Sinif()
        {
            data = new SqlDataProcess();
        }
     
        public string Adi { get; set; }
        public string Kodu { get; set; }

        public List<Sinif> ListeGetir()
        {
        

            List<Sinif> siniflar = new List<Sinif>();
            DataTable dtSiniflar = data.GetExecuteDataTable("Select * from Sinif", CommandType.Text);


            foreach (DataRow dataRow in dtSiniflar.Rows)
            {
                siniflar.Add(new Sinif
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    Adi = dataRow["SinifAdi"].ToString(),
                    Kodu = dataRow["SinifKodu"].ToString()
                });
            }
            return siniflar;
        }

        public bool Ekle()
        {
            try
            {
                return data.SetExecuteNonQuery("Insert into Sinif (SinifAdi, SinifKodu) values(@sinifadi, @sinifkodu)",
                    CommandType.Text,
                    new SqlParameter("@sinifadi",Adi),
                    new SqlParameter("@sinifkodu",Kodu));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Sil()
        {
            return data.SetExecuteNonQuery("Delete from Sinif where Id=@Id",CommandType.Text,new SqlParameter("@Id",Id));
        }
    }
}