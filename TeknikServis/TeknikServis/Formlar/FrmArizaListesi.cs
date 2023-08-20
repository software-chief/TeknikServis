using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaListesi : DevExpress.XtraEditors.XtraForm
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1(); 
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLURUNKABUL
                           select new
                           {
                               x.ISLEMID,                              
                               CARİ  = x.TBLCARI.AD + x.TBLCARI.SOYAD,                             
                               PERSONEL = x.TBLPERSONEL.AD + x.TBLPERSONEL.SOYAD,
                               x.GELISTARIH,
                               x.CIKISTARIH,
                               x.URUNSERINO,
                               x.URUNDURUMDETAY
                               
                               
                           };
                    gridControl1.DataSource = degerler.ToList();
            labelControl5.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUM == true).ToString();
           
            labelControl15.Text = db.TBLURUN.Count().ToString();
            labelControl7.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "Parça bekliyor.").ToString();
            
            

            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HCKP6VQ;Initial Catalog=DbTeknikServis;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT URUNDURUMDETAY, COUNT(*) FROM TBLURUNKABUL GROUP BY URUNDURUMDETAY", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),
                    int.Parse(dr[1].ToString()));

            }
            baglanti.Close();
            chartControl1.Series[0].LegendTextPattern = "{A}: {V:F1}";


        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmArizaDetaylar fr = new FrmArizaDetaylar();
            fr.id = gridView1.GetFocusedRowCellValue("ISLEMID").ToString();
            fr.serino = gridView1.GetFocusedRowCellValue("URUNSERINO").ToString();
            
            fr.Show();
        }
    }
}