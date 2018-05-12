using System;
using System.Windows;
using System.Windows.Forms;
using System.Threading;
using BLL.Entities.AviaTicket;
using BLL.Entities.Invoice;
using AviaTicketXMLParser.DB;
using BLL.Infrastructure;
using System.IO;
using System.Threading.Tasks;

namespace AviaTicketXMLParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileSystemWatcher watcher;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChooseTicketFolder(object sender, RoutedEventArgs e)
        {
            try
            {
                FolderBrowserDialog fbDialog = new FolderBrowserDialog();
                if (fbDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.ticketFolderPath.Text = fbDialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void StartMonitoring(object sender, RoutedEventArgs e)
        {
            this.watcher = new FileSystemWatcher();
            if (this.ticketFolderPath.Text != null && this.ticketFolderPath.Text != String.Empty)
            {
                this.watcher.Path = this.ticketFolderPath.Text;
                this.watcher.Changed += Parse_Ticket;
                Task.Run(() => this.watcher.WaitForChanged(WatcherChangeTypes.All));
                this.watcher.EnableRaisingEvents = true;
                this.status.Content = "Статус: нагляд за текою";
            }
        }
        private void ChooseTicket(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog fbDialog = new System.Windows.Forms.OpenFileDialog();
            if (fbDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.ticketPath.Text = fbDialog.FileName;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.watcher != null)
            {
                this.watcher.EnableRaisingEvents = false;
                this.watcher.Dispose();
            }
            this.status.Content = "Статус: очiкування";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                BLL.AviaTicketXMLParser parser = new BLL.AviaTicketXMLParser();
                AviaTicket ticket = parser.ParseTicket(this.ticketPath.Text).Result;
                using (AviaTicketModel db = new AviaTicketModel())
                {
                    db.AviaXMLTickets.Add(ticket);
                    db.SaveChanges();
                }
                AviaInvoice invoice = new Mapper(ticket).Map();
                using (InvoiceContext db = new InvoiceContext())
                {
                    db.Invoices.Add(invoice);
                    db.SaveChanges();
                }
                oneTicketTextBox.Content = "Квиток додано до БД.";
                Thread.Sleep(1000);
                oneTicketTextBox.Content = "Оберiть новий квиток.";
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Parse_Ticket(object sender, FileSystemEventArgs argv)
        {
            Task.Run(() =>
            {
                try
                {
                    watcher.EnableRaisingEvents = false;
                    if (argv.ChangeType == WatcherChangeTypes.Changed)
                    {
                        BLL.AviaTicketXMLParser parser = new BLL.AviaTicketXMLParser();
                        AviaTicket ticket = parser.ParseTicket(argv.FullPath).Result;
                        using (AviaTicketModel db = new AviaTicketModel())
                        {
                            db.AviaXMLTickets.Add(ticket);
                            db.SaveChanges();
                        }
                        AviaInvoice invoice = new Mapper(ticket).Map();
                        using (InvoiceContext db = new InvoiceContext())
                        {
                            db.Invoices.Add(invoice);
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.watcher.EnableRaisingEvents = true;
                }
            });           
        }
    }
}
