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
    public partial class FrmPersonel : DevExpress.XtraEditors.XtraForm
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        void metot1()
        {
            var degerler = from u in db.TBLPERSONEL
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.MAIL,
                               u.TELEFON,
                               u.DEPARTMAN

                           };
            gridControl1.DataSource = degerler.ToList();
        }

        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
           

            metot1();
            TxtPersonelDep.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                   select new
                                                   {
                                                       x.ID,
                                                       x.AD,
                                                       
                                                   }).ToList();

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot1();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLPERSONEL t = new TBLPERSONEL();
            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.DEPARTMAN = byte.Parse(TxtPersonelDep.EditValue.ToString());
            t.MAIL = TxtMail.Text;
            t.TELEFON = TxtTelefon.Text;
            
            db.TBLPERSONEL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
           
            //TxtFotograf.Text = gridView1.GetFocusedRowCellValue("FOTOGRAF").ToString();
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLPERSONEL.Find(id);
            deger.AD = TxtAd.Text;
            deger.SOYAD = TxtSoyad.Text;
            deger.TELEFON = TxtTelefon.Text;
            deger.MAIL = TxtMail.Text;
           
            
            //deger.DEPARTMAN = (TxtPersonelDep.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi başarıyla gerçekleştirildi!", "Bilgi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}