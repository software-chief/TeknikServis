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


namespace TeknikServis.Formlar
{
    public partial class FrmIstatistik : DevExpress.XtraEditors.XtraForm
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        
       
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            labelControl2.Text=db.TBLURUN.Count().ToString();
            labelControl3.Text=db.TBLKATEGORI.Count().ToString();
            labelControl5.Text = db.TBLURUN.Sum(x => x.STOK).ToString();
            //En fazla stoklu ürün.
            labelControl19.Text = (from x in db.TBLURUN
                                   orderby x.STOK descending
                                   select x.AD).FirstOrDefault();
            //En az stoklu ürün.
            labelControl18.Text = (from x in db.TBLURUN
                                   orderby x.STOK ascending 
                                   select x.AD).FirstOrDefault();
            //En yüksek fiyatlı ürün.
            labelControl13.Text=(from x in db.TBLURUN
                                orderby x.SATISFIYAT descending
                                select x.AD).FirstOrDefault();
            //En düşük fiyatlı ürün.
            labelControl12.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT ascending
                                   select x.AD).FirstOrDefault();
            //Toplam marka sayısı.
            labelControl25.Text = db.TBLURUN.Count( x => x.KATEGORI == 4).ToString();   
            labelControl27.Text = db.TBLURUN.Count( x => x.KATEGORI == 1).ToString();   
            labelControl29.Text = db.TBLURUN.Count( x => x.KATEGORI == 3).ToString();
            labelControl35.Text = (from x in db.TBLURUN
                                   select x.MARKA).Distinct().Count().ToString();

            labelControl33.Text = db.TBLURUNKABUL.Count().ToString();

            labelControl16.Text = db.MAKSKATEGORI().FirstOrDefault();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           //Yenile butonu.
        }
    }
}