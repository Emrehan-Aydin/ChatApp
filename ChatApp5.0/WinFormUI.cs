using EasyFileTransfer;
using Library;
using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ChatApp5._0
{
    public partial class WinFormUI : Form
    {
        public WinFormUI()
        {
            InitializeComponent();
        }
        // Program içerisinde kullanacağımız global değişkenler
        private Socket socket; // veri transferi için programın her yerinde kullanmamız gereken soketimiz.
        private EndPoint epLocal, epRemote; // Local Ip miz ve Karşı tarafın ağdaki local IP si
        private byte[] buffer; // gelen Veri için buffer dizimiz.
        private string senderPassword; // gönderdiğimiz şifre
        private string message; // gönderilmek istenen mesaj hafızamız
        private string algorithm; // program içerisindeki şifreleme algoritması
        private void Form1_Load(object sender, EventArgs e)
        {
            // soket ataması
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            // Ip adresimizin arayüze atanması
            txtLocalIp.Text = GetLocalIp();

            // ilk açılışta program arayüzün için erişim engel metodu
            btnEnterPassword.Hide();
            ControlComponents(false);


        }
        // Connect Button click event metodu
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect(txtLocalIp.Text, txtRemoteIp.Text);
        }

        private void Connect(string _localIp, string _remoteIp)
        {
            // Dosya transferi için asenkron port dinleme metodu
            try
            {
                // Gelen dosyanın nereye kaydedileceği ve hangi porttan geleceği.
                EftServer server = new EftServer(@"C:\Download\", Convert.ToInt32(8082));
                // UDP sunucu başlatılıyor (Dinlemeye başlandı)
                System.Threading.Thread obj_thread = new System.Threading.Thread(server.StartServer);
                obj_thread.Start();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                // Girilen IP adresinin doğru formatta olup olmadığını kontrol eden validation metod.
                Ipv4Validator validator= new Ipv4Validator();
                validator.ValidateIPv4(_remoteIp);
                // Arayüz de eksik veri kalmaması için kontroller
                if (_remoteIp.Trim() != string.Empty)
                {
                    txtRemoteIp.Enabled = false;
                    // binding socket
                    epLocal = new IPEndPoint(IPAddress.Parse(_localIp), Convert.ToInt32(80));
                    socket.Bind(epLocal);

                    // connecting to remote ip
                    epRemote = new IPEndPoint(IPAddress.Parse(_remoteIp), Convert.ToInt32(80));
                    socket.Connect(epRemote);

                    // listening the specific port
                    buffer = new byte[1500];
                    var a = socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote,
                        new AsyncCallback(MessageCallBack), buffer);
                    // arayüz erişim kontrolleri
                    btnConnect.Enabled = false;
                    ControlComponents(true);
                    status.ForeColor = Color.Green;
                    status.Text = "Online";
                }
                else
                {
                    MessageBox.Show("Please enter all fields");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        // Local IP mizi getiren metodumuz.
        private string GetLocalIp()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            // Herhangi bir ağa bağlı değilse LocalHost Ip si geri döner
            return "127.0.0.1";
        }
        // Send button click efent
        private void btnSend_Click(object sender, EventArgs e)
        {
            // RadioButton dan seçilen algoritma verisi almak
            algorithm = rb_algorithm_SPN.Checked ? rb_algorithm_SPN.Text : rb_algorithm_SHA.Text;
            try { 
                // Gönderilecek mesajın içeriği oluşturulur
                byte[] data = send(txtMessage.Text, txtPassword.Text, algorithm);
                // gelen data ilgili sokete gönderilir.
                socket.Send(data);
                // Arayüz Feedback
                listMessages.Items.Add("Me: " + txtMessage.Text);
                txtMessage.Text = "";
                txtPassword.Text = "";
                // arayüz atamaları
                ButtonCheck();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        private byte[] send(string? _message,string? _password , string _algorithm)
        {
            try
            {
                // Convert string message to byte[]
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                byte[] sendingMessage = new byte[1500];

                if (_password != "" && _message != "")
                {
                    // Şifrelenecek mesajın tam 16 Byte ve katları olması gerekmektedir.
                    _message = _message.Length % 2 == 0 ? _message : _message += " ";
                    // Türkçe Karakter düzenlemesi
                    ConvertAscii command = new ConvertAscii();
                    _message = command.ConvertToAsciFormat(_message);
                    sendingMessage = EnCrypto(_message, _password, _algorithm, aEncoding, sendingMessage);
                    // şifrelenmiş veriyi geri döner.
                    return sendingMessage;
                }
                else
                {
                    throw new InvalidCastException("Please enter all fields");
                }
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(exception.Message);
            }
        }
        //Şifreleme metodları çağırılır.
        private byte[] EnCrypto(string _message, string _password, string _algoritmText, ASCIIEncoding aEncoding, byte[] sendingMessage)
        {
            // Şifrelenecek mesaj için algoritma yönlendirmesi yapılır.
            // SHA 256 ile şifreleme 
            if (_algoritmText == "SHA 256")
                sendingMessage = aEncoding.GetBytes(_algoritmText.Trim() + "??__" + _message.Trim() + "??__" + sha256(_password));
            // SPN şifreleme algoritması
            else if (_algoritmText == "SPN")
            {
                if (_password.Length != 8)
                    throw new InvalidOperationException("Please enter an 8-character password");
                SPN spn = new SPN();
                _message = aEncoding.GetString(spn.Encode(_message, _password));
                sendingMessage = aEncoding.GetBytes(_algoritmText.Trim() + "??__" + _message + "??__" + _password);
            }
            // şifrelenmiş mesajı geri döndürür.
            return sendingMessage;
        }

        //Dinlenilen porttan gelen verileri dinleyen asenkron metod
        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {  
                // Gelecek veri için buffer
                byte[] receiveData = new byte[1024 * 8];
                receiveData = (byte[])aResult.AsyncState;
                // converting byte[] to string
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                string receivedMessage = aEncoding.GetString(receiveData);
                // Gelen tüm eriyi eritmek için kullanılan yapı 
                //Örnek : ŞifrelemeAlgoritması??__mesaj??__şifre
                string[] post = receivedMessage.Split("??__");
                // Gelen verilerin atanması
                algorithm = post[0];
                message = post[1];
                senderPassword = post[2];
                // Gelen mesajı listbox'a ekleme
                if (post[0] == "SPN")
                {
                    BinaryToText Get = new BinaryToText();
                    listMessages.Items.Add("Friend: " + post[0] + "-" + message);
                }
                else if(post[0] == "SHA 256")
                {
                    listMessages.Items.Add("Friend: " + post[0] + "-" + sha256(post[1]));
                }
                
                buffer = new byte[1500];
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote,
                    new AsyncCallback(MessageCallBack), buffer);
                // Mesaj geldiğinde arayüzdeki değişiklikler.
                ButtonCheck();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        // Sha256 şifreleme metodu
        private string sha256(string text)
        {
            SHA256 sha256Encrypting = new SHA256CryptoServiceProvider();
            byte[] bytes = sha256Encrypting.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder builder = new StringBuilder();

            foreach (var item in bytes)
            {
                builder.Append(item.ToString("x2"));
            }

            return builder.ToString();
        }
        // Enter password button click eventi
        private void btnEnterPassword_Click(object sender, EventArgs e)
        {
            // gelen şifre atanması ve eboş mu kontrolü ?
            string password;
            if (txtPassword.Text != "")
            {
                // Gelen mesaj hangi algoritma ile şifrelenmiş.
                if (algorithm == "SHA 256")
                {
                    //Sha için anahtar kontorlü
                    password = sha256(txtPassword.Text);
                }
                else if (algorithm=="SPN")
                {
                    //Şifremiz ile mesaj çözülüyor.
                    password = txtPassword.Text;
                    SPN spn = new SPN();
                    BinaryToText Get = new BinaryToText();
                    message = Get.GetBytesFromBinaryString(spn.Decode(message.ToCharArray(), senderPassword));
                }
                else
                {
                    password = "";
                }
                //Gelen parola doğruysa arayüze mesajı günceller.
                if (senderPassword.Contains(password))
                {
                    MessageBox.Show("Password is correct");
                    listMessages.Items[^1] = "Friend: " + message;
                    btnEnterPassword.Hide();
                    btnSend.Show();
                    txtMessage.Enabled = true;
                    txtPassword.Text = "";
                    //ButtonCheck();
                }
                else
                {
                    MessageBox.Show("Password is not correct. Try again.");
                    btnEnterPassword.Hide();
                    btnSend.Show();
                    txtMessage.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Please enter password");
            }
        }


        private void ButtonCheck()
        {
            // Gelen mesajın düzgün bir şekilde ekranda gözükmesi ve düzenlemeleri
            string message = listMessages.Items[^1].ToString();
            string[] messagelist = message.Split(":");
            // Gelen veri için enter password buttonunu aktif hale getirir.
            if (messagelist[0] == "Friend")
            {
                btnEnterPassword.Show();
                btnSend.Hide();
                txtMessage.Enabled = false;
            }
            else
            {
                btnEnterPassword.Hide();
                btnSend.Show();
                txtMessage.Enabled = true;
            }

        }
        // Componentleri açma ve kapatma metodumuz.
        private void ControlComponents(bool value)
        {
            txtPassword.Enabled = value;
            txtMessage.Enabled = value;
            listMessages.Enabled = value;
            btnEnterPassword.Enabled = value;
            btnSend.Enabled = value;
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            // Upload edilecek dosyanın alınması.
            string filenametouse = SelectFileDialog.FileName;
            try
            {
                if (SelectFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Seçilen dosya yolunun atanması.
                    filenametouse = SelectFileDialog.FileName;
                    worker.Value = 5;// progress bar güncellemesi
                    //Dosyayı sıkıştırma ve geçiçi olarak tutma
                    using (var archive = ZipFile.Open(@"C:\Upload\"+ Path.GetFileNameWithoutExtension(filenametouse) + ".zip", ZipArchiveMode.Create))
                    {
                        worker.Value = 10;
                        archive.CreateEntryFromFile(SelectFileDialog.FileName, Path.GetFileName(SelectFileDialog.FileName));
                    }
                    worker.Value = 50; // progress bar güncelleme
                    // EasyFile Transfer metodumuz ile ilgili dosyanın gönderim işlemi.
                    EasyFileTransfer.Model.Response rsp = EftClient.Send(@"C:\Upload\" + Path.GetFileNameWithoutExtension(filenametouse) + ".zip", txtRemoteIp.Text, 8082);
                    worker.Value = 100; // progress güncellemesi
                    if (rsp.status == 1)
                    {
                        // Dosyanın tamamı gönderildi mi ?
                        worker.Value = 100;
                        // Oluşturulan sıkıştırılmış dosyanın silinmesi.
                        File.Delete(@"C:\Upload\" + Path.GetFileNameWithoutExtension(filenametouse) + ".zip");
                        
                        MessageBox.Show("send successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    }
                    worker.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File receiving error :" + ex.Message.ToString());
            }
        }
        // Logout button click eventi
        private void btn_logout_Click(object sender, EventArgs e)
        {
            // Programın kapatılması kullanıcıya sorulur.
            var sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
                
            }
            if (sonuc == DialogResult.Yes)
            {
                // Program kapatılır.
                System.Environment.Exit(1);
            }
        }

        private void btn_logout_Click(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Çıkış Başarılı");  
        }

        private void Btn_SelectFile_Click(object sender, EventArgs e)
        {
            //1 tane string dizi değişkeni tanımlıyoruz.
            string[] secilendosyayolu;
            //dosya seçtirmek için dialoğu çıkartıyoruz.
            SelectFileDialog.ShowDialog();
            //seçtiğimiz dosyanın yolunu dizimize alıyoruz.
            secilendosyayolu = SelectFileDialog.FileNames;
            //dosyayının uzunluğu kadar dönüp listboxa basıyoruz.
        }
    }
}
