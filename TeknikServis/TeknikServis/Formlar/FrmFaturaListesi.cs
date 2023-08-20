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
    public partial class FrmFaturaListesi : DevExpress.XtraEditors.XtraForm
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();

        void metot1()
        {
            var degerler = from u in db.TBLFATURABILGI
                           select new
                           {
                               u.ID,
                               u.SERI,
                               u.SIRANO,
                               u.TARIH,
                               u.SAAT,
                               u.VERGIDAIRE,
                               CARI = u.TBLCARI.AD + u.TBLCARI.SOYAD,
                               PERSONEL = u.TBLPERSONEL.AD + u.TBLPERSONEL.SOYAD

                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmFaturaListesi_Load(object sender, EventArgs e)           
        {
            metot1();
            LookCari.Properties.DataSource = (from x in db.TBLCARI
                                                    select new
                                                    {
                                                        x.ID,
                                                       AD = x.AD + " " + x.SOYAD

                                                    }).ToList();
            LookPersonel.Properties.DataSource = (from x in db.TBLPERSONEL
                                              select new
                                              {
                                                  x.ID,
                                                  AD = x.AD + " " + x.SOYAD

                                              }).ToList();

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot1();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURABILGI t = new TBLFATURABILGI();
            t.SERI = TxtSeriNo.Text;
            t.SIRANO = TxtSiraNo.Text;
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.SAAT = TxtSaat.Text;
            t.VERGIDAIRE = TxtVergiDaire.Text;
            t.CARI = int.Parse(LookCari.EditValue.ToString());
            t.PERSONEL = short.Parse(LookPersonel.EditValue.ToString());
            db.TBLFATURABILGI.Add(t);
            db.SaveChanges();   
            MessageBox.Show("Faturanız sisteme işlendi.", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }

        
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaKalemPopup fr = new FrmFaturaKalemPopup();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());          
            fr.Show();
        }
    }
    }
