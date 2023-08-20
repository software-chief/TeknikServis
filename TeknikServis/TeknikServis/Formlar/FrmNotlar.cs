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
    public partial class FrmNotlar : DevExpress.XtraEditors.XtraForm
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        void metot1()
        {
            var degerler = from u in db.TBLNOTLARIM
                           select new
                           {
                               u.ID,
                               u.BASLIK,
                               u.ICERIK,
                               u.DURUM
                               

                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            gridControl2.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl1.DataSource = db.TBLNOTLARIM.Where(y => y.DURUM == true).ToList();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLNOTLARIM t = new TBLNOTLARIM();
            t.BASLIK = TxtBaslik.Text;
            t.ICERIK = TxtIcerik.Text;
            t.DURUM = false;
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            db.TBLNOTLARIM.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl1.DataSource = db.TBLNOTLARIM.Where(y => y.DURUM == true).ToList();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if(checkEdit1.Checked == true)
            {
                int id = int.Parse(TxtID.Text);
                var deger = db.TBLNOTLARIM.Find(id);
                deger.DURUM = true;
               
                db.SaveChanges();
                MessageBox.Show("Durum değiştirildi.", "Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView2.GetFocusedRowCellValue("ID").ToString();
        }
    }
}