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
    public partial class FrmCariListesi : DevExpress.XtraEditors.XtraForm
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        

        void metot1()
        {
            var degerler = from x in db.TBLCARI
                           select new
                           {
                               x.ID,
                               x.AD,
                               x.SOYAD,
                               x.IL,
                               x.ILCE

                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            metot1();
            labelControl12.Text = db.TBLCARI.Count().ToString();
            labelControl14.Text = db.TBLCARI.Select(x => x.IL).Distinct().Count().ToString();
            labelControl18.Text = db.TBLCARI.Select(x => x.ILCE).Distinct().Count().ToString();

            
        }

        private void LookIl_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAdress.Text != "" & TxtCariSoyad.Text != "" & TxtCariAd.Text.Length <= 20)
            {
                TBLCARI t = new TBLCARI();
                t.AD = TxtCariAd.Text;
                t.SOYAD = TxtCariSoyad.Text;
                t.IL = TxtIl.Text;
                t.ILCE = TxtIlce.Text;
                t.TELEFON = TxtTelefon.Text;
                t.ADRES = TxtAdress.Text;
                db.TBLCARI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Cari Sisteme Eklendi.", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                metot1();
            }

            else
            {
                MessageBox.Show("Hatalı Giriş, Tekrar Deneyin.", "Hata", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
            

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot1();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtCariAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtIl.Text = gridView1.GetFocusedRowCellValue("IL").ToString();
            TxtIlce.Text = gridView1.GetFocusedRowCellValue("ILCE").ToString();
            //TxtVergiDairesi.Text = gridView1.GetFocusedRowCellValue("VERGIDAIRESI").ToString();
            //TxtVergiNo.Text = gridView1.GetFocusedRowCellValue("VERGINO").ToString();
            //TxtStatu.Text = gridView1.GetFocusedRowCellValue("STATU").ToString();
            //TxtBanka.Text = gridView1.GetFocusedRowCellValue("BANKA").ToString();
            //TxtAdress.Text = gridView1.GetFocusedRowCellValue("ADRES").ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLCARI.Find(id);
            deger.AD = TxtCariAd.Text;
            deger.IL = TxtIl.Text;
            deger.ILCE = TxtIlce.Text;
            deger.BANKA = TxtBanka.Text;
            deger.TELEFON = TxtTelefon.Text;
            deger.VERGIDAIRESI = TxtVergiDairesi.Text;
            deger.ADRES = TxtAdress.Text;
            deger.VERGINO = TxtVergiNo.Text;

           
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi başarıyla gerçekleştirildi!", "Bilgi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLCARI.Find(id);
            db.TBLCARI.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi başarıyla gerçekleştirildi!", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}