using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicineTracker
{
    /// <summary>
    /// Interaction logic for MedicineRecords.xaml
    /// </summary>
    public partial class MedicineRecords : UserControl
    {
        // Will move this business logic to mvvm later
        DataSet m_records;
        DataTable m_dataTable = new DataTable();

        int x;
        string m_medName;
        int m_medDoseMrng;
        int m_medDoseAft;
        int m_medDoseEve;
        int m_totalPills;
        public DateTime m_endDate;

        public MedicineRecords()
        {
            InitializeComponent();
            labelNameVal.Content = Model.Name;
            labelAgeVal.Content = Model.Age;
            labelDaigVal.Content = Model.Diagnosis;
            CreateDataTable();
            //m_records
            recordGrid.ItemsSource = m_dataTable.DefaultView;
        }

        void CreateDataTable()
        {
            m_dataTable.Columns.Add(new DataColumn("Medicine Name", typeof(string)));
            m_dataTable.Columns.Add(new DataColumn("Morning Dose", typeof(int)));
            m_dataTable.Columns.Add(new DataColumn("Afternoon Dose", typeof(int)));
            m_dataTable.Columns.Add(new DataColumn("Evening Dose", typeof(int)));
            m_dataTable.Columns.Add(new DataColumn("Total Pills", typeof(int)));
            m_dataTable.Columns.Add(new DataColumn("Doses Ending", typeof(DateTime)));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            m_medName = txtMedName.Text;
            m_medDoseMrng = Int32.Parse(txtMedDoseMrng.Text); 
            m_medDoseAft = Int32.Parse(txtMedDoseAft.Text);
            m_medDoseEve = Int32.Parse(txtMedDoseEve.Text);
            m_totalPills = Int32.Parse(txtTotalPills.Text);
            x = Int32.Parse(txtTotalPills.Text) / (Int32.Parse(txtMedDoseMrng.Text) + Int32.Parse(txtMedDoseAft.Text) + Int32.Parse(txtMedDoseEve.Text));
            m_endDate = DateTime.Now.AddDays(value:x-1);
          
            
            /// Event For Empty Text Boxes 
            txtMedName.Clear();
            txtMedDoseMrng.Clear();
            txtMedDoseAft.Clear();
            txtMedDoseEve.Clear();
            txtTotalPills.Clear();
           
            /// To Get Entered Medicine Details In Table
            m_dataTable.Rows.Add(m_medName,
                m_medDoseMrng,
                m_medDoseAft,
                m_medDoseEve,
                m_totalPills,
                m_endDate);

           
        }
    }
}