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
using System.Data.Entity;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmMarkalar : DevExpress.XtraEditors.XtraForm
    {
        public FrmMarkalar()
        {
            InitializeComponent();
           
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            
            var degerler = db.TBLURUN.OrderBy(x=> x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,Toplam=z.Count()
            });
            gridControl1.DataSource = degerler.ToList();
            //------------------------------------------------------
            labelControl3.Text = (from x in db.TBLURUN
                                   select x.MARKA).Distinct().Count().ToString();
            labelControl5.Text = db.TBLURUN.Count().ToString();
            //------------------------------------------------------

            labelControl1.Text = (from x in db.TBLURUN
                                  orderby x.SATISFIYAT descending
                                  select x.MARKA).FirstOrDefault();





            //chartControl1.Series["Series 1"].Points.AddPoint("Siemens",4);
            //chartControl1.Series["Series 1"].Points.AddPoint("Arçelik",3);
            //chartControl1.Series["Series 1"].Points.AddPoint("Asus",2);
            //chartControl1.Series["Series 1"].Points.AddPoint("Gigabyte",1);
            //chartControl1.Series["Series 1"].Points.AddPoint("Apple",6);

            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HCKP6VQ;Initial Catalog=DbTeknikServis;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT MARKA, COUNT(*) FROM TBLURUN GROUP BY MARKA", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),
                    int.Parse(dr[1].ToString()));

            }
            baglanti.Close();
            chartControl1.Series[0].LegendTextPattern = "{A}: {V:F1}";

            //CHART 2            

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT TBLKATEGORI.AD, COUNT(*) " +
                "FROM TBLURUN INNER JOIN TBLKATEGORI ON " +
                "TBLKATEGORI.ID = TBLURUN.KATEGORI GROUP BY TBLKATEGORI.AD", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr2[0]),
                    int.Parse(dr2[1].ToString()));
            }
            baglanti.Close();


            chartControl2.Series[0].LegendTextPattern = "{A}: {V:F1}";



        }
    }
}